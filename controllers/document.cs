
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
        DocumentTree.Insert(DocumentTree.root, newNode);
    }

    public void Read(string order)
    {
        List<string> path = DocumentTree.Walk(order);
        DocumentView view = new DocumentView();
        view.show(path);
    }

    public void Update(string currentName, string newName)
    {
        DocumentView view = new DocumentView();
        
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
        DocumentTree.root = DocumentTree.Delete(name, DocumentTree.root, out string deletionType);
        view.showDeletionType(name, deletionType);
    }

    public void Search(string filename)
    {
        DocumentView view = new DocumentView();
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