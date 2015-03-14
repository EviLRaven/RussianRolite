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
    public partial class AuthOrRegPanel : Form
    {
        public AuthOrRegPanel()
        {
            InitializeComponent();
        }

        public string GetName
        {
            get
            {

                return textBox1.Text;
            }

        }

        public string GetPassword
        {
            get
            {
                return textBox2.Text;
            }
        }


    }
}
