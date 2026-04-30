namespace TreeSearch.Models;


class Tree {
    public FileNode root;

    
    private void PreOrderWalk(FileNode currNode, List<string> path)
    {
        if (currNode == null)
        {
            return;
        }
        path.Add(currNode.name);
        PreOrderWalk(currNode.left, path);
        PreOrderWalk(currNode.right, path);

    }

    private void PostOrderWalk(FileNode currNode, List<string> path)
    {
        if(currNode == null){
            return;
        }
        PostOrderWalk(currNode.left, path);
        path.Add(currNode.name);
        PostOrderWalk(currNode.right, path);
    }

    private void InOrderWalk(FileNode currNode, List<string> path)
    {
        if(currNode == null){
            return;
        }
        InOrderWalk(currNode.left, path);
        InOrderWalk(currNode.right, path);
        path.Add(currNode.name);
    }
}