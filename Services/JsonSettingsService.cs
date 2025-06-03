using System;
using System.IO;
using Newtonsoft.Json;
using TypeMaster.Models;

namespace TypeMaster.Services
{
    public class JsonSettingsService : ISettingsService
    {
        private readonly string _path =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        public SettingsModel Load()
        {
            if (!File.Exists(_path))
                return new SettingsModel();

            var json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<SettingsModel>(json)!
                   ?? new SettingsModel();
        }

        public void Save(SettingsModel settings)
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(settings, Formatting.Indented));
        }
    }
}