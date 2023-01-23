using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions
{
    public class Queue
    {
        [FunctionName("Queue")]
        public void Run([QueueTrigger("workshop-queue", Connection = "StorageConnection")]string myQueueItem,
            [Queue("workshop-queue2", Connection = "StorageConnection")] ICollector<string> output, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            output.Add(myQueueItem);
        }
    }
}
