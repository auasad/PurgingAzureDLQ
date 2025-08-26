## How to Purge Dead Letter Queue (DLQ) Messages in Azure Service Bus Using .NET

When working with Azure Service Bus, each queue and topic subscription automatically comes with a Dead Letter Queue (DLQ). This DLQ stores messages that cannot be delivered or processed for example, due to exceeding max delivery count or schema validation errors.

Over time, the DLQ can grow large and may need to be purged. Unfortunately, Azure doesn’t provide a direct “purge” button in the portal. But with a few lines of .NET code, you can easily remove all messages.

# Clone the repository 
`git clone https://github.com/auasad/PurgingAzureDLQ.git`

# Install the NuGet Package
`dotnet add package Azure.Messaging.ServiceBus`

# Provide Queue endpoint and queue name
`string connectionString = "endpoint-here";`
`string queueName = "dlq-name-here";`

# Run the Application
`dotnet run`

