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

            //注册Logger驱动程序
            hostBuilder.ConfigureLogging((logging) =>
            {
                logging.AddConsole();
            });

            //注册配置文件
            hostBuilder.ConfigureAppConfiguration((configurationBuilder) =>
            {
                var builder = configurationBuilder.AddJsonFile("appSettings.json");
            });

            //注册相关的服务，以及进行DependencyInjection
            hostBuilder.ConfigureServices((serviceCollection) =>
            {
                serviceCollection.AddSingleton<IHostedService, HostService>();
            });

            //处理完上述程序后即可启动
            await hostBuilder.RunConsoleAsync();
        }
    }
}
