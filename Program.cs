using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "endpoint-here";
        string queueName = "dlq-name-here"; // the DLQ name directly

        string dlqPath = queueName + "/$DeadLetterQueue";

        await using var client = new ServiceBusClient(connectionString);

        var receiver = client.CreateReceiver(
            queueName: dlqPath,
            options: new ServiceBusReceiverOptions
            {
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
            });

        Console.WriteLine($"Purging DLQ for queue: {queueName}");

        int totalDeleted = 0;

        while (true)
        {
            var messages = await receiver.ReceiveMessagesAsync(maxMessages: 100, maxWaitTime: TimeSpan.FromSeconds(5));
            if (messages.Count == 0) break;

            totalDeleted += messages.Count;
            Console.WriteLine($"Deleted {messages.Count} messages...");
        }

        Console.WriteLine($"Done. Total messages purged from DLQ: {totalDeleted}");
    }
}
