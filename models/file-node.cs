namespace TreeSearch.Models;

public class FileNode
{
    public string name; // nombre del archivo
    public FileNode left;
    public FileNode right;
    public bool isFolder; 

    public FileNode(string fileName)
    {
        name = fileName;
        left = null;
        right = null;
    }



    public static int Compare(string nameA, string nameB)
    {
        return string.Compare(nameA, nameB);
    }


    public bool IsLeaf(){
        return this.left == null && this.right == null;
    }
}