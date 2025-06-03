using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TypeMaster.Models;

namespace TypeMaster.Services
{
    public class JsonStatisticsService : IStatisticsService
    {
        private readonly string _path =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "statistics.json");

        public void Save(TypingStatistic stat)
        {
            var list = LoadAll();
            list.Add(stat);
            var dir = Path.GetDirectoryName(_path)!;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            File.WriteAllText(_path, JsonConvert.SerializeObject(list, Formatting.Indented));
        }

        public List<TypingStatistic> LoadAll()
        {
            if (!File.Exists(_path))
                return new List<TypingStatistic>();
            var json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<List<TypingStatistic>>(json)!
                   ?? new List<TypingStatistic>();
        }
    }
}