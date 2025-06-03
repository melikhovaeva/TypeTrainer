using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using TypeMaster.Helpers;
using TypeMaster.Models;
using TypeMaster.Services;

namespace TypeMaster.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IDictionaryService _dictService;
        private readonly IAppStateService _state;
        private readonly INavigationService _nav;

        private DictionaryModel? _selectedDictionary;

        public ObservableCollection<DictionaryModel> Dictionaries { get; }

        public DictionaryModel? SelectedDictionary
        {
            get => _selectedDictionary;
            set
            {
                if (SetProperty(ref _selectedDictionary, value))
                    ((RelayCommand)StartGameCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand StartGameCommand { get; }
        public ICommand EditDictionariesCommand { get; }
        public ICommand ViewStatisticsCommand { get; }
        public ICommand OpenSettingsCommand { get; }

        public MainViewModel(
            IDictionaryService dictService,
            IAppStateService state,
            INavigationService nav)
        {
            _dictService = dictService;
            _state = state;
            _nav = nav;

            Dictionaries = new ObservableCollection<DictionaryModel>(_dictService.LoadAll());

            StartGameCommand = new RelayCommand(_ =>
            {
                _state.SelectedDictionary = SelectedDictionary!;
                _nav.CurrentViewModel = App.ServiceProvider
                    .GetRequiredService<GameViewModel>();
            }, _ => SelectedDictionary != null);

            EditDictionariesCommand = new RelayCommand(_ =>
            {
                _nav.CurrentViewModel = App.ServiceProvider
                    .GetRequiredService<DictionaryEditorViewModel>();
            });

            ViewStatisticsCommand = new RelayCommand(_ =>
            {
                _nav.CurrentViewModel = App.ServiceProvider
                    .GetRequiredService<StatisticsViewModel>();
            });

            OpenSettingsCommand = new RelayCommand(_ =>
            {
                _nav.CurrentViewModel = App.ServiceProvider
                    .GetRequiredService<SettingsViewModel>();
            });
        }
    }
}
