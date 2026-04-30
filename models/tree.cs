namespace TreeSearch.Models;


class Tree {
    public FileNode root;

    public List<string> Walk(string order)
    {
        List<string> path = new List<string>();

        switch (order)
        {
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
        if(currNode == null){
            return;
        }
        postOrderWalk(currNode.left, path);
        path.Add(currNode.name);
        postOrderWalk(currNode.right, path);
    }

    private void inOrderWalk(FileNode currNode, List<string> path)
    {
        if(currNode == null){
            return;
        }
        inOrderWalk(currNode.left, path);
        inOrderWalk(currNode.right, path);
        path.Add(currNode.name);
    }
}