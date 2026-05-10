
using TreeSearch.Models;

namespace TreeSearch.controllers;

class DocumentController
{
    public Tree DocumentTree;
    public DocumentController()
    {
        DocumentTree = new Tree();
    }

    public void Create(string name, bool isFolder)
    {
        DocumentView view = new DocumentView();

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
        DocumentView view = new DocumentView();

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
        DocumentView view = new DocumentView();

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
        DocumentView view = new DocumentView();

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
        DocumentView view = new DocumentView();

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

}