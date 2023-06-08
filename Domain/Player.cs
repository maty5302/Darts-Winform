using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        public long Id { get; set; }

        public DateTime date { get ; set; } 

        public string Name { get; set; }
        public int Wins { get; set; }
        public double Average { get; set; }
        public int highestOut { get; set; }
        public int sixty { get; set; }
        public int hundred { get; set; }
        public int hundred20 { get; set; }
        public int hundred80 { get; set; }
        
        public int AllWins { get; set; }
        public int OldhighestOut { get; set; }
        public int Allsixty { get; set; }
        public int Allhundred { get; set; }
        public int Allhundred20 { get; set; }
        public int Allhundred80 { get; set; }

        public bool firstWin { get; set; }
        public bool _20Wins { get; set; }
        public bool _100Wins { get; set; }
        public bool first180 { get; set; }
        public bool profesional { get; set; }

        public Player()
        {
            Name = "Hráč Test";
            Wins = 1;
            Average = 99.9;
            sixty = 6;
            hundred = 10;
            hundred20 = 12;
            hundred80 = 18;
        }

        public Player(string jmeno)
        {
            Name = jmeno;
            Wins = 0;
            Average = 0;
            sixty = 0;
            hundred = 0;
            hundred20 =0;
            hundred80 = 0;
            date = DateTime.Now;
        }

        public Player(string name, int wins, double average, int sixty, int hundred, int hundred20, int hundred80, bool firstWin, bool _20Wins, bool _100Wins, bool first180, bool profesional) : this(name)
        {
            Wins = wins;
            Average = average;
            this.sixty = sixty;
            this.hundred = hundred;
            this.hundred20 = hundred20;
            this.hundred80 = hundred80;
            this.firstWin = firstWin;
            this._20Wins = _20Wins;
            this._100Wins = _100Wins;
            this.first180 = first180;
            this.profesional = profesional;
        }

        public void AddWin()
        {
            Wins++;
            if (Wins >= 1 && !firstWin)
                firstWin = true;
            if (Wins >= 20 && !_20Wins)
                _20Wins = true;
            if (Wins >= 100 && !_100Wins)
               _100Wins = true;
        }

        public void AddSixty()
        {
            sixty++;
        }

        public void AddHundred()
        {
            hundred++;
        }

        public void AddHundred20()
        {
            hundred20++;
        }

        public void AddHundred80()
        {
            hundred80++;
            if(hundred80==1 && !first180)
                first180= true;
        }

        
    }
}
