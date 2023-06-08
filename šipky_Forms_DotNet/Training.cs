using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace šipky_Forms
{
    public partial class Training : UserControl
    {
        private int done = 0;
        private int fail = 0;
        private int totalscore = 0;
        private Random r = new Random();

        private void UpdateStatistics()
        {
            total.Text = totalscore.ToString();
            totalDone.Text = done.ToString();
            totalFailed.Text = fail.ToString();
        }

        private int ShuffleNumber()
        {
            int number = 0;
            Random random= new Random();
            number = random.Next(1,21);
            return number;
        }

        private void Decide(bool single, bool doubleD, bool triple, bool random, bool checkout)
        {

            if (single)
                showScore.Text = ShuffleNumber().ToString();
            else if (doubleD)
                showScore.Text = "D" + ShuffleNumber().ToString();
            else if (triple)
                showScore.Text = "T" + ShuffleNumber().ToString();
            else if (random)
            {
                int v = r.Next(1, 4);
                switch (v)
                {
                    case 1:
                        showScore.Text = ShuffleNumber().ToString();
                        break;
                    case 2:
                        showScore.Text = "D" + ShuffleNumber().ToString();
                        break;
                    case 3:
                        showScore.Text = "T" + ShuffleNumber().ToString();
                        break;
                    default:
                        break;
                }
            }
            else if (checkout)
            {
                List<int> prohibited = new List<int>() { 159, 162, 163, 165, 166, 168, 169};

                int check = r.Next(60, 171);
                while (prohibited.Contains(check))
                    check = r.Next(60, 171);                   

                showScore.Text = Checkout.checkout(check);
            }
        }

        public Training()
        {
            InitializeComponent();
        }

        public void Initializate()
        {
            totalscore = 0;
            done = 0;
            fail = 0;
            showScore.Text = "0";
            startTraining.Enabled = true;
            resetTraining.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            UpdateStatistics();
        }

        private void resetTraining_Click(object sender, EventArgs e)
        {
            Initializate();
        }

        private void startTraining_Click(object sender, EventArgs e)
        {
            Decide(singleDarts.Checked, doubleDarts.Checked, tripleDarts.Checked, randomDarts.Checked, checkoutDarts.Checked);
            startTraining.Enabled = false ;
            resetTraining.Enabled = true ;
            button1.Enabled = true ;
            button2.Enabled = true ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startTraining_Click(sender, e);
            done++;
            totalscore++;
            UpdateStatistics();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startTraining_Click(sender, e);
            totalscore++;
            fail++;
            UpdateStatistics();
        }
    }
}
