using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._04_WriteData
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
