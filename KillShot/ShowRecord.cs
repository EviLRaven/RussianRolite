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
    public partial class ShowRecord : Form
    {
        public ShowRecord()
        {
            InitializeComponent();
            UpdateGrid();
        }

        public ShowRecord(string name)
        {
            InitializeComponent();
            bindingNavigatorAddNewItem.Visible = false;
            bindingNavigatorDeleteItem.Visible = false;
            toolStripButton1.Visible = false;
            UpdateGrid();
        }

        void UpdateGrid()
        {
            scoreSetBindingSource.DataSource = DateManager.ScoresRepository.List;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddOrEditRecord f = new AddOrEditRecord();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                DateManager.ScoresRepository.AddScores(f.GetOrSetName, f.GetOrSetPoint, 1);
                UpdateGrid();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Kill Shot 2.0",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var record = scoreSetBindingSource.Current as ScoreSet;
                var id_record = record.Id_score;
                DateManager.ScoresRepository.DeleteScore(id_record);
                UpdateGrid();
            }
            else MessageBox.Show("Багулина тут :(", "Kill Shot 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddOrEditRecord f = new AddOrEditRecord();

            var record = scoreSetBindingSource.Current as ScoreSet;
            var id_record = record.Id_score;

            f.GetOrSetName = record.Name;
            f.GetOrSetPoint = record.Points;

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                DateManager.ScoresRepository.AppScore(id_record, f.GetOrSetName, f.GetOrSetPoint);
                UpdateGrid();
            }
        }
    }
}
