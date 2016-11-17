using Microsoft.Extensions.Logging;

namespace Logging
{

    /// <summary>
    /// Main Application starting point
    /// </summary>
    public class Application {

        ILogger<Application> Log {get; set;}

        /// <summary>
        /// Uses the dependency injection to pass in the Logging
        /// factory.
        /// </summary>
        /// <param name="logger">Logger Factory Instance</param>
        public Application (ILogger<Application> logger)
        {    
            Log = logger;
        }

        /// <summary>
        /// Execute the application
        /// </summary>
        public void Run() {

            Log.LogInformation("Hello World");

            Log.LogWarning("Oh no the world might blow");

            Log.LogError("Oh my god the world is gonna blow!");
            
        }

    }
    
}