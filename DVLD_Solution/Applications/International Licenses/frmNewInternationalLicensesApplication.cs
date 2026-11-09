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
    public partial class frmNewInternationalLicensesApplication : Form
    {
        public clsInternationalLicenses InternationalLicenses;

        int _InternationalLicenseID = -1;
        int _PersonID = -1;

        public frmNewInternationalLicensesApplication()
        {
            InitializeComponent();

        }

        void LoadData()
        {
            clsApplicationBusiness App = clsApplicationBusiness.FindBaseApplication(6);
            InternationalLicenses = new clsInternationalLicenses();

            InternationalLicenses.ApplicationDate = Convert.ToDateTime(clsFormat.DateToShort(DateTime.Now));
            InternationalLicenses.IssueDate = Convert.ToDateTime(clsFormat.DateToShort(DateTime.Now));
            InternationalLicenses.PaidFees = clsApplicationTypesBusiness.Find((int)clsApplicationBusiness.enApplicationType.NewInternationalLicense).ApplicationFees;
            InternationalLicenses.ExpirationDate = Convert.ToDateTime(clsFormat.DateToShort(InternationalLicenses.IssueDate));
            InternationalLicenses.CreatedByUserID = clsGlobal.user.UserID;

            labApplicationDate.Text = InternationalLicenses.ApplicationDate.ToString();
            labIssueDate.Text = InternationalLicenses.IssueDate.ToString();
            labFees.Text = InternationalLicenses.PaidFees.ToString();
            labExpirationDate.Text = InternationalLicenses.ExpirationDate.ToString();
            labCreatedID.Text = InternationalLicenses.CreatedByUserID.ToString();
        }

        private void frmInternationalLicensesApplication_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if(ucSearchLicense1.Licenses.LicenseClass == 3)
            {
                clsDrivers driver = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID);

                InternationalLicenses.ApplicationPersonID = driver.PersonID;
                InternationalLicenses.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.NewInternationalLicense;
                InternationalLicenses.DriverID = driver.DriverID;
                InternationalLicenses.IssuedUsingLocalLicenseID = ucSearchLicense1.Licenses.LicenseID;
                InternationalLicenses.IsActive = true;
                InternationalLicenses.ExpirationDate.AddYears(clsLicenseClassesBusiness.Find(ucSearchLicense1.Licenses.LicenseClass).DefaultValidityLength);

                if (InternationalLicenses.Save())
                {
                    labILApplicationID.Text = InternationalLicenses.ApplicationID.ToString();
                    labLicenseID.Text = InternationalLicenses.InternationalLicenseID.ToString();

                    MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicenses.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labLinkShowLicensesInfo.Enabled = true;
                }
                else
                    MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(@"The license you entered is not the one required to obtain an international license. 
                                The required license is 'Class 3 - Ordinary driving license'.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void ucSearchLicense1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            labLocalLicenseID.Text = SelectedLicenseID.ToString();

            labLinkShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            //check the license class, person could not issue international license without having
            //normal license of class 3.


            if (ucSearchLicense1.Licenses.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(ucSearchLicense1.ucLicenseInfo1.License.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labLinkShowLicensesInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            _PersonID = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID).PersonID;
            btnIssue.Enabled = true;
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
            frmDriverInterNationalInfo frmDriverInterNationalInfo = new frmDriverInterNationalInfo(_InternationalLicenseID);

            frmDriverInterNationalInfo.ShowDialog();
        }
    }
}
