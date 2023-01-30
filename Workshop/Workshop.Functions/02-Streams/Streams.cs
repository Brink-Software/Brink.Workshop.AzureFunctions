using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._02_Streams;

public static class Streams
{
    [FunctionName("Streams")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        var reader = new StreamReader(req.Body);
        var body = await reader.ReadToEndAsync();

        var year = int.Parse(body);

        bool result;

        if (year % 400 == 0) result = true;
        else if (year % 100 == 0) result = false;
        else if (year % 4 == 0) result = true;
        else result = false;

        return new OkObjectResult(result);

        // Extra challenge: return answer in a stream

        // var stream = new MemoryStream();
        // var writer = new StreamWriter(stream);
            
        // await writer.WriteAsync(result ? "true" : "false");
        // await writer.FlushAsync();
        // stream.Position = 0;

        // return new OkObjectResult(stream);
    }
}
