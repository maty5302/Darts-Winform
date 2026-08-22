namespace Domain
{
    public static class AverageScore
    {
        private static List<List<int>> averages = new List<List<int>>() { new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>(), new List<int>() };

        private static double CalculateAverage(int player)
        {
            if (player > -1 && averages[player].Count > 0)
                return averages[player].Average();
            else
                return 0;
        }
        
        public static double AddAverage(int player, int score)
        {
            averages[player].Add(score);
            return CalculateAverage(player);
        }

        public static void ClearAverage()
        {
            averages.All(a => { a.Clear(); return true; });
        }

        public static void RemoveLastAverage(int player)
        {
            if(averages[player].Count > 0)
                averages[player].RemoveAt(averages[player].Count - 1);
        }

        public static double GetAverageOfPlayer(int player)
        {
            return CalculateAverage(player);
        }
    }
}
