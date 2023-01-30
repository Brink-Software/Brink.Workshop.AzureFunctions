using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Workshop.Functions._04_Queues;

public static class Queues
{
    [FunctionName("CreateJob")]
    public static async Task Run(
        [BlobTrigger("workshopdb/workshopdata")] Stream myBlob,
        [Queue("workshop-queue")] ICollector<string> myQueue)
    {
        using StreamReader reader = new(myBlob, Encoding.UTF8);
        var content = await reader.ReadToEndAsync();

        myQueue.Add(content);
    }
}
