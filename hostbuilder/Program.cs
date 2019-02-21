using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Hosting;
using Serilog;

namespace HostTest
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Configuration providers
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // createSerilog logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            var hostBuilder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {

                }).UseSerilog();

            Log.Information("Starting host");

            await hostBuilder.RunConsoleAsync();
        }
    }
}
