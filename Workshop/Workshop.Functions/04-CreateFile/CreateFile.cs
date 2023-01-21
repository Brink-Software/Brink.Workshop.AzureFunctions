using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System.Text;
using Workshop.Functions.Helpers;

namespace Workshop.Functions._04_CreateFile
{
    public static class CreateFile
    {
        [FunctionName("create-file")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string containerName = req.Query["containerName"];
            string fileName = req.Query["fileName"];
            string message = req.Query["message"];
            var blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", containerName);
            await blobContainerClient.CreateIfNotExistsAsync();
            var blockBlobClient = blobContainerClient.GetBlockBlobClient(fileName);

            await BlobStorage.WriteMessage(blockBlobClient, message);
            var result = await BlobStorage.ReadFileContent(blockBlobClient);

            return new OkObjectResult(result);
        }

       
    }

    
}
