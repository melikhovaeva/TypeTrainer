using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TypeMaster.Services;
using TypeMaster.ViewModels;
using TypeMaster.Views;

namespace TypeMaster
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAppStateService, AppStateService>();

            services.AddSingleton<IDictionaryService, JsonDictionaryService>();
            services.AddSingleton<ISettingsService, JsonSettingsService>();
            services.AddSingleton<IStatisticsService, JsonStatisticsService>();

            services.AddSingleton<MainViewModel>();
            services.AddTransient<GameViewModel>();
            services.AddTransient<DictionaryEditorViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<StatisticsViewModel>();

            services.AddSingleton<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();

            var nav = ServiceProvider.GetRequiredService<INavigationService>();
            nav.CurrentViewModel = ServiceProvider.GetRequiredService<MainViewModel>();

            var mw = ServiceProvider.GetRequiredService<MainWindow>();
            mw.Show();
        }
    }
}