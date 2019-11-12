using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Akanami.EfCoreSqlite
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
                services.AddDbContext<SqliteContext>((configure) => 
                {
                    var connectionString = context.Configuration.GetConnectionString("Default");
                    configure.UseSqlite(connectionString);
                });

                services.AddSingleton<IHostedService, HostService>();
            });

            await hostBuilder.RunConsoleAsync();
        }
    }
}
