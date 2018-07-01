using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CodeKatas.LightWeightHttpService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables().Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureLogging(arg => arg.AddConsole(config.GetSection("Logging")))
                .ConfigureServices(s => s.AddRouting())
                .Configure(app =>
                {
                    app.UseRouter(arg => 
                    {
                        arg.MapGet("test", async (context) =>
                        {
                            var testResponse = Encoding.ASCII.GetBytes("No MVC test");
                            await context.Response.Body.WriteAsync(testResponse, 0, testResponse.Length);
                        });
                    });
                })
                .Build();

            host.Run();
        }
    }
}
