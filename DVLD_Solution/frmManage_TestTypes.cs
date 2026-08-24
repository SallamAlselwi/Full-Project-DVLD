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
    public partial class frmManage_TestTypes : Form
    {
        public frmManage_TestTypes()
        {
            InitializeComponent();
        }
        
        DataTable dataTestTypes = new DataTable();
        void _LoadTestTypes()
        {
            dataTestTypes = clsTestTypesBusiness.GetAllTestTypes();

            labCount.Text = dataTestTypes.Rows.Count.ToString();

            dataGridView1.DataSource = dataTestTypes;
        }

        private void frmManage_TestTypes_Load(object sender, EventArgs e)
        {
            _LoadTestTypes();
        }

        private void eidtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frmUpdateApplicationTypes = new frmUpdateTestTypes(int.Parse(dataGridView1.CurrentRow.Cells["LicenseClassID"].Value.ToString()));

            frmUpdateApplicationTypes.ShowDialog();

            _LoadTestTypes();
        }
    }
}
