using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmailSender.Smtp.Core.Sample
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }
        
        static async Task Main(string[] args)
        {
            // Set up configuration sources.
            var service = ConfigureApplication();
            var app = service.GetService<App>();
            await app.RunApp();
            Console.ReadLine();
        }

        private static ServiceProvider ConfigureApplication()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);

            Configuration = builder.Build();
            
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSmtpEmailSender(Configuration)
                .AddTransient<App>()
                .BuildServiceProvider();
            

            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddFilter("Microsoft", LogLevel.Warning)
                        .AddConsole();
                }
            );

            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogDebug("Starting application");

            return serviceProvider;
        }
    }
}