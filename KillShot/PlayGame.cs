using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace KillShot
{
    public partial class PlayGame : Form
    {
        private string NamePlayer;
        public PlayGame()
        {
            InitializeComponent();
        }

        public PlayGame(string name)
        {
            InitializeComponent();
            NamePlayer = name;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (Gamer.Insteance.Shot())
            {
                MessageBox.Show(this, "LOL YOU DEAD !!!!", "Russian Rolite", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                label3.Text = Gamer.Insteance.ShotNum.ToString();
                label4.Text = Gamer.Insteance.Points.ToString();
                if (MessageBox.Show(this, "Next RollDryer !?!?", "Russian Rolite", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MessageBox.Show(this, "Good Luck , Go Roll !!!!", "Russian Rolite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = false;
                    button1.Enabled = true;
                }
                else
                {

                    var GamerName = NamePlayer;
                    if (!Gamer.Insteance.SavePoints(GamerName))
                    {
                        MessageBox.Show(this, "Sorry Man , BD Not Aviable , Die Again :D !!!!", "Russian Rolite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "You Point Save", "Russian Rolite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }

                }
            }
        }

        private void PlayGame_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gamer.Insteance.RollDrayer();
            MessageBox.Show(this, " Shot ", "Russian Rolite", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button2.Enabled = true;
            button1.Enabled = false;
        }


    }
}
