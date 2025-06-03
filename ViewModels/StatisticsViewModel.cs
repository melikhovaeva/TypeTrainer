using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using TypeMaster.Helpers;
using TypeMaster.Models;
using TypeMaster.Services;

namespace TypeMaster.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        private readonly IStatisticsService _stats;
        private readonly INavigationService _nav;

        public ObservableCollection<TypingStatistic> Statistics { get; }
        public ICommand BackCommand { get; }
        public ICommand ExportCommand { get; }

        public StatisticsViewModel(
            IStatisticsService stats,
            INavigationService nav)
        {
            _stats = stats;
            _nav = nav;

            Statistics = new ObservableCollection<TypingStatistic>(_stats.LoadAll());

            BackCommand = new RelayCommand(_ =>
            {
                _nav.CurrentViewModel = App.ServiceProvider
                    .GetRequiredService<MainViewModel>();
            });

            ExportCommand = new RelayCommand(_ => ExportCsv());
        }

        private void ExportCsv()
        {
            var dlg = new SaveFileDialog
            {
                Filter = "CSV-файлы (*.csv)|*.csv",
                FileName = "statistics.csv",
                DefaultExt = "csv"
            };
            if (dlg.ShowDialog() != true)
                return;

            var sb = new StringBuilder();
            sb.AppendLine("Date,WordsPerMinute,Errors,DictionaryName");
            foreach (var st in Statistics)
            {
                var date = st.Date.ToString("yyyy-MM-dd HH:mm");
                sb.AppendLine($"{date},{st.WordsPerMinute},{st.Errors},{st.DictionaryName}");
            }

            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
        }
    }
}