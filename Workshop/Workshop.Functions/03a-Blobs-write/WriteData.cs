using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Functions._03a_Blobs_write;

public static class WriteData
{
    [FunctionName("write-message")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        [Blob("workshopdb/workshopdata", FileAccess.Write)] Stream myBlob)
    {
        string message = req.Query["message"];

        await using StreamWriter writer = new(myBlob, Encoding.UTF8);
        await writer.WriteAsync(message);

        return new OkObjectResult("Ok");
    }
}
