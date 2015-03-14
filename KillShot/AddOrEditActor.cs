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
    public partial class AddOrEditActor : Form
    {
        public AddOrEditActor()
        {
            InitializeComponent();
        }

        public string GetOrSetLogin
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }

        }

        public string GetOrSetPass
        {
            get
            {
                return textBox2.Text;
            }

            set
            {
                textBox2.Text = value;
            }
        }
    }
}
