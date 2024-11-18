using Domain.Services;
using ForSuccess.State.Accounts;
using ForSuccess.State.Authenticators;
using ForSuccess.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForSuccess.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        /*
         * this: 메서드를 호출하는 인스턴스 자신을 참조
         */
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
            });

            return host;
        }
    }
}
