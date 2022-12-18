using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using ServiceOne.API;

namespace ServiceOne.SomethingUsefull;

public class MessageSender
{
    private QueueClient? _queueClient;

    public bool SendPing(string text)
    {
        _queueClient ??= CreateClient();
        IDictionary<string,string> metadata = new Dictionary<string, string>();
        if (_queueClient.Exists())
        {
            Console.WriteLine($"Before CreateIfNotExists. Queue exists: '{_queueClient.Name}'.");
            
        }
        else
        {
            Console.WriteLine($"Before CreateIfNotExists. Queue does not exist.");
        }
        
        _queueClient.CreateIfNotExists();
        if (_queueClient.Exists())
        {
            Console.WriteLine($"After CreateIfNotExists. Queue created: '{_queueClient.Name}', sending the message.");
            
        }
        else
        {
            Console.WriteLine($"After CreateIfNotExists. Make sure the Azurite storage emulator running and try again.");
            return false;
        }
        _queueClient.SendMessage(text);
        return true;
    }
    public void PeekMessage(string queueName)
    {
        _queueClient ??= CreateClient();

        if (_queueClient.Exists())
        { 
            // Peek at the next message
            PeekedMessage[] peekedMessage = _queueClient.PeekMessages();

            // Display the message
            Console.WriteLine($"Peeked message: '{peekedMessage[0].Body}'");
        }
    }

    public void UpdateMessage(string queueName)
    {
        _queueClient ??= CreateClient();

        if (_queueClient.Exists())
        {
            // Get the message from the queue
            QueueMessage[] message = _queueClient.ReceiveMessages();

            // Update the message contents
            _queueClient.UpdateMessage(message[0].MessageId,
                message[0].PopReceipt,
                "Updated contents",
                TimeSpan.FromSeconds(60.0) // Make it invisible for another 60 seconds
            );
        }
    }
    
    public void DequeueMessage(string queueName)
    {
        _queueClient ??= CreateClient();

        if (_queueClient.Exists())
        {
            // Get the next message
            QueueMessage[] retrievedMessage = _queueClient.ReceiveMessages();

            // Process (i.e. print) the message in less than 30 seconds
            Console.WriteLine($"Dequeued message: '{retrievedMessage[0].Body}'");

            // Delete the message
            _queueClient.DeleteMessage(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
        }
    }

    private QueueClient CreateClient()
    {
        _queueClient = QueueClientFactory.CreateClientWithDefaultAzureCredential("cool-queue");
        return _queueClient;
    }
}