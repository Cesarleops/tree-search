public class DocumentView {

    public void show(List<string> data)
    {
        foreach (string node in data)
        {
            Console.WriteLine(node);
        }
    }

    public void alreadyExistsMessage(string filename){
        Console.WriteLine("El documento con nombre " + filename + "ya existe");
    }
}