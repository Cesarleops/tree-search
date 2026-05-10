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

    public void showNotFoundMessage(string name)
    {
        Console.WriteLine($"No se encontró '{name}' para eliminar.");
    }

    public void showInsertRoot(string name)
    {
        Console.WriteLine($"Se insertó '{name}' como raíz del árbol.");
    }

    public void showHeight(int height)
    {
        Console.WriteLine($"Altura del árbol: {height}");
    }

    public void showTestDataAlreadyLoaded()
    {
        Console.WriteLine("Los datos de prueba ya fueron cargados.");
    }

    public void showTestDataLoaded()
    {
        Console.WriteLine("Datos de prueba cargados:");
    }

    public void showInvalidOption()
    {
        Console.WriteLine("Opción no válida.");
    }

    public void showGoodbye()
    {
        Console.WriteLine("Gracias");
    }

    public string showMenu()
    {
        Console.WriteLine("\nSistema de documentos de Docutrack");
        Console.WriteLine("Por favor marca una opción");
        Console.WriteLine("1. Insertar documento");
        Console.WriteLine("2. Buscar documento");
        Console.WriteLine("3. Actualizar documento");
        Console.WriteLine("4. Eliminar documento");
        Console.WriteLine("5. Ver arbol");
        Console.WriteLine("6. Ver recorridos");
        Console.WriteLine("7. Cargar datos de prueba");
        Console.WriteLine("8. Mostrar altura del árbol");
        Console.WriteLine("0. Salir");
        Console.Write("Opción: ");
        return Console.ReadLine()?.Trim() ?? "";
    }

    public string readInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim() ?? "";
    }

    public bool readIsFolder()
    {
        Console.Write("¿Es carpeta? (si/no): ");
        // por defecto los documentos nuevos no serán carpetas
        return (Console.ReadLine()?.Trim().ToLower() ?? "no") == "si";
    }

    public void showWalkHeader(string title)
    {
        Console.WriteLine($"\n--- {title} ---");
    }
}