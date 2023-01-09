using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Workshop.Functions
{
    public static class HelloWorld
    {
        [FunctionName("HelloWorld")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Hello World has been triggered");

            // Extract keyword and assign "World" if empty, else the keyword gets assigned
            string keyword = req.Query["keyword"] == ((string)null) ? "World" : req.Query["keyword"];
            string response = $"Hello {keyword}!";

            // Fire response
            return new OkObjectResult(response);
        }
    }
}
