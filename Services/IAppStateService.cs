using TypeMaster.Models;

namespace TypeMaster.Services
{
    public interface IAppStateService
    {
        DictionaryModel? SelectedDictionary { get; set; }
    }
}