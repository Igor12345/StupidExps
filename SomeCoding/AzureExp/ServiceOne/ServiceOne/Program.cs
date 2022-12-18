// See https://aka.ms/new-console-template for more information

using ServiceOne.SomethingUsefull;

Console.WriteLine("Hello, Azure!");

MessageSender sender = new MessageSender();

sender.SendPing("Ping 1");

Console.WriteLine("Look in queue!");

Console.ReadLine();