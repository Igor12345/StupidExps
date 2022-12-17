// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var t = new SeveralTasks();

Console.WriteLine("Start");

await t.JustRun();
 // t.JustRun().SafeFireAndForget(e=>{
 //     Console.WriteLine($"Handler {e}");
 //     throw e;
 // });

await Task.Delay(20);
 Console.WriteLine("End");
 
 Console.ReadLine();