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



    public static int Compare(string nameA, string nameB)
    {
        return string.Compare(nameA, nameB);
    }


}