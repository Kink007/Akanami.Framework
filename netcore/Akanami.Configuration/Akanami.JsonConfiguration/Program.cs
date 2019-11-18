using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Akanami.JsonConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            HostBuilder hostBuilder = new HostBuilder();
            hostBuilder.ConfigureAppConfiguration((configure) =>
            {
                configure.AddJsonFile("appSettings.json");
            });
            hostBuilder.ConfigureLogging((configure) =>
            {
                configure.AddConsole();
            });
            hostBuilder.ConfigureServices((context, services) =>
            {
                //services.AddOptions<HostOptions>("HostOption").Bind(context.Configuration);
                services.Configure<HostOptions>(context.Configuration.GetSection("HostOption"));
                
                services.AddSingleton<IHostedService, HostService>();
            });

            await hostBuilder.RunConsoleAsync();
        }
    }
}
