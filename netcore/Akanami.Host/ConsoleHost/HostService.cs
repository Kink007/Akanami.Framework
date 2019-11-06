using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleHost
{
    public class HostService : IHostedService
    {
        private readonly ILogger logger;

        public HostService(ILogger<HostService> logger)
        {
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => 
            {
                this.logger.LogInformation("HostService Run Started");
            });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => 
            {
                this.logger.LogInformation("HostService Run Stopped");
            });
        }
    }
}
