using System.Collections.ObjectModel;

namespace TypeMaster.Models
{
    public class DictionaryModel
    {
        public string Name { get; set; } = string.Empty;
        public ObservableCollection<string> Words { get; set; } = new();
    }
}