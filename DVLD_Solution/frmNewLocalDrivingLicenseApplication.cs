using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ucSearchPerson1.personDetails.person != null)
            {
                tabControl1.SelectedTab = tabpApplicationInfo;
                
                //if ()
                //{
                //    tabControl1.SelectedTab = tabpApplicationInfo;
                //}
                //else
                //{
                //    MessageBox.Show("Selected Person already has a ..., Choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else
            {
                MessageBox.Show("Choose Person to Make it User", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void NewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = clsLicenseClassesBusiness.GetAllLicenseClasses();

            comboBox1.DisplayMember = "ClassName";
            comboBox1.ValueMember = "ClassFees";

            comboBox1.SelectedIndex = 2;

            labFees.Text = comboBox1.SelectedValue.ToString();
            labApplicationDate.Text = DateTime.Now.ToString();
            labUserName.Text = clsGlobal.user.UserName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labFees.Text = comboBox1.SelectedValue.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ()
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
