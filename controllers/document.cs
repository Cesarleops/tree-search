
using TreeSearch.Models;

namespace TreeSearch.controllers;

class DocumentController
{
    public Tree DocumentTree;
    public DocumentController()
    {
        DocumentTree = new Tree();
    }

    public void Create(string name)
    {
        FileNode newNode = new FileNode(name);
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
        DocumentTree.Update(currentName, newName);
    }

    public void Delete(string name)
    {
        DocumentTree.Delete(name, DocumentTree.root);
    }




}