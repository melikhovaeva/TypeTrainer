using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using TypeMaster.Helpers;
using TypeMaster.Models;
using TypeMaster.Services;

namespace TypeMaster.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly INavigationService _nav;

        private SettingsModel _settings;
        public SettingsModel Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public SettingsViewModel(
            ISettingsService settingsService,
            INavigationService nav)
        {
            _settingsService = settingsService;
            _nav = nav;

            Settings = _settingsService.Load();

            SaveCommand = new RelayCommand(_ =>
            {
                _settingsService.Save(Settings);
            });

            BackCommand = new RelayCommand(_ =>
            {
                _nav.CurrentViewModel = App.ServiceProvider
                    .GetRequiredService<MainViewModel>();
            });
        }
    }
}