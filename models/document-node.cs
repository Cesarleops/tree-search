namespace TreeSearch.Models;

public class DocumentNode
{
    public DocumentNode left;
    public DocumentNode right;
    public CompanyDocument value;

    public DocumentNode(string fileName, bool isFolder)
    {
        value = new CompanyDocument(fileName, isFolder);
        left = null;
        right = null;
    }



    public static int Compare(string nameA, string nameB)
    {
        return string.Compare(nameA, nameB, StringComparison.OrdinalIgnoreCase);
    }


    public bool IsLeaf(){
        return this.left == null && this.right == null;
    }
}