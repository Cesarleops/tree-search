using TreeSearch.Models;

namespace TreeSearch.controllers;

class DocumentController
{
    public Tree DocumentTree;
    private DocumentView view;
    private bool testDataLoaded;

    public DocumentController()
    {
        DocumentTree = new Tree();
        view = new DocumentView();
        testDataLoaded = false;
    }

    public void StartMenu()
    {
        while (true)
        {
            string input = view.showMenu();

            switch (input)
            {
                case "1":
                    string name = view.readInput("Nombre del documento: ");
                    bool isFolder = view.readIsFolder();
                    Create(name, isFolder);
                    break;

                case "2":
                    string searchName = view.readInput("Nombre del documento: ");
                    Search(searchName);
                    break;

                case "3":
                    string oldName = view.readInput("Nombre actual: ");
                    string newName = view.readInput("Nombre nuevo: ");
                    Update(oldName, newName);
                    break;

                case "4":
                    string deleteName = view.readInput("Nombre del documento a eliminar: ");
                    Delete(deleteName);
                    break;

                case "5":
                    Read("ascii");
                    break;

                case "6":
                    view.showWalkHeader("Pre orden");
                    Read("PreOrder");
                    view.showWalkHeader("En orden");
                    Read("InOrder");
                    view.showWalkHeader("Post orden");
                    Read("PostOrder");
                    view.showWalkHeader("Por nivel");
                    Read("BFS");
                    break;

                case "7":
                    if (testDataLoaded)
                    {
                        view.showTestDataAlreadyLoaded();
                        break;
                    }
                    LoadTestData();
                    testDataLoaded = true;
                    view.showTestDataLoaded();
                    Read("ascii");
                    break;

                case "8":
                    view.showHeight(DocumentTree.Height(DocumentTree.root));
                    break;

                case "0":
                    view.showGoodbye();
                    return;

                default:
                    view.showInvalidOption();
                    break;
            }
        }
    }

    public void Create(string name, bool isFolder)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            view.showEmptyNameMessage();
            return;
        }
        
        if (!isUniqueName(name))
        {
            view.alreadyExistsMessage(name);
            return;
        }

        DocumentNode newNode = new DocumentNode(name, isFolder);

        if (DocumentTree.root == null)
        {
            DocumentTree.root = newNode;
            return;
        }
        DocumentTree.Insert(DocumentTree.root, newNode, out int comparisons);
        view.showInsertComparisons(name, comparisons);
    }

    public void Read(string order)
    {
        if (order == "ascii")
        {
            view.showTree(DocumentTree.root);
            return;
        }

        List<string> path = DocumentTree.Walk(order);
        view.show(path);
    }

    public void Update(string currentName, string newName)
    {
        if (string.IsNullOrWhiteSpace(currentName) || string.IsNullOrWhiteSpace(newName))
        {
            view.showEmptyNameMessage();
            return;
        }
        
        if (!isUniqueName(newName))
        {
            view.alreadyExistsMessage(newName);
            return;
        }

        DocumentTree.Update(currentName, newName);
    }

    public void Delete(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            view.showEmptyNameMessage();
            return;
        }

        DocumentTree.root = DocumentTree.Delete(name, DocumentTree.root, out string deletionType);
        view.showDeletionType(name, deletionType);
    }

    public void Search(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            view.showEmptyNameMessage();
            return;
        }

        DocumentNode result = DocumentTree.Search(filename, DocumentTree.root, out int comparisons);
        if (result != null)
        {
            view.showComparisons(filename, comparisons, true);
        }
        else
        {
            view.showComparisons(filename, comparisons, false);
        }
    }

    private bool isUniqueName(string newName)
    {
        DocumentNode node = DocumentTree.Search(newName, DocumentTree.root, out _);
        if (node != null) return false;
        return true;
    }

    // como indica el taller, 14 nodos de pruebas
    private void LoadTestData()
    {
        string[] folders = { "Proyectos", "Finanzas", "Recursos", "Marketing", "Ventas", "Legal" };
        string[] files = { "Informe.docx", "Balance.xlsx", "Contrato.pdf", "Logo.png", "Notas.txt", "Presupuesto.xlsx", "Plan.docx", "Foto.jpg" };

        foreach (string f in folders)
        {
            Create(f, true);
        }
        foreach (string f in files)
        {
            Create(f, false);
        }
    }
}