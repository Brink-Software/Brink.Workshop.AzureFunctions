using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._08_ReadSecret
{
    public class ReadSecret
    {

        [FunctionName("ReadSecret")]
        public async Task Run([TimerTrigger("0/5 * * * * *")] TimerInfo myTimer,
            ILogger log)
        {
            const string containerName = "workshopdb";
            const string fileName = "workshopsecretfile";
            var blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", containerName);
            await blobContainerClient.CreateIfNotExistsAsync();
            var blobClient = blobContainerClient.GetAppendBlobClient(fileName);
            await blobClient.CreateIfNotExistsAsync();
            var properties = await blobClient.GetPropertiesAsync();
            var fileDate = properties.Value.LastModified;
            if ((DateTime.Now - fileDate).TotalMinutes > 1) 
            {
                await blobClient.DeleteAsync();
            }
        }
    }
}
