using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Settings
{
    public class SettingsPlayers : ISettingsPanels<PlayerPanels>
    {
        public string PicturePath { get; set; }
        public bool muteSounds { get; set; }
        public List<PlayerPanels> panels { get; set; } 
    }
}
