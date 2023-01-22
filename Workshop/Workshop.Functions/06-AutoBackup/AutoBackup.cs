using System;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions
{
    public class BlobTrigger
    {
        [FunctionName("BlobTrigger")]
        public void Run(
            [BlobTrigger("workshopdb/{name}", Connection = "StorageConnection")] Stream myBlob,
            [Blob("backupdb/{name}", FileAccess.Write)] Stream backup,
            string name, ILogger log)
        {
            if (name == "backup") return;

            using StreamReader reader = new(myBlob, Encoding.UTF8);
            var content = reader.ReadToEnd();

            using StreamWriter writer = new(backup, Encoding.UTF8);
            writer.Write(content);
        }
    }
}
