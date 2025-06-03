using System;
using System.Collections.Generic;
using TypeMaster.Models;

namespace TypeMaster.Services
{
    public class SqliteStatisticsService : IStatisticsService
    {
        public void Save(TypingStatistic stat)
        {
            // TODO: здесь будет реализация через EF Core / SQLite
            throw new NotImplementedException();
        }

        public List<TypingStatistic> LoadAll()
        {
            // TODO: загрузка статистики
            throw new NotImplementedException();
        }
    }
}