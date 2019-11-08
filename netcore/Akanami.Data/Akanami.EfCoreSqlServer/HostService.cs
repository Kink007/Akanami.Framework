using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Akanami.EfCoreSqlServer
{
    public class HostService : IHostedService
    {
        private readonly ILogger logger;
        private readonly SampleContext sampleContext;

        public HostService(ILogger<HostService> logger, SampleContext sampleContext)
        {
            this.logger = logger;
            this.sampleContext = sampleContext;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //var userCount = await this.sampleContext.Users.CountAsync();
            //var appCount = await this.sampleContext.Apps.CountAsync();

            //this.logger.LogInformation($"User Count:{userCount}");
            //this.logger.LogInformation($"App Count:{appCount}");

            var query = this.sampleContext.Set<User>()
                            .Include(x => x.UserApps).ThenInclude(pt => pt.App)
                            .AsNoTracking();

            foreach (var user in query)
            {
                foreach (var app in user.UserApps)
                {
                    this.logger.LogInformation($"App Id[{app.App.Id}] Name[{app.App.Name}]");    
                }
            }


            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => 
            {
                this.logger.LogInformation("Host Service Has Stopped");
            });
        }
    }
}
