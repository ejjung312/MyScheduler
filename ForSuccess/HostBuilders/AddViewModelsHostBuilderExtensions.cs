﻿using ForSuccess.State.Navigators;
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
                services.AddTransient<LoginViewModel>();

                // AddSingleton: 애플리케이션 전체에서 하나의 인스턴스만 생성
                //services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                //services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => services.GetRequiredService<LoginViewModel>());

                services.AddSingleton<ViewModelFactory>();

                // AddScoped: 요청당 하나의 인스턴스 생성. 요청이 끝날 때까지 동일한 인스턴스 사용
            });

            return host;
        }
    }
}