
using TreeSearch.controllers;

Console.WriteLine("Bienvenido al sistema de documentos de DocuTrack S.A.");

DocumentController controller = new DocumentController();

controller.Create("C");
controller.Create("B");
controller.Create("A");
controller.Create("D");
controller.Create("E");
Console.WriteLine("-------- NUESTRO ARCHIVO --------------- ");

controller.Read("BFS");


controller.Delete("C");

Console.WriteLine("-------- NUESTRO ARCHIVO POST ELIMINACIÓN --------------- ");
controller.Read("InOrder");