namespace TreeSearch.Models;


public class Tree
{
    public FileNode root;

    public List<string> Walk(string order)
    {
        List<string> path = new List<string>();

        switch (order)
        {
            case "BFS":
                path = BFS();
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

    public FileNode Insert(FileNode currNode, FileNode newNode)
    {
        if (currNode == null)
        {
            return newNode;
        }

        int comparison = FileNode.Compare(newNode.name, currNode.name);

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

    public FileNode Update(string filename, string newFilename)
    {

        // Eliminar el documento que tenga el nombre
        this.root = Delete(filename, this.root);

        FileNode newNode = new FileNode(newFilename);

        this.root = Insert(this.root, newNode);
        // Añadir un nuevo documento con el nuevo nombre para que quede actualizado.
        return this.root;
    }

    public FileNode Search(string filename, FileNode currentNode)
    {

        if (currentNode == null)
        {
            return null;
        }

        if (currentNode.name == filename)
        {
            return currentNode;
        }

        if (FileNode.Compare(filename, currentNode.name) < 0)
        {
            return Search(filename, currentNode.left);
        }
        else
        {
            return Search(filename, currentNode.right);

        }
    }

    public FileNode Delete(string filename, FileNode currentNode)
    {

        if (currentNode == null)
        {
            return null;
        }

        int comparison = FileNode.Compare(filename, currentNode.name)
        if( comparison < 0)
        {
            currentNode.left = Delete(filename, currentNode.left);
            return currentNode;

        }
        else if (comparison > 0)
        {
            currentNode.right = Delete(filename, currentNode.right);
            return currentNode;
        }

        if (currentNode.IsLeaf())
        {
            return null;
        }

        if (currentNode.right != null && currentNode.left == null)
        {
            return currentNode.right;
        }

        if (currentNode.left != null && currentNode.right == null)
        {
            return currentNode.left;
        }

        FileNode minSucessor = getMinSuccesor(currentNode.right);
        currentNode.name = minSucessor.name;
        currentNode.isFolder = minSucessor.isFolder;
        currentNode.right = Delete(minSucessor.name, currentNode.right);

        return currentNode;

    }

    private FileNode getMinSuccesor(FileNode node)
    {
        FileNode curr = node;
        while (curr.left != null)
        {
            curr = curr.left;
        }
        return curr;
    }

    private List<string> BFS()
    {
        List<string> path = new List<string>();
        Queue<FileNode> q = new Queue<FileNode>();
        q.Enqueue(this.root);
        while (q.Count > 0)
        {
            FileNode node = q.Dequeue();
            path.Add(node.name);
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

    private void preOrderWalk(FileNode currNode, List<string> path)
    {
        if (currNode == null)
        {
            return;
        }
        path.Add(currNode.name);
        preOrderWalk(currNode.left, path);
        preOrderWalk(currNode.right, path);

    }

    private void postOrderWalk(FileNode currNode, List<string> path)
    {
        if (currNode == null)
        {
            return;
        }
        postOrderWalk(currNode.left, path);
        postOrderWalk(currNode.right, path);
        path.Add(currNode.name);

    }

    private void inOrderWalk(FileNode currNode, List<string> path)
    {
        if (currNode == null)
        {
            return;
        }
        inOrderWalk(currNode.left, path);
        path.Add(currNode.name);
        inOrderWalk(currNode.right, path);
    }
}