using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace Workshop.Functions._03_Streams;

public static class Streams
{
    [FunctionName("Streams")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Streams has been triggered");

        var reader = new StreamReader(req.Body);
        var body = reader.ReadToEnd();

        string firstReadResult = body.Split('-')[0];
        string secondReadResult = body.Split('-')[1];

        Stream stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(firstReadResult + secondReadResult);
        writer.Flush();
        stream.Position = 0;

        return new OkObjectResult(stream);
    }
}
