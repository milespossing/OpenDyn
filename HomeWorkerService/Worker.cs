using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenDyn.Client;

namespace HomeWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IIpClient _client;
        private readonly IApiClient _reporter;

        public Worker(ILogger<Worker> logger, IIpClient client, IApiClient reporter)
        {
            _logger = logger;
            _client = client;
            _reporter = reporter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker running at: {DateTime.UtcNow:u}");
                var ip = await _client.GetIp();
                _logger.LogInformation($"Reporting Ip Address: {ip}");
                await _reporter.SetIpAddressAsync(ip);
                _logger.LogInformation("Finished");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}