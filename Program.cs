using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
                // Execute Application
                app.Run();
            }
            else {
                throw new InvalidOperationException("No application instance. Check your dependencies.");
            }
        
        }

        /// <summary>
        /// Configures services
        /// </summary>
        private static void Configure() {
            var loggingFactory = serviceProvider.GetRequiredService(typeof(ILoggerFactory)) as ILoggerFactory;
            loggingFactory.AddConsole();
        }

        /// <summary>
        /// Configures the service collection
        /// </summary>
        /// <param name="serviceCollection"></param>
        private static void ConfigureServices(IServiceCollection serviceCollection) {
            serviceCollection.AddLogging();
            serviceCollection.AddSingleton<Application>();
        }

    }
}
