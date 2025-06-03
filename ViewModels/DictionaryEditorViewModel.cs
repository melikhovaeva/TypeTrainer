using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using TypeMaster.Helpers;
using TypeMaster.Models;
using TypeMaster.Services;

namespace TypeMaster.ViewModels
{
    public class DictionaryEditorViewModel : BaseViewModel
    {
        private readonly IDictionaryService _dictService;
        private readonly INavigationService _nav;

        private DictionaryModel? _selectedDictionary;
        private string _newWord = string.Empty;
        private string? _selectedWord;

        public ObservableCollection<DictionaryModel> Dictionaries { get; }

        public DictionaryModel? SelectedDictionary
        {
            get => _selectedDictionary;
            set
            {
                if (SetProperty(ref _selectedDictionary, value))
                {
                    (AddWordCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (RemoveWordCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public string NewWord
        {
            get => _newWord;
            set
            {
                if (SetProperty(ref _newWord, value))
                    (AddWordCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public string? SelectedWord
        {
            get => _selectedWord;
            set
            {
                if (SetProperty(ref _selectedWord, value))
                    (RemoveWordCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ICommand AddWordCommand { get; }
        public ICommand RemoveWordCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public DictionaryEditorViewModel(
            IDictionaryService dictService,
            INavigationService nav)
        {
            _dictService = dictService;
            _nav = nav;

            Dictionaries = new ObservableCollection<DictionaryModel>(
                _dictService.LoadAll());

            AddWordCommand = new RelayCommand(_ =>
            {
                if (SelectedDictionary != null && !string.IsNullOrWhiteSpace(NewWord))
                {
                    SelectedDictionary.Words.Add(NewWord.Trim());
                    NewWord = string.Empty;
                }
            }, _ => SelectedDictionary != null && !string.IsNullOrWhiteSpace(NewWord));

            RemoveWordCommand = new RelayCommand(_ =>
            {
                if (SelectedDictionary != null && SelectedWord != null)
                    SelectedDictionary.Words.Remove(SelectedWord);
            }, _ => SelectedDictionary != null && SelectedWord != null);

            SaveCommand = new RelayCommand(_ =>
            {
                foreach (var dict in Dictionaries)
                    _dictService.Save(dict);
            });

            BackCommand = new RelayCommand(_ =>
            {
                _nav.CurrentViewModel = App.ServiceProvider
                    .GetRequiredService<MainViewModel>();
            });

            if (Dictionaries.Count > 0)
                SelectedDictionary = Dictionaries[0];
        }
    }
}
