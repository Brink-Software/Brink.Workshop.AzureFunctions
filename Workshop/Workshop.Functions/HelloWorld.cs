using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Workshop.Functions
{
    public class HelloWorld
    {
        private readonly ILogger _logger;

        public HelloWorld(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HelloWorld>();
        }

        [Function("HelloWorld")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("Hello World received a request!");

            // Parse Query parameter to string Collection
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            // Checks if the keyword is passed into the query parameters, if not it returns World else it returns the keyword
            var keyword = queryDictionary["keyword"] == null ? "World" : queryDictionary["keyword"];

            // Build response
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString($"Hello {keyword}");

            // Send response
            return response;
        }
    }
}
