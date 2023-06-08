using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CA1416 // Ověřit kompatibilitu platformy
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
                    SoundEffects.SoundEffects.player[0].Play();
                return null;
            }
            else
            {
                if (!muteSounds)
                    SoundEffects.SoundEffects.player.ElementAt(thrown).Play();
                return result.ToString();
            }
        }
    }
}
