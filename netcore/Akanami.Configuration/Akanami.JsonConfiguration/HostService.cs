using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akanami.JsonConfiguration
{
    public class HostService : IHostedService
    {
        private readonly HostOptions options;
        private readonly ILogger logger;

        public HostService(IOptions<HostOptions> options, ILogger<HostService> logger)
        {
            this.options = options.Value;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("==============================================================");
            this.logger.LogInformation($"Options Name:{this.options.Name} TestValue:{this.options.TestValue}");
            this.logger.LogInformation("==============================================================");

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("停止服务");

            await Task.CompletedTask;
        }
    }
}
