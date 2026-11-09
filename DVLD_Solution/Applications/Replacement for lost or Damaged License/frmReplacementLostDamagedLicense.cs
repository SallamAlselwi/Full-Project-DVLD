using DVLD_Business_Layer;
using DVLD_Solution.Tests.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution.Applications.International_Licenses
{
    public partial class frmReplacementLostDamagedLicense : Form
    {
        public clsLicensesBuisness LocalLicenses;
        public clsLDLApplicationsBusiness newApplication;

        int _LocalLicenseID = -1;
        int _RewApplicationID = -1;
        int _PersonID = -1;

        public frmReplacementLostDamagedLicense()
        {
            InitializeComponent();

        }

        void LoadData()
        {
            labOldLicenseID.Text = ucSearchLicense1.ucLicenseInfo1.License.LicenseID.ToString();
            labApplicationDate.Text = clsFormat.DateToShort(ucSearchLicense1.Licenses.IssueDate);
            labCreatedID.Text = clsGlobal.user.UserName;
        }
        void DataLoadApplication()
        {
            newApplication.ApplicationPersonID = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID).PersonID;
            newApplication.ApplicationStatus = clsApplicationBusiness.Status.Completed;
            newApplication.LastStatusDate = DateTime.Now;
            newApplication.LicenseClassID = ucSearchLicense1.Licenses.LicenseClass;
            newApplication.ApplicationDate = ucSearchLicense1.Licenses.IssueDate;
            newApplication.CreatedByUserID = clsGlobal.user.UserID;
        }
        void DataLoadLocalLicenses()
        {
            LocalLicenses.ApplicationID = newApplication.ApplicationID;
            LocalLicenses.DriverID = ucSearchLicense1.Licenses.DriverID;
            LocalLicenses.LicenseClass = ucSearchLicense1.Licenses.LicenseClass;
            LocalLicenses.IsActive = true;
            LocalLicenses.IssueDate = ucSearchLicense1.Licenses.IssueDate;
            LocalLicenses.ExpirationDate = ucSearchLicense1.Licenses.ExpirationDate;
            LocalLicenses.CreatedByUserID = clsGlobal.user.UserID;
        }
        private void frmInternationalLicensesApplication_Load(object sender, EventArgs e)
        {
            newApplication = new clsLDLApplicationsBusiness();
            LocalLicenses = new clsLicensesBuisness();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            DataLoadApplication();

            if (newApplication.Save())
            {
                DataLoadLocalLicenses();

                if (LocalLicenses.Save())
                {
                    clsLicensesBuisness license = clsLicensesBuisness.FindLicenseID(ucSearchLicense1.Licenses.LicenseID);
                    license.IsActive = false;
                    license.Save();

                    labRLApplicationID.Text = LocalLicenses.ApplicationID.ToString();
                    labRenewedLicenseID.Text = LocalLicenses.LicenseID.ToString();

                    MessageBox.Show("Licensed Replaced Successfully with ID = " + LocalLicenses.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    labLinkShowLicensesInfo.Enabled = true;
                    btnIssueReplacement.Enabled = false;
                    _LocalLicenseID = LocalLicenses.LicenseID;
                }
                else
                    MessageBox.Show("Faild to Replaced License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Faild to Replaced Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ucSearchLicense1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            labOldLicenseID.Text = SelectedLicenseID.ToString();

            labLinkShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            _PersonID = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID).PersonID;
            LoadData();

            radioDamagedLicense_CheckedChanged(null, null);

            if (!ucSearchLicense1.Licenses.IsActive)
            {
                MessageBox.Show($@"This license is not Active!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            btnIssueReplacement.Enabled = true;
        }

        private void labLinkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID == -1)
                return;

            frmLicenseHistory LicenseHistory = new frmLicenseHistory(_PersonID);

            LicenseHistory.ShowDialog();
        }

        private void labLinkShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_LocalLicenseID != -1)
            {
                frmLicenseInfo LicenseInfo = new frmLicenseInfo(-1, _LocalLicenseID);

                LicenseInfo.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if(radioDamagedLicense.Checked)
            {
                newApplication.PaidFees = clsLicenseClassesBusiness.Find((int)clsApplicationBusiness.enApplicationType.ReplaceDamagedDrivingLicense).ClassFees;
                newApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.ReplaceDamagedDrivingLicense;

                LocalLicenses.IssueReason = clsLicensesBuisness.enIssueReason.ReplacementForDamaged;

                labTitle.Text = "Replacement for Damaged License";
                labApplicationFees.Text = newApplication.PaidFees.ToString();
            }
            else if(radioLostLicense.Checked)
            {
                newApplication.PaidFees = clsLicenseClassesBusiness.Find((int)clsApplicationBusiness.enApplicationType.ReplaceLostDrivingLicense).ClassFees;
                newApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.ReplaceLostDrivingLicense;
                
                LocalLicenses.IssueReason = clsLicensesBuisness.enIssueReason.ReplacementForLost;

                labTitle.Text = "Replacement Lost Damaged License";
                labApplicationFees.Text = newApplication.PaidFees.ToString();
            }
        }
    }
}
