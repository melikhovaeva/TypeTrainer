using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TypeMaster.Models;

namespace TypeMaster.Services
{
    public class JsonDictionaryService : IDictionaryService
    {
        private readonly string _folder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Dictionaries");

        public List<DictionaryModel> LoadAll()
        {
            if (!Directory.Exists(_folder))
                Directory.CreateDirectory(_folder);

            var files = Directory.GetFiles(_folder, "*.json");
            return files
                .Select(f => JsonConvert.DeserializeObject<DictionaryModel>(File.ReadAllText(f))!)
                .ToList();
        }

        public void Save(DictionaryModel dict)
        {
            if (!Directory.Exists(_folder))
                Directory.CreateDirectory(_folder);

            var path = Path.Combine(_folder, dict.Name + ".json");
            File.WriteAllText(path, JsonConvert.SerializeObject(dict, Formatting.Indented));
        }
    }
}