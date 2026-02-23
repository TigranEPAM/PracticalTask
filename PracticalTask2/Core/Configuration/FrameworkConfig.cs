using Microsoft.Extensions.Configuration;
using PracticalTask2.Core.Driver;

namespace PracticalTask2.Core.Configuration
{
    public static class FrameworkConfig
    {
        static FrameworkConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var browserEnv = Environment.GetEnvironmentVariable("BROWSER");
            Browser = !string.IsNullOrEmpty(browserEnv)
                ? Enum.Parse<BrowserType>(browserEnv, ignoreCase: true)
                : Enum.Parse<BrowserType>(config["Browser"]);
            BaseUrl = config["BaseUrl"];
            LogLevel = config["LogLevel"];
            ApiBaseUrl = config["ApiBaseUrl"];
        }

        public static BrowserType Browser { get; }
        public static string BaseUrl { get; }
        public static string LogLevel { get; }
        public static string ApiBaseUrl { get; }
    }
}
