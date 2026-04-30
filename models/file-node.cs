namespace TreeSearch.Models;

class FileNode
{
    public string name; // nombre del archivo
    private FileNode left;
    private FileNode right;

    public FileNode(string fileName)
    {
        name = fileName;
        left = null;
        right = null;
    }

    public FileNode Insert(FileNode currNode, FileNode newNode)
    {
        if (currNode == null)
        {
            return newNode;
        }

        int comparison = compare(newNode.name, currNode.name);

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



    private int compare(string nameA, string nameB)
    {
        return string.Compare(nameA, nameB);
    }


}