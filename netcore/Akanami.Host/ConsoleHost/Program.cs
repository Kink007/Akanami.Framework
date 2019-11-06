using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();

            //Console.WriteLine("Service Finished  \nPress Any Key To Stop...");
            //Console.ReadKey();
        }

        static async Task RunAsync()
        {
            HostBuilder hostBuilder = new HostBuilder();

            hostBuilder.ConfigureLogging((logging) =>
            {
                logging.AddConsole();
            });

            hostBuilder.ConfigureAppConfiguration((configurationBuilder) =>
            {
                var builder = configurationBuilder.AddJsonFile("appSettings.json");
            });

            hostBuilder.ConfigureServices((serviceCollection) =>
            {
                serviceCollection.AddSingleton<IHostedService, HostService>();
            });

            await hostBuilder.RunConsoleAsync();
        }
    }
}
