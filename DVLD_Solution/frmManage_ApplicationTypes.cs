using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business_Layer;

namespace DVLD_Solution
{
    public partial class frmManage_ApplicationTypes : Form
    {
        public frmManage_ApplicationTypes()
        {
            InitializeComponent();
        }
        
        DataTable dataTApplicationTypes = new DataTable();
        void _LoadApplicationTypes()
        {
            dataTApplicationTypes = clsApplicationTypesBusiness.GetAllApplicationTypes();

            labCount.Text = dataTApplicationTypes.Rows.Count.ToString();

            dataGridView1.DataSource = dataTApplicationTypes;
        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypes();
        }

        private void eidtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes frmUpdateApplicationTypes = new frmUpdateApplicationTypes(int.Parse(dataGridView1.CurrentRow.Cells["LicenseClassID"].Value.ToString()));

            frmUpdateApplicationTypes.ShowDialog();

            _LoadApplicationTypes();
        }
    }
}
