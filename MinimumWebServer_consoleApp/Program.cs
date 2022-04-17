using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace MinimumWebServer_consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new WebHostBuilder().UseKestrel().Configure(paulApp
                    => paulApp.Run(paulHttpContext => paulHttpContext.Response.WriteAsync("<h1> Minimum Web Server</h1>")))
                .Build().Run();
        }
    }
}
