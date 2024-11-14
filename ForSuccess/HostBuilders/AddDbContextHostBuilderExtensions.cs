using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForSuccess.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("default");
                services.AddDbContext<ForSuccessDbContext>(o => o.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("EntityFramework")));
                services.AddSingleton<ForSuccessDbContextFactory>(new ForSuccessDbContextFactory(connectionString));
            });

            return host;
        }
    }
}
