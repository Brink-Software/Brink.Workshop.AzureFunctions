using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._05_ReadMessage
{
    public static class ReadData
    {
        [FunctionName("read-data")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Blob("workshopdb/workshopdata", FileAccess.Read)] Stream myBlob,
            ILogger log)
        {
            using StreamReader reader = new(myBlob, Encoding.UTF8);
            var content = await reader.ReadToEndAsync();

            return new OkObjectResult(content);
        }
    }
}
