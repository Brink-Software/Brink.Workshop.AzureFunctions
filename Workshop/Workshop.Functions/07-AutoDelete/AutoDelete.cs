using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions
{
      //https://arminreiter.com/2017/02/azure-functions-time-trigger-cron-cheat-sheet/
    public class AutoDelete
    {
        [FunctionName("Timer")]
        public async Task Run([TimerTrigger("* 0 * * * *")] TimerInfo myTimer, ILogger log)
        {
            var blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "workshopdb");
            var appendBlobClient = blobContainerClient.GetAppendBlobClient("workshopdata");
            await appendBlobClient.DeleteIfExistsAsync();
        }
    }
}
