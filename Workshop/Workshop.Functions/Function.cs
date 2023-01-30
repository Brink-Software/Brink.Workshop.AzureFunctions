using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions
{
    public class Function
    {
        [FunctionName("Function")]
        public void Run([ServiceBusTrigger("myqueue", Connection = "")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
