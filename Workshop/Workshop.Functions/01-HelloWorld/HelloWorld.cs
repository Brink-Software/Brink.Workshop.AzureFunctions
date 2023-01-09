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
        [FunctionName("hello-world")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Hello World has been triggered");
            // Extract name and assign "World" if empty, else the name gets assigned
            string name = string.IsNullOrEmpty(req.Query["name"]) ? "World" : req.Query["name"];
            string response = $"Hello, {name}!";
            // Return response
            return new OkObjectResult(response);
        }
    }
}
