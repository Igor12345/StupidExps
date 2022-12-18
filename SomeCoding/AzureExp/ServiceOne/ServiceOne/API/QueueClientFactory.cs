using Azure.Identity;
using Azure.Storage.Queues;

namespace ServiceOne.API;

public class QueueClientFactory
{
    private static string _connectionString =
        "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

    public static QueueClient CreateClientWithDefaultAzureCredential(string queueName = "queue-name")
    {
        QueueClient client = new QueueClient(_connectionString,
            $"{queueName}", new QueueClientOptions() { MessageEncoding = QueueMessageEncoding.Base64 });
        return client;
    }
}