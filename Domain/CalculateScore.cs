using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain
{
    public static class CalculateScore
    {
        public static string? GetResult(int score, int thrown,bool muteSounds, out int result)
        {
            result = score - thrown;
            if (thrown < 0 || thrown > 180 || result < 0)
            {
                if(!muteSounds)
                    SoundManagerDarts.SoundEffects.PlayScoreAsync(0);
                return null;
            }
            else
            {
                if (!muteSounds)
                    SoundManagerDarts.SoundEffects.PlayScoreAsync(score);
                return result.ToString();
            }
        }
    }
}
