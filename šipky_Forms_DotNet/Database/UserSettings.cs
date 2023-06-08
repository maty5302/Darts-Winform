using Domain.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace šipky_Forms.Database
{
    public class UserSettings
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public bool muteSounds { get; set; }
        public List<PlayerPanels> panels { get; set; }
    }
}
