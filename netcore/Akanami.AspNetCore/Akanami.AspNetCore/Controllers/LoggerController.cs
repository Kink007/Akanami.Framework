using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Akanami.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            this.logger = logger;
        }

        public async Task<string> Get(string msg)
        {
            this.logger.LogInformation($"测试消息:{msg}");

            return await Task.FromResult("ok");
        }
    }
}