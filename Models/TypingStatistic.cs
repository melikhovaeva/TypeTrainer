using System;

namespace TypeMaster.Models
{
    public class TypingStatistic
    {
        public DateTime Date { get; set; }
        public double WordsPerMinute { get; set; }
        public int Errors { get; set; }
        public string DictionaryName { get; set; } = string.Empty;
    }
}