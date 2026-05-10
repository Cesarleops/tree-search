
using TreeSearch.controllers;

Console.WriteLine("Bienvenido al sistema de documentos de DocuTrack S.A.");

DocumentController controller = new DocumentController();

controller.Create("C", false);
controller.Create("B", false);
controller.Create("A", false);
controller.Create("D", false);
controller.Create("E", false);
Console.WriteLine("-------- NUESTRO ARCHIVO --------------- ");
controller.Read("ascii");

// controller.Read("BFS");


controller.Delete("C");

Console.WriteLine("-------- NUESTRO ARCHIVO POST ELIMINACIÓN --------------- ");
// controller.Read("InOrder");

controller.Update("A", "Z");

Console.WriteLine("-------- NUESTRO ARCHIVO POST ACTU --------------- ");

