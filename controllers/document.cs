
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
        DocumentTree.Delete(name, DocumentTree.root);
    }



    private bool isUniqueName(string newName)
    {
        DocumentNode node = DocumentTree.Search(newName, DocumentTree.root);
        if (node != null) return true;
        return false;
    }

}