using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._08_ReadSecret
{
    public class ReadSecret
    {

        [FunctionName("ReadSecret")]
        public async Task Run([TimerTrigger("0/5 * * * * *")] TimerInfo myTimer,
            [Blob("workshopdb/workshopsecretfile")] BlobClient blobClient)
        {
            var fileDate = (await blobClient.GetPropertiesAsync()).Value.LastModified;
            if ((DateTime.Now - fileDate).TotalMinutes > 1)
            {
                await blobClient.DeleteAsync();
            }
        }
    }
}
