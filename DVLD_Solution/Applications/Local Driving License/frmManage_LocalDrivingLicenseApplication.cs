using DVLD_Business_Layer;
using DVLD_Solution.Applications;
using DVLD_Solution.Tests;
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
    public partial class frmMange_LocalDrivingLicenseApplication : Form
    {
        DataTable DTApplications;
        public frmMange_LocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            DTApplications = clsLDLApplicationsBusiness.GetLDLApplicationsTypes();

            dataGridView1.DataSource = DTApplications;

            labCountRecords.Text = DTApplications.Rows.Count.ToString();

            comFilter.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmMange_LocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comFilter.SelectedItem.ToString() != "L.D.L.AppID")
            {
                if (textBox1.Text != "")
                {
                    DataRow[] rows = DTApplications.Select($"{comFilter.SelectedItem} lIKE '{textBox1.Text}%'");
                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                    dataGridView1.DataSource = DTApplications;
            }
            else if (comFilter.SelectedItem.ToString() == "L.D.L.AppID")
            {
                if (textBox1.Text != "")
                {
                    DataRow[] rows = DTApplications.Select($"LocalDrivingLicenseApplicationID = {int.Parse(textBox1.Text)}");

                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                    dataGridView1.DataSource = DTApplications;

            }
            else
                dataGridView1.DataSource = DTApplications;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "L.D.L.AppID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frmLocal = new frmNewLocalDrivingLicenseApplication();

            frmLocal.ShowDialog();
            DTApplications = clsLDLApplicationsBusiness.GetLDLApplicationsTypes();
        }

        private void comFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DTApplications != null)
            {
                textBox1.Text = "";
                if (comFilter.SelectedItem.ToString() == "Status")
                {
                    textBox1.Visible = false;
                    comboBox1.Visible = true;
                    
                }
                else if(comFilter.SelectedIndex >= 1)
                {
                    comboBox1.Visible = false;
                    textBox1.Visible = true;
                    textBox1.Focus();
                }
                else
                {
                    comboBox1.Visible = false;
                    textBox1.Visible = false;

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != 0)
            {
                DataRow[] rows = DTApplications.Select($"Status Like '{comboBox1.SelectedItem.ToString()}'");

                if (rows.Length > 0)
                    dataGridView1.DataSource = rows.CopyToDataTable();
            }
            else
                dataGridView1.DataSource = DTApplications;
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = int.Parse(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString());
            
            clsLDLApplicationsBusiness LDLApp = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if(LDLApp != null)
            {
                if (LDLApp.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            string Status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();

            if(Status == "Cancelled")
            {
                toolStripMenuItem3.Enabled = false;
                CancelToolStripMenuItem.Enabled = false;
                return;
            }
            clsLDLApplicationsBusiness LDLA = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(int.Parse(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString()));
            if (clsLicensesBuisness.IsExist(LDLA.ApplicationID, LDLA.LicenseClassID))
            {
                eidtToolStripMenuItem.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                CancelToolStripMenuItem.Enabled = false;
                toolStripMenuItem3.Enabled = false;
                IssueDringLicenseToolStripMenuItem.Enabled = false;

                phoneCallToolStripMenuItem.Enabled = true;
                ShowLicenseToolStripMenuItem.Enabled = true;


                return;
            }

            toolStripMenuItem3.Enabled = true;
            CancelToolStripMenuItem.Enabled = true;

            int PassedTestCount = int.Parse(dataGridView1.CurrentRow.Cells["PassedTestCount"].Value.ToString());

            switch (PassedTestCount)
            {
                case 0: 
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                case 1: 
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                case 2: 
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                    break;
                case 3:
                    toolStripMenuItem3.Enabled = false;
                    IssueDringLicenseToolStripMenuItem.Enabled = true;
                    break;

                default:
                    break;
            }
                
        }

        void _ScheduleTest(clsTestTypesBusiness.enTestType TestType)
        {
            int ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            frmListTestAppointments listTestAppointments = new frmListTestAppointments(ID, TestType);

            listTestAppointments.ShowDialog();

            LoadData();
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypesBusiness.enTestType.Vision);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypesBusiness.enTestType.Written);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypesBusiness.enTestType.PracticalStreet);
        }

        private void IssueDringLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString());
            
            frmIssueDringLicenseFirstTime gg = new frmIssueDringLicenseFirstTime(id);

            gg.ShowDialog();

            clsLDLApplicationsBusiness LDLApp = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(id);

            if (clsLicensesBuisness.IsExist(LDLApp.ApplicationID, LDLApp.LicenseClassID))
            {
                LDLApp.Completed();
                LoadData();
            }

        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(int.Parse(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString()));

            frmLicenseInfo.ShowDialog();

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string National = dataGridView1.CurrentRow.Cells["NationalNo"].Value.ToString();
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(clsPeopleBusiness.Find(National).PersonID);

            LicenseHistory.ShowDialog();
        }
    }
}
