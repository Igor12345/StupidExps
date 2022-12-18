using Azure.Identity;
using Azure.Storage.Queues;

namespace ServiceOne.API;

public class QueueClientFactory
{
    public static QueueClient CreateClientWithDefaultAzureCredential(StorageSettings storage,
        string queueName = "queue-name")
    {
        QueueClient client = new QueueClient(storage.ConnectionString,
            $"{queueName}", new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64 });
        return client;
    }
}