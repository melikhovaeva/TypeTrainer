using System.Collections.Generic;
using TypeMaster.Models;

namespace TypeMaster.Services
{
    public interface IStatisticsService
    {
        void Save(TypingStatistic stat);
        List<TypingStatistic> LoadAll();
    }
}