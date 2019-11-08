using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Akanami.EfCoreSqlServer
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

            hostBuilder.ConfigureAppConfiguration(configure =>
            {
                configure.AddJsonFile("appSettings.json");
            });

            hostBuilder.ConfigureLogging(configure =>
            {
                configure.AddConsole();
            });

            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<SampleContext>(options =>
                {
                    var connectionString = context.Configuration.GetConnectionString("Default");
                    options.UseSqlServer(connectionString);
                });

                services.AddHostedService<HostService>();
            });

            await hostBuilder.RunConsoleAsync();
        }
    }
}
