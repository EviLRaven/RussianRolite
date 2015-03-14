using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateLayer;

namespace KillShot
{
    public partial class Authication : Form
    {
        public Authication()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AuthOrRegPanel f = new AuthOrRegPanel();
            bool actor = false;
            bool admin = false;
            bool q1 = false;
            bool q2 = false;
            string login = "";
            string password = "";

            while (!q1)
            {

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    login = f.GetName;
                    password = f.GetPassword;

                    string pod_l = login.Trim();
                    string pod_p = password.Trim();

                    if (pod_l.Length == 0 && pod_p.Length == 0)
                    {
                        q2 = true;
                        MessageBox.Show(this, "Введите логин и пароль", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (pod_l.Length == 0)
                        {
                            q2 = true;
                            MessageBox.Show(this, "Введите логин", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            if (pod_p.Length == 0)
                            {
                                q2 = true;
                                MessageBox.Show(this, "Введите пароль", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                admin = DateManager.AdminRepository.CheckAdmin(login, password);
                                actor = DateManager.ActorRepository.CheckActor(login, password);
                            }
                }
                else q1 = true;

                if (actor)
                {
                    Game ActF = new Game(login);
                    ActF.ShowDialog(this);
                    q1 = true;
                }
                else
                    if (admin)
                    {
                        AdminPanel ActD = new AdminPanel();
                        ActD.ShowDialog(this);
                        q1 = true;
                    }
                    else
                        if (!q1 && !q2) MessageBox.Show(this, "Неверный Логин или Пароль , попробуйте еще раз", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AuthOrRegPanel f = new AuthOrRegPanel();
            bool q1 = false;
            bool q2 = false;
            bool actor = false;
            string login= "";
            string password = "";

            while (!q1)
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    login = f.GetName;
                    password = f.GetPassword;

                    string pod_l = login.Trim();
                    string pod_p = password.Trim();

                    if (pod_l.Length == 0 && pod_p.Length == 0)
                    {
                        q2 = true;
                        MessageBox.Show(this, "Введите логин и пароль", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (pod_l.Length == 0)
                        {
                            MessageBox.Show(this, "Введите логин", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            if (pod_p.Length == 0)
                            {
                                MessageBox.Show(this, "Введите пароль", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                actor = DateManager.ActorRepository.CheckActor(f.GetName);
                                if (!actor)
                                {
                                    DateManager.ActorRepository.AddActor(login, password, 1);
                                    q2 = true;
                                    q1 = true;
                                }
                                else MessageBox.Show(this, "Такой Логин уже существует , попробуйте другой", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                }
                else q1 = true;
            }

            if (q2)
            {
                Game GameForm = new Game(login);
                GameForm.ShowDialog(this);
            }
        }


    }
}
