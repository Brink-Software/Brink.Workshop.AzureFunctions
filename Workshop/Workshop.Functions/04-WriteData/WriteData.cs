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
using System.Reflection.Metadata;

namespace Workshop.Functions._04_CreateFile
{
    public static class WriteData
    {
        [FunctionName("write-data")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Blob("workshopdb/workshopdata", FileAccess.Write)] Stream myBlob,
            ILogger log)
        {
            string message = req.Query["message"];

            await using StreamWriter writer = new(myBlob, Encoding.UTF8);
            writer.Write(message);

            return new OkObjectResult("Ok");
        }
    }


}
