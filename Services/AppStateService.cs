using TypeMaster.Models;

namespace TypeMaster.Services
{
    public class AppStateService : IAppStateService
    {
        public DictionaryModel? SelectedDictionary { get; set; }
    }
}