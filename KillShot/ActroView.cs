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
    public partial class ActroView : Form
    {
        public ActroView()
        {
            InitializeComponent();
            UpdateGrid();
        }

        void UpdateGrid()
        {
            actorSetBindingSource.DataSource = DateManager.ActorRepository.List;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddOrEditActor f = new AddOrEditActor();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                DateManager.ActorRepository.AddActor(f.GetOrSetLogin,f.GetOrSetPass,1);
                UpdateGrid();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddOrEditActor f = new AddOrEditActor();

            var actor = actorSetBindingSource.Current as ActorSet;
            var id_actor = actor.Id_actor;

            f.GetOrSetLogin = actor.Login;
            f.GetOrSetPass = actor.Passowrd;

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                DateManager.ActorRepository.AppActor(id_actor,f.GetOrSetLogin,f.GetOrSetPass);
                UpdateGrid();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Kill Shot 2.0",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var actor = actorSetBindingSource.Current as ActorSet;
                var id_actor = actor.Id_actor;
                DateManager.ActorRepository.DeleteActor(id_actor);
                UpdateGrid();
            }
            else MessageBox.Show("Багулина тут :(", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
