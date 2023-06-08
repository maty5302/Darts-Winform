using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class AverageScore
    {
        private static List<List<int>> averages = new List<List<int>>() { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>() };

        public static string CalculateAverage(int player)
        {
            if (player > -1 && averages[player].Count > 0)
                return averages[player].Average().ToString("0.00");
            else
                return "0,00";
        }

        public static void ClearAverage()
        {
            averages.All(a => { a.Clear(); return true; });
        }

        public static void AddAverage(int player, int score)
        {
            averages[player].Add(score);
        }

        public static void RemoveLastAverage(int player)
        {
            averages[player].RemoveAt(averages[player].Count - 1);
        }
    }
}
