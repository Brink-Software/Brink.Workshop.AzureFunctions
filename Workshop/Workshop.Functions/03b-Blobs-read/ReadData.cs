using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._03b_Blobs_read
{
    public static class ReadData
    {
        [FunctionName("read-message")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            //[Blob("workshopdb/workshopdata", FileAccess.Read)] Stream myBlob,
            [Blob("workshopdb/workshopsecretfile", FileAccess.Read)] Stream myBlob,
            ILogger log)
        {
            using StreamReader reader = new(myBlob, Encoding.UTF8);
            var content = await reader.ReadToEndAsync();

            return new OkObjectResult(content);
        }


    }
}
