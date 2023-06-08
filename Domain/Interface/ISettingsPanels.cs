using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ISettingsPanels<T> where T : IPlayerPanels
    {
        string PicturePath { get; set; }
        bool muteSounds { get; set; }
        List<T> panels { get; set; }
    }
}
