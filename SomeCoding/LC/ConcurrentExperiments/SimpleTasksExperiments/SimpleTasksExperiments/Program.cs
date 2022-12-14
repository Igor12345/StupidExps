// See https://aka.ms/new-console-template for more information

using SimpleTasksExperiments;

Console.WriteLine("Hello, World!");

object boxed = 42;
int? nv = boxed as int?;
int? nv2 = (int?) boxed;
int v = (int) boxed;


Manager manager = new Manager();
manager.Execute();
Console.WriteLine("End");