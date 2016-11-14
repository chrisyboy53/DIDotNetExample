using Microsoft.Extensions.Logging;

namespace Logging
{

    /// <summary>
    /// Main Application starting point
    /// </summary>
    public class Application {

        ILoggerFactory _logging = null;

        ILogger Log { get {
            return _logging?.CreateLogger<Application>();
        }}

        /// <summary>
        /// Uses the dependency injection to pass in the Logging
        /// factory.
        /// </summary>
        /// <param name="loggerFactory">Logger Factory Instance</param>
        public Application (ILoggerFactory loggerFactory)
        {    
            _logging = loggerFactory;
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