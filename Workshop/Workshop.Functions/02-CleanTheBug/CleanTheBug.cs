using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Workshop.Functions._2_CleanTheBug
{
    public static class CleanTheBug
    {
        /* 
        Binnen Brink zijn er een aantal applicaties (IBIS Calculeren voor bouw, IBIS Calculeren voor infra), 
        hiermee kunnen klanten kosten van projecten kunnen berekenen.
        Om gebruik te maken van deze applicatie heeft een klant (een bedrijf) licenties nodig.
        Deze licenties worden binnen het bedrijf beheerd door de eigenaar (admin) van het bedrijf,
        maar door een fout in de productiecode kan de eigenaar niet opgespoord worden in het bedrijf, 
        waardoor de licenties niet gekoppeld kunnen worden aan werknemers door de eigenaar (admin).

        Kan jij de fout in de code opsporen en oplossen?
         */
        [FunctionName("clean-the-bug")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Clean The Bug has been triggered");
            string role = req.Query["role"];

            string response = $"Hello, {role}!";
            return new OkObjectResult(response);

            if (role == "eigenaar")
            {
                string specialResponse = $"Hello, Admin!";
                return new OkObjectResult(response);
            }
        }
    }
}
