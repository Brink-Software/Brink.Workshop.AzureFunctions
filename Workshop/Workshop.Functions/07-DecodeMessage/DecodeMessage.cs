using Microsoft.Azure.WebJobs;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Functions._08_Queue
{
    public class DecodeMessage
    {
        [FunctionName("DecodeMessage")]
        public static async Task Run([QueueTrigger("workshop-queue", Connection = "StorageConnection")]string myQueueItem,
            [Blob("workshopdb/workshopsecretfile", FileAccess.Write)] Stream myBlob)
        {
            await using StreamWriter writer = new(myBlob, Encoding.UTF8);
            await writer.WriteAsync(myQueueItem);
        }
    }
}
