using TreeSearch.Models;

public class DocumentView
{

    public void show(List<string> data)
    {
        foreach (string node in data)
        {
            Console.WriteLine(node);
        }
    }

    public void showTree(DocumentNode root)
    {
        if (root == null)
        {
            Console.WriteLine("No hay ningún documento.");
            return;
        }
        Console.WriteLine(root.value.name);
        printNode(root.left, "", true);
        printNode(root.right, "", false);
    }

    private void printNode(DocumentNode node, string prefix, bool isLeft)
    {
        if (node == null) return;

        Console.WriteLine(prefix + (isLeft ? "├── " : "└── ") + node.value.name);

        string newPrefix = prefix + (isLeft ? "│   " : "    ");
        printNode(node.left, newPrefix, true);
        printNode(node.right, newPrefix, false);
    }

    public void alreadyExistsMessage(string filename)
    {
        Console.WriteLine("El documento con nombre " + filename + " ya existe");
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
        Console.WriteLine($"Se eliminó '{name}' que era un nodo tipo: {deletionType}.");
    }

    public void showHeight(int height)
    {
        Console.WriteLine($"Altura del árbol: {height}");
    }
}