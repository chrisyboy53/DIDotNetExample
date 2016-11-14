using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Logging
{
    public class Program
    {
        static IServiceProvider serviceProvider = null;

        public static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
            Configure();
            
            Application app = serviceProvider.GetRequiredService(typeof(Application)) as Application;
            if (app != null) {
                app.Run();
            }
            else {
                throw new Exception("No application instance. Check your dependencies.");
            }
        }

        private static void Configure() {
            var loggingFactory = serviceProvider.GetRequiredService(typeof(ILoggerFactory)) as ILoggerFactory;
            loggingFactory.AddConsole();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection) {
            serviceCollection.AddLogging();
            serviceCollection.AddSingleton<Application>();
        }

    }
}
