using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Workshop.Functions.Helpers;

namespace Workshop.Functions
{
    public class Blob
    {
        [FunctionName("Blob")]
        public async Task Run([BlobTrigger("workshopcontainer/{name}", Connection = "StorageConnection")] Stream myBlob, string name, ILogger log)
        {
            var blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "workshopcontainer");
            //await blobContainerClient.CreateIfNotExistsAsync();
            var blockBlobClient = blobContainerClient.GetBlockBlobClient(name);
            await blockBlobClient.DeleteAsync();

            
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
