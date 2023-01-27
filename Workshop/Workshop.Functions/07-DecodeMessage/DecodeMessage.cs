using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Workshop.Functions._07_DecodeMessage
{
    public class DecodeMessage
    {
        [FunctionName("DecodeMessage")]
        public static async Task Run([QueueTrigger("workshop-queue", Connection = "StorageConnection")]string myQueueItem,
            [Blob("workshopdb/workshopsecretfile", FileAccess.Write)] Stream myBlob)
        {
            await using StreamWriter writer = new(myBlob, Encoding.UTF8);
            var decodedMassage = Encoding.UTF8.GetString(Convert.FromBase64String(myQueueItem));
            await writer.WriteAsync(decodedMassage);
        }
    }
}
