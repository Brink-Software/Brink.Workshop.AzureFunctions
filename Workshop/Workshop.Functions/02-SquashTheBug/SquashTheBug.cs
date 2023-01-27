using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions._02_SquashTheBug;

public static class SquashTheBug
{
    [FunctionName("squash-the-bug")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Squash the Bug was triggered.");

        string role = req.Query["role"];

        var response = $"Hello, {role}!";
        return new OkObjectResult(response);

        if (role == "owner")
        {
            var specialResponse = "Hello, admin!";
            return new OkObjectResult(response);
        }
    }
}
