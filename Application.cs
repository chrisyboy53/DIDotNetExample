using Microsoft.Extensions.Logging;

namespace Logging {
    public class Application {

        ILoggerFactory _logging = null;

        ILogger Log { get {
            return _logging?.CreateLogger<Application>();
        }}

        public Application (ILoggerFactory loggerFactory)
        {    
            _logging = loggerFactory;
        }

        public void Run() {

            Log.LogInformation("Hello World");

            Log.LogWarning("Oh no the world might blow");

            Log.LogError("Oh my god the world is gonna blow!");
            
        }

    }
}