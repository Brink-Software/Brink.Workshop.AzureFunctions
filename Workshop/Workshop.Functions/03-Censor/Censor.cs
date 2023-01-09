using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Workshop.Functions._03_Censor
{
    public static class Censor
    {
        /* 
        Het design van de applicatie wordt ontworpen door speciale UX-designers.
        Deze designs worden vervolgens doorgespeeld naar de ontwikkelaars die deze implementeren.
        De ontwikkelaars hebben het verzoek van de UX-designers gekregen om de creditcardgegevens van klanten beter te censureren.
        Dit is tevens ook een beveiligingsrisico.

        Kan jij het verzoek verwerken?
         */
        [FunctionName("Censor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Censor has been triggered");
            string keyword = req.Query["keyword"];

            string response = "";
            return new OkObjectResult(response);
        }
    }
}
