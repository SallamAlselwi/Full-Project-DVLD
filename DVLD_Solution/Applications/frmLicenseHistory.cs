using DVLD_Business_Layer;
using DVLD_Solution.Applications.International_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution.Applications
{
    public partial class frmLicenseHistory : Form
    {
        int PersonID;
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();

            this.PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private async void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            ucPersonDetails1.Loading(this.PersonID);

            clsDrivers driver = clsDrivers.FindByPersonID(ucPersonDetails1.person.PersonID);

            dataGridViewLocal.DataSource = await clsLicensesBuisness.GetAllLicenses(driver.DriverID);
            labRecordsLocal.Text = dataGridViewLocal.RowCount.ToString();

            dataGridViewInternational.DataSource = await clsInternationalLicenses.GetAllInternationalLicenses(driver.DriverID);
            labRecordsInternational.Text = dataGridViewInternational.RowCount.ToString();
        }

        private void dataGridViewLocal_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewLocal == null)
                return;

            int LicenseID = Convert.ToInt16(dataGridViewLocal.CurrentRow.Cells["LicenseID"].Value.ToString());
            
            frmLicenseInfo LicenseInfo = new frmLicenseInfo(-1, LicenseID);

            LicenseInfo.ShowDialog();
        }

        private void dataGridViewInternational_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewInternational == null)
                return;

            frmDriverInterNationalInfo DriverInterNationalInfo = new frmDriverInterNationalInfo(Convert.ToUInt16(dataGridViewInternational.CurrentRow.Cells["InternationalLicenseID"].Value.ToString()));

            DriverInterNationalInfo.ShowDialog();
        }
    }
}
