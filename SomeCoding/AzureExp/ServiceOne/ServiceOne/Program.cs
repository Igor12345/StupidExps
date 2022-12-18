// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ServiceOne.API;
using ServiceOne.SomethingUseful;

Console.WriteLine("Hello, Azure!");

using IHost host = Host.CreateDefaultBuilder(args).Build();
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Get values from the config given their key and their target type.
AzureConnectionsSettings settings = config.GetRequiredSection("AzureConnections").Get<AzureConnectionsSettings>();
StorageSettings storageSettings = config.GetRequiredSection("AzureConnections:Storage").Get<StorageSettings>();

MessageSender sender = new MessageSender(settings.Storage);

sender.SendPing($"Ping {DateTime.UtcNow:dd/MM/yyyy - HH:mm:ss}");

Console.WriteLine("Look in queue!");
sender.DequeueMessage();
sender.PeekMessage();
Console.ReadLine();