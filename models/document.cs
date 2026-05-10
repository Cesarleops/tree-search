public class CompanyDocument {

    public string name; 
    public bool isFolder; 
    
    public CompanyDocument(string filename, bool isFolder) {
        name = filename;
        this.isFolder = isFolder;
    }
}