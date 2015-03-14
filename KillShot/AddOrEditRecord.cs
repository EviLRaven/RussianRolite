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
    public partial class AddOrEditRecord : Form
    {
        public AddOrEditRecord()
        {
            InitializeComponent();
        }

        public string GetOrSetName
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

        public int GetOrSetPoint
        {
            get
            {
                return Convert.ToInt32(textBox2.Text);
            }
            set
            {
                textBox2.Text = Convert.ToString(value);
            }
        }

    }
}
