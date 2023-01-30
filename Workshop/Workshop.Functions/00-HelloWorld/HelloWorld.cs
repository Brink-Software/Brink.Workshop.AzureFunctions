// Using statements are used to import code from other namespaces.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

// Namespaces are used to organize code, similar to how you can organize files into folder on your file system.
namespace Workshop.Functions._00_HelloWorld;

// Classes encapsulate related data and functionality. They function as blueprints from which you can instantiate multiple objects of the same class.
// In the case of Azure Functions, each function is declared using a class with a Run method (see below).
public static class HelloWorld
{
    // This attribute FunctionName registers the Run method below as an Azure Function that will be available on the path "/hello-world".
    // Check this link for more information on the required attributes in an Azure Function:
    // https://learn.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library?tabs=v4%2Ccmd#methods-recognized-as-functions
    [FunctionName("hello-world")]
    // This Run method contains the logic that will be executed when the Azure Function is called.
    public static async Task<IActionResult> Run(
        // The Run method takes two parameters. The "request" parameter contains the HTTP request.
        // An HttpTrigger attribute is added to the "request" parameter to indicate this Azure Function is triggered using an HTTP request.
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest request,
        // The Run method also receives a "log" parameter that can be used to write output to the console. This can be useful when debugging your function.
        ILogger log)
    {
        // This is an example of how to log an informational message.
        log.LogInformation("Hello World was triggered.");

        // Create variables using the "var" keyword.
        var name = "world";

        // The HTTP request might contain query parameters. This line checks if there is a query parameter called "name". If there is, the body of the
        // if-statement overwrites the "name" variable with the value of the query parameter.
        if (request.Query.ContainsKey("name"))
        {
            name = request.Query["name"];
        }

        // Here we use the $-symbol in combination with a string to interpolate the value of the "name" variable to create a nicely formatted response.
        var response = $"Hello, {name}!";

        // Use the "new" keyword to instantiate (create) a new object based on a class. This line creates a new object of the OkObjectResult class.
        // The OkObjectResult class creates a nice HTTP response with the "200 OK" HTTP status code.
        var result = new OkObjectResult(response);

        // Return a value from a method using the "return" keyword.
        return result;
    }
}
