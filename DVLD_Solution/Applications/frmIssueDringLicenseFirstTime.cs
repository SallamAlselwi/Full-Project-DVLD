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

namespace DVLD_Solution.Applications
{
    public partial class frmIssueDringLicenseFirstTime : Form
    {
        public frmIssueDringLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            ucDrivingLicenseApplicationInfo1.LoadData(LocalDrivingLicenseApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsDrivers Driver = new clsDrivers();

            Driver.PersonID = ucDrivingLicenseApplicationInfo1.application.ApplicationPersonID;
            Driver.CreatedDate = DateTime.Now.Date;
            Driver.CreatedByUserID = clsGlobal.user.UserID;

            if (Driver.Save())
            {
                clsLicensesBuisness License = new clsLicensesBuisness();

                License.ApplicationID = ucDrivingLicenseApplicationInfo1.application.ApplicationID;
                License.DriverID = Driver.DriverID;
                License.LicenseClass = ucDrivingLicenseApplicationInfo1.LDL.LicenseClassID;
                License.IssueDate = DateTime.Now.Date;
                License.ExpirationDate = Convert.ToDateTime(clsFormat.DateToShort(DateTime.Now.AddYears(clsLicenseClassesBusiness.Find(ucDrivingLicenseApplicationInfo1.LDL.LicenseClassID).DefaultValidityLength)));
                License.Notes = richTextBox1.Text;
                License.PaidFees = ucDrivingLicenseApplicationInfo1.application.PaidFees;
                License.IsActive = true;
                License.CreatedByUserID = clsGlobal.user.UserID;

                if (License.Save())
                {
                    MessageBox.Show("License Issued Successfully with License ID = " + License.LicenseID.ToString(), "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("License Was not Issued ! ", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
