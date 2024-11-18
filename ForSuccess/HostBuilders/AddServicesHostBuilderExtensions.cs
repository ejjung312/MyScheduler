using Domain.Models;
using Domain.Services;
using Domain.Services.AuthenticationServices;
using EntityFramework.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForSuccess.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();

                services.AddSingleton<IDataService<Account>, AccountDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
            });

            return host;
        }
    }
}
