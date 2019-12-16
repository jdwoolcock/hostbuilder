using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hostbuilder
{
    public class HostedService : BackgroundService
    {
        private readonly ILogger logger;

        public HostedService(ILogger<HostedService> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Service starting.");

            stoppingToken.Register(() => logger.LogInformation("Service has been  stopped."));

            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Service is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            logger.LogInformation("Service has finished.");
        }
    }
}