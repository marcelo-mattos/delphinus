using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Delphinus.Tests
{
    /// <summary>
    /// Provides the entry point and application startup logic for the program.
    /// </summary>
    /// <remarks>This class is responsible for configuring logging and dependency injection, building the
    /// application host, and starting the main application workflow. It is intended for internal use and is not
    /// designed to be instantiated or used directly by consumers.</remarks>
    internal static class Program
    {
        /// <summary>
        /// Program Entry point
        /// </summary>
        private static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();

                    logging.SetMinimumLevel(LogLevel.Debug);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.AddConsole();
                        logging.SetMinimumLevel(LogLevel.Debug);
                    });
                    services.AddTransient<App>();
                })
                .Build();

            var app = host.Services.GetRequiredService<App>();
            await app.RunAsync();
        }
    }
}
