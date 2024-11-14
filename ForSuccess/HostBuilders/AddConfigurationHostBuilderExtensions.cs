using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ForSuccess.HostBuilders
{
    public static class AddConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables(); // TODO 무조건 해야하나
            });

            return host;
        }
    }
}
