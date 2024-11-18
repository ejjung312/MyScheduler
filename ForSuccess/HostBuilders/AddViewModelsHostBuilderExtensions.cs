using ForSuccess.State.Authenticators;
using ForSuccess.State.Navigators;
using ForSuccess.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForSuccess.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                // AddTransient: 요청할 때마다 새로운 인스턴스 생성
                services.AddTransient<MainViewModel>();
                services.AddTransient<HomeViewModel>(services => new HomeViewModel());

                // AddSingleton: 애플리케이션 전체에서 하나의 인스턴스만 생성
                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateloginViewModel(services));

                services.AddSingleton<ViewModelFactory>();

                // AddScoped: 요청당 하나의 인스턴스 생성. 요청이 끝날 때까지 동일한 인스턴스 사용
            });

            return host;
        }

        private static LoginViewModel CreateloginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
        }
    }
}
