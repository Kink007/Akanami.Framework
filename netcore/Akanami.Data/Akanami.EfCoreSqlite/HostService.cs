using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akanami.EfCoreSqlite
{
    public class HostService : IHostedService
    {
        private readonly SqliteContext sampleContext;
        private readonly ILogger logger;

        public HostService(SqliteContext sqliteContext, ILogger<HostService> logger)
        {
            this.sampleContext = sqliteContext;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (!await this.sampleContext.Users.AnyAsync())
            {
                this.sampleContext.Users.Add(new User() { Id = 1, Name = "test1" });
                await this.sampleContext.SaveChangesAsync();
            }

            var userCount = await this.sampleContext.Users.CountAsync();
            var roleCount = await this.sampleContext.Roles.CountAsync();

            this.logger.LogInformation($"UserCount:{userCount}");
            this.logger.LogInformation($"RoleCount:{roleCount}");
        } 

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("停止服务");

            await Task.CompletedTask;
        }
    }
}
