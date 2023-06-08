using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Domain.Interface;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Settings
{
    public class PlayerPanels : IPlayerPanels
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        [XmlIgnore][NotMapped]
        public Color BackColor { get; set; }

        
        [XmlElement("BackColor")]
        public int BackColorAsArgb
        {
            get { return BackColor.ToArgb(); }
            set { BackColor = Color.FromArgb(value); }
        }

        public long UserSettingsId { get; set; }
    }

}
