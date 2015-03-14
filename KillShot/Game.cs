using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillShot
{
    public partial class Game : Form
    {
        string NamePlayer;
        public Game()
        {
            InitializeComponent();
        }

        public Game(string name)
        {
            InitializeComponent();
            NamePlayer = name;
            MessageBox.Show(this, "Привет " + NamePlayer,"Killer Shot 2.0" , MessageBoxButtons.OK, MessageBoxIcon.Information); 
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            PlayGame f = new PlayGame(NamePlayer);
            f.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowRecord f =new ShowRecord(NamePlayer);
            f.ShowDialog(this);
        }
    }
}
