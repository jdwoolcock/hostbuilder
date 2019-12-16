using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hostbuilder
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                await new HostBuilder()
                    .ConfigureAppConfiguration((hostContext, configBuilder) =>
                    {
                        configBuilder.AddJsonFile("appsettings.json");
                    })
                    .ConfigureLogging((_, config) =>
                    {
                        config.AddConsole();
                    })
                    .ConfigureServices(services => services.AddHostedService<HostedService>())
                    .RunConsoleAsync();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
