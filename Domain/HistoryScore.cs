using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class HistoryScore
    {
        private static List<List<string>> history = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>() };
        private static string? historyValue;

        public static void AddHistory(int player, string score)
        {
            history[player].Add(score);
        }

        public static void ClearHistory()
        {
            history.All(a => { a.Clear(); return true; });
        }

        public static string? RedoLastScore(int player)
        {
            if (history[player].Count > 0)
            {
                historyValue = history[player].Last();
                history[player].RemoveAt(history[player].Count - 1);
                AverageScore.RemoveLastAverage(player);
                return historyValue;
            }
            else
                return null;
        }

        public static bool IsEmpty(int player)
        {
            return history[player].Count == 0;
        }
    }
}
