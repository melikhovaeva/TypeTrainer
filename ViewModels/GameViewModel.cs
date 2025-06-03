using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using TypeMaster.Helpers;
using TypeMaster.Models;
using TypeMaster.Services;

namespace TypeMaster.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private readonly IAppStateService _state;
        private readonly IStatisticsService _stats;
        private readonly INavigationService _nav;
        private readonly SettingsModel _settings;

        private readonly string[] _words;

        public string[] Words => _words;

        public string DisplayText { get; }
        public FlowDocument EditableDocument { get; set; } = new FlowDocument();

        private readonly Stopwatch _timer = new();

        private int _errors;
        public int Errors
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }

        private double _wpm;
        public double Wpm
        {
            get => _wpm;
            set => SetProperty(ref _wpm, value);
        }

        public ICommand FinishCommand { get; }

        public GameViewModel(
            IAppStateService state,
            IStatisticsService stats,
            INavigationService nav,
            ISettingsService settingsService)
        {
            _state = state;
            _stats = stats;
            _nav = nav;
            _settings = settingsService.Load();

            var dict = _state.SelectedDictionary
                       ?? throw new InvalidOperationException("Словарь не выбран");

            _words = dict.Words
                         .OrderBy(_ => Guid.NewGuid())
                         .Take(_settings.TestLengthWords)
                         .ToArray();

            DisplayText = string.Join(" ", _words);

            FinishCommand = new RelayCommand(_ => Finish());
        }

        public void ProcessInput(string inputText)
        {
            var typedWords = inputText
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int totalErrors = 0;
            for (int i = 0; i < typedWords.Length; i++)
            {
                if (i >= Words.Length || typedWords[i] != Words[i])
                    totalErrors++;
            }
            Errors = totalErrors;

            var minutes = _timer.Elapsed.TotalMinutes;
            var correctChars = inputText.Length - Errors;
            Wpm = minutes > 0
                ? Math.Round((correctChars / 5.0) / minutes, 1)
                : 0;
        }

        public void StartTimerIfNeeded()
        {
            if (!_timer.IsRunning)
                _timer.Start();
        }

        private void Finish()
        {
            _timer.Stop();

            _stats.Save(new TypingStatistic
            {
                Date = DateTime.Now,
                WordsPerMinute = Wpm,
                Errors = Errors,
                DictionaryName = _state.SelectedDictionary!.Name
            });

            _nav.CurrentViewModel = App.ServiceProvider
                .GetRequiredService<MainViewModel>();
        }
    }
}
