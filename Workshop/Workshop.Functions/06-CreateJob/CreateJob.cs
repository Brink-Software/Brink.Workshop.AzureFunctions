using System.IO;
using System.Text;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._06_AutoBackup
{
    public class CreateJob
    {
        [FunctionName("CreateJob")]
        public void Run(
            [BlobTrigger("workshopdb/workshopdata", Connection = "StorageConnection")] Stream myBlob,
            [Queue("workshop-queue", Connection = "StorageConnection")] ICollector<string> myQueue)
        {
            using StreamReader reader = new(myBlob, Encoding.UTF8);
            var content = reader.ReadToEnd();

            myQueue.Add(content);
        }
    }
}
