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
    public partial class frmRenewDrivingLicense : Form
    {
        public clsLicensesBuisness LocalLicenses;
        public clsLDLApplicationsBusiness RenewApplication;

        int _LocalLicenseID = -1;
        int _RewApplicationID = -1;
        int _PersonID = -1;

        public frmRenewDrivingLicense()
        {
            InitializeComponent();

        }

        void LoadData()
        {
            LocalLicenses = new clsLicensesBuisness();
            RenewApplication = new clsLDLApplicationsBusiness();

            RenewApplication.ApplicationDate = Convert.ToDateTime(clsFormat.DateToShort(DateTime.Now));
            RenewApplication.PaidFees = clsLicenseClassesBusiness.Find(ucSearchLicense1.ucLicenseInfo1.License.LicenseClass).ClassFees;
            RenewApplication.CreatedByUserID = clsGlobal.user.UserID;

            LocalLicenses.IssueDate = Convert.ToDateTime(clsFormat.DateToShort(DateTime.Now));
            LocalLicenses.PaidFees = clsApplicationTypesBusiness.Find((int)clsApplicationBusiness.enApplicationType.RenewDrivingLicense).ApplicationFees;
            LocalLicenses.ExpirationDate = DateTime.Now.AddYears(clsLicenseClassesBusiness.Find(ucSearchLicense1.Licenses.LicenseClass).DefaultValidityLength);
            LocalLicenses.CreatedByUserID = clsGlobal.user.UserID;

            labOldLicenseID.Text = ucSearchLicense1.ucLicenseInfo1.License.LicenseID.ToString();
            labApplicationDate.Text = clsFormat.DateToShort(RenewApplication.ApplicationDate);
            labIssueDate.Text = clsFormat.DateToShort(LocalLicenses.IssueDate);
            labApplicationFees.Text = RenewApplication.PaidFees.ToString();
            labLicenseFees.Text = LocalLicenses.PaidFees.ToString();
            labExpirationDate.Text = clsFormat.DateToShort(LocalLicenses.ExpirationDate);
            labCreatedID.Text = LocalLicenses.CreatedByUserID.ToString();
            labTotalFees.Text = (LocalLicenses.PaidFees + RenewApplication.PaidFees).ToString();
        }

        private void frmInternationalLicensesApplication_Load(object sender, EventArgs e)
        {
            
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            
            clsDrivers driver = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID);

            RenewApplication.ApplicationPersonID = driver.PersonID;
            RenewApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.RenewDrivingLicense;
            RenewApplication.ApplicationStatus = clsApplicationBusiness.Status.Completed;
            RenewApplication.LastStatusDate = DateTime.Now;
            RenewApplication.LicenseClassID = ucSearchLicense1.Licenses.LicenseClass;


            
            if (RenewApplication.Save())
            {
                LocalLicenses.ApplicationID = RenewApplication.ApplicationID;
                LocalLicenses.DriverID = driver.DriverID;
                LocalLicenses.LicenseClass = ucSearchLicense1.Licenses.LicenseClass;
                LocalLicenses.Notes = richTextNotes.Text;

                LocalLicenses.IsActive = true;
                LocalLicenses.IssueReason = clsLicensesBuisness.enIssueReason.Renew;

                if(LocalLicenses.Save())
                {
                    clsLicensesBuisness license = clsLicensesBuisness.FindLicenseID(ucSearchLicense1.Licenses.LicenseID);
                    license.IsActive = false;
                    license.Save();
                    labRLApplicationID.Text = LocalLicenses.ApplicationID.ToString();
                    labRenewedLicenseID.Text = LocalLicenses.LicenseID.ToString();

                    MessageBox.Show("Local License Renew Successfully with ID = " + LocalLicenses.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labLinkShowLicensesInfo.Enabled = true;
                    _LocalLicenseID = LocalLicenses.LicenseID;
                }
                else
                    MessageBox.Show("Faild to Renew Local License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Faild to Renew Local License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
            if (ucSearchLicense1.Licenses.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($@"Selected License is not yet expiared, It will expire on: {clsFormat.DateToShort(ucSearchLicense1.Licenses.ExpirationDate)}", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                btnRenew.Enabled = false;
                return;
            }

            if (!ucSearchLicense1.Licenses.IsActive)
            {
                MessageBox.Show($@"This license is not Active!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            btnRenew.Enabled = true;
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
    }
}
