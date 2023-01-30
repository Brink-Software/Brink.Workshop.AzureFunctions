using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;

namespace Workshop.Functions._06_Timer
{
    public class Timer
    {

        [FunctionName("timer")]
        public async Task Run([TimerTrigger("0/30 * * * * *")] TimerInfo myTimer,
            [Blob("workshopdb/workshopsecretfile")] BlobClient blobClient)
        {
            if (blobClient.Exists())
            {
                var properties = await blobClient.GetPropertiesAsync();
                if (properties.Value is not null)
                {
                    var fileDate = properties.Value.LastModified;
                    if ((DateTime.Now - fileDate).TotalSeconds > 30)
                    {
                        await blobClient.DeleteAsync();
                    }
                }
            }
        }
    }
}
