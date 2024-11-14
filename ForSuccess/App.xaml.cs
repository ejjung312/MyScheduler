using EntityFramework;
using ForSuccess.HostBuilders;
using ForSuccess.State.Navigators;
using ForSuccess.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Principal;
using System.Windows;

namespace ForSuccess
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            //return Host.CreateDefaultBuilder(args)
            //    .AddConfiguration()
            //    .AddDbContext()
            //    .AddStores()
            //    .AddViewModels()
            //    .AddViews();
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                    c.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    //string connectionString = context.Configuration.GetConnectionString("default");
                    //services.AddDbContext<ForSuccessDbContext>(o => o.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString),
                    //                                            b => b.MigrationsAssembly("EntityFramework")));
                    //services.AddSingleton<ForSuccessDbContextFactory>(new ForSuccessDbContextFactory(connectionString));

                    services.AddSingleton<ForSuccessDbContextFactory>();

                    services.AddSingleton<ViewModelFactory>();
                    services.AddSingleton<HomeViewModel>(services => new HomeViewModel());

                    services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<HomeViewModel>();
                    });

                    services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();

                    services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                    {
                        return () => new LoginViewModel(
                            services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
                    });

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddScoped<MainViewModel>();

                    services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();

            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
