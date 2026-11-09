using DVLD_Business_Layer;
using DVLD_Solution.Applications;
using DVLD_Solution.Applications.International_Licenses;
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
    public partial class frmMangeInterNationalDrivingLicenseApplication : Form
    {
        DataTable DTInterNationalApplications;
        public frmMangeInterNationalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        async void LoadData()
        {
            DTInterNationalApplications = await clsInternationalLicenses.GetAllInternationalLicenses();

            dataGridView1.DataSource = DTInterNationalApplications;

            labCountRecords.Text = DTInterNationalApplications.Rows.Count.ToString();

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
                    DataRow[] rows = DTInterNationalApplications.Select($"{comFilter.SelectedItem} lIKE '{textBox1.Text}%'");
                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                    dataGridView1.DataSource = DTInterNationalApplications;
            }
            else if (comFilter.SelectedItem.ToString() == "L.D.L.AppID")
            {
                if (textBox1.Text != "")
                {
                    DataRow[] rows = DTInterNationalApplications.Select($"{comFilter.SelectedItem.ToString()} = {int.Parse(textBox1.Text)}");

                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                    dataGridView1.DataSource = DTInterNationalApplications;

            }
            else
                dataGridView1.DataSource = DTInterNationalApplications;
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
            frmNewInternationalLicensesApplication frmInterNational = new frmNewInternationalLicensesApplication();

            frmInterNational.ShowDialog();
            DTInterNationalApplications = clsLDLApplicationsBusiness.GetLDLApplicationsTypes();
        }

        private void comFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DTInterNationalApplications != null)
            {
                if(comFilter.SelectedItem.ToString() == "Status")
                {
                    textBox1.Visible = false;
                    comboBox1.Visible = true;
                }
                else if(comFilter.SelectedIndex >= 1)
                {
                    comboBox1.Visible = false;
                    textBox1.Visible = true;
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
                DataRow[] rows = DTInterNationalApplications.Select($"Status Like '{comboBox1.SelectedItem.ToString()}'");

                if (rows.Length > 0)
                    dataGridView1.DataSource = rows.CopyToDataTable();
            }
            else
                dataGridView1.DataSource = DTInterNationalApplications;
        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = clsInternationalLicenses.Find(int.Parse(dataGridView1.CurrentRow.Cells["InternationalLicenseID"].Value.ToString())).IssuedUsingLocalLicenseID;
           
            frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(-1, LicenseID);

            frmLicenseInfo.ShowDialog();

        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDrivers.FindByDriverID(int.Parse(dataGridView1.CurrentRow.Cells["DriverID"].Value.ToString())).PersonID;

            frmLicenseHistory LicenseHistory = new frmLicenseHistory(PersonID);

            LicenseHistory.ShowDialog();
        }

        private void showDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDrivers.FindByDriverID(int.Parse(dataGridView1.CurrentRow.Cells["DriverID"].Value.ToString())).PersonID;
           
            PersonDetails personDetails = new PersonDetails(PersonID);
            personDetails.ShowDialog();
        }
    }
}
