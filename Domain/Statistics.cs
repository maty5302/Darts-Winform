using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Statistics
    {
        public static void CheckStatistics(Player player, int thrown)
        {
            if (thrown >= 60 && thrown < 100)
                player.AddSixty();
            else if (thrown >= 100 && thrown < 120)
                player.AddHundred(); 
            else if(thrown >= 120 && thrown < 180)
                player.AddHundred20();
            else if(thrown==180)
                player.AddHundred80();
        } 

        public static void CheckExpertAchievement(Player player, int skore)
        {
            if(skore>=100 && player.profesional==false)
                player.profesional = true;
        }

        private static void Migrate(Player player)
        {
            player.AllWins += player.Wins;
            player.OldhighestOut = player.highestOut;
            player.Allsixty += player.sixty;
            player.Allhundred += player.hundred;
            player.Allhundred20 += player.hundred20;
            player.Allhundred80 += player.hundred80;

            player.Average = player.highestOut = player.Wins = player.sixty = player.hundred = player.hundred20 = player.hundred80 = 0;
        }

        public static void CheckDateStatistics(List<Player> players)
        {
            foreach (Player player in players)
            {
                if(player.date==DateTime.MinValue || player.date.Year < DateTime.Now.Year)
                {
                    Migrate(player);
                    player.date = DateTime.Now.Date;
                }
            }
        }
    }
}
