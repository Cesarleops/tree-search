public class DocumentView
{

    public void show(List<string> data)
    {
        foreach (string node in data)
        {
            Console.WriteLine(node);
        }
    }

    public void alreadyExistsMessage(string filename)
    {
        Console.WriteLine("El documento con nombre " + filename + "ya existe");
    }

    public void showEmptyNameMessage()
    {
        Console.WriteLine("El nombre no puede estar vacío.");
    }

    public void showComparisons(string filename, int comparisons, bool found)
    {
        if (found)
        {
            Console.WriteLine($"Se encontró '{filename}' después de {comparisons} comparaciones.");
        }
        else
        {
            Console.WriteLine($"No se encontró '{filename}' después de {comparisons} comparaciones.");
        }
    }

    public void showInsertComparisons(string filename, int comparisons)
    {
        Console.WriteLine($"Se añadió '{filename}' después de {comparisons} comparaciones.");
    }

    public void showDeletionType(string name, string deletionType)
    {
        Console.WriteLine($"Se eliminó '{name}' que era un nodo {deletionType}.");
    }
}