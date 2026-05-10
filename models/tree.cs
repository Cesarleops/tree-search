namespace TreeSearch.Models;


public class Tree
{
    public DocumentNode root;


    public int Height(DocumentNode currNode)
    {
        if(currNode == null){
            return 0;
        }
        int leftHeight = Height(currNode.left);
        int rightHeight = Height(currNode.right);
        return 1 + Math.Max(leftHeight, rightHeight);
    }
    
    public List<string> Walk(string order)
    {
        List<string> path = new List<string>();

        switch (order)
        {
            case "BFS":
                path = BFS();
                break;
            case "ascii":
                printFolder(this.root, 0);
                break;
            case "PreOrder":
                preOrderWalk(this.root, path);
                break;
            case "InOrder":
                inOrderWalk(this.root, path);
                break;
            case "PostOrder":
                postOrderWalk(this.root, path);
                break;

        }
        return path;
    }

    public DocumentNode Insert(DocumentNode currNode, DocumentNode newNode)
    {
        if (currNode == null)
        {
            return newNode;
        }

        int comparison = DocumentNode.Compare(newNode.value.name, currNode.value.name);

        if (comparison < 0)
        {
            currNode.left = Insert(currNode.left, newNode);
        }
        else if (comparison > 0)
        {
            currNode.right = Insert(currNode.right, newNode);
        }

        return currNode;

    }

    public DocumentNode Update(string filename, string newFilename)
    {

        // Eliminar el documento que tenga el nombre
        this.root = Delete(filename, this.root, out _);

        DocumentNode newNode = new DocumentNode(newFilename, false);

        this.root = Insert(this.root, newNode);
        // Añadir un nuevo documento con el nuevo nombre para que quede actualizado.
        return this.root;
    }

    public DocumentNode Search(string filename, DocumentNode currentNode, out int comparisons)
    {
        if (currentNode == null)
        {
            comparisons = 0;
            return null;
        }

        comparisons = 1;

        if (currentNode.value.name == filename)
        {
            return currentNode;
        }

        comparisons++;

        if (DocumentNode.Compare(filename, currentNode.value.name) < 0)
        {
            DocumentNode result = Search(filename, currentNode.left, out int subComparisons);
            comparisons += subComparisons;
            return result;
        }
        else
        {
            DocumentNode result = Search(filename, currentNode.right, out int subComparisons);
            comparisons += subComparisons;
            return result;
        }
    }

    public DocumentNode Delete(string filename, DocumentNode currentNode, out string deletionType)
    {
        deletionType = "";

        if (currentNode == null)
        {
            return null;
        }

        int comparison = DocumentNode.Compare(filename, currentNode.value.name);
        if(comparison < 0)
        {
            currentNode.left = Delete(filename, currentNode.left, out deletionType);
            return currentNode;

        }
        else if (comparison > 0)
        {
            currentNode.right = Delete(filename, currentNode.right, out deletionType);
            return currentNode;
        }

        if (currentNode.IsLeaf())
        {
            deletionType = "hoja";
            return null;
        }

        if (currentNode.right != null && currentNode.left == null)
        {
            deletionType = "un hijo";
            return currentNode.right;
        }

        if (currentNode.left != null && currentNode.right == null)
        {
            deletionType = "un hijo";
            return currentNode.left;
        }

        deletionType = "dos hijos";
        DocumentNode minSuccessor = getMinSuccesor(currentNode.right);
        currentNode.value = minSuccessor.value;
        currentNode.right = Delete(minSuccessor.value.name, currentNode.right, out _);

        return currentNode;

    }

    private DocumentNode getMinSuccesor(DocumentNode node)
    {
        DocumentNode curr = node;
        while (curr.left != null)
        {
            curr = curr.left;
        }
        return curr;
    }

    private void printFolder(DocumentNode node, int identation)
    {
        if (node == null)
        {
            return;
        }
        
        Console.WriteLine("|--"+new string('-', identation) +  node.value.name);

        printFolder(node.left, identation + 1);
        printFolder(node.right, identation + 1);
    }

    private List<string> BFS()
    {
        List<string> path = new List<string>();
        Queue<DocumentNode> q = new Queue<DocumentNode>();
        q.Enqueue(this.root);
        while (q.Count > 0)
        {
            DocumentNode node = q.Dequeue();
            path.Add(node.value.name);
            if (node.left != null)
            {
                q.Enqueue(node.left);
            }
            if (node.right != null)
            {
                q.Enqueue(node.right);
            }

        }
        return path;
    }

    private void preOrderWalk(DocumentNode currNode, List<string> path)
    {
        if (currNode == null)
        {
            return;
        }
        path.Add(currNode.value.name);
        preOrderWalk(currNode.left, path);
        preOrderWalk(currNode.right, path);

    }

    private void postOrderWalk(DocumentNode currNode, List<string> path)
    {
        if (currNode == null)
        {
            return;
        }
        postOrderWalk(currNode.left, path);
        postOrderWalk(currNode.right, path);
        path.Add(currNode.value.name);

    }

    private void inOrderWalk(DocumentNode currNode, List<string> path)
    {
        if (currNode == null)
        {
            return;
        }
        inOrderWalk(currNode.left, path);
        path.Add(currNode.value.name);
        inOrderWalk(currNode.right, path);
    }
}