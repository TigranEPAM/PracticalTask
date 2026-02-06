using PracticalTask2.Core.Configuration;
using Serilog;
using Serilog.Events;

namespace PracticalTask2.Core.Utilities
{
    public static class Log
    {
        public static ILogger Logger { get; }

        static Log()
        {
            Logger = new LoggerConfiguration()
                .MinimumLevel.Is(ParseLogLevel(FrameworkConfig.LogLevel))
                .WriteTo.Console()
                .WriteTo.File("logs/test.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private static LogEventLevel ParseLogLevel(string level)
        {
            return level.ToLower() switch
            {
                "verbose" => LogEventLevel.Verbose,
                "debug" => LogEventLevel.Debug,
                "information" => LogEventLevel.Information,
                "warning" => LogEventLevel.Warning,
                "error" => LogEventLevel.Error,
                "fatal" => LogEventLevel.Fatal,
                _ => LogEventLevel.Information
            };
        }
    }
}
