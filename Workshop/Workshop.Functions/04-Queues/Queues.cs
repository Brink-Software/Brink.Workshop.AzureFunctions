using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;

namespace Workshop.Functions._04_Queues
{
    public class Queues
    {
        [FunctionName("CreateJob")]
        public void Run(
            [BlobTrigger("workshopdb/workshopdata")] Stream myBlob,
            [Queue("workshop-queue")] ICollector<string> myQueue)
        {
            using StreamReader reader = new(myBlob, Encoding.UTF8);
            var content = reader.ReadToEnd();

            myQueue.Add(content);
        }
    }
}
