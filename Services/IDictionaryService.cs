using System.Collections.Generic;
using TypeMaster.Models;

namespace TypeMaster.Services
{
    public interface IDictionaryService
    {
        List<DictionaryModel> LoadAll();
        void Save(DictionaryModel dict);
    }
}