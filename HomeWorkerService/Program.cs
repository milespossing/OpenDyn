using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenDyn.Client;

namespace HomeWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IIpClient>(new IpClient());
                    services.AddSingleton<IApiClient>(provider =>
                        new ApiClient(new Uri(hostContext.Configuration["PostEndpoint"])));
                    services.AddHostedService<Worker>();
                });
    }
}