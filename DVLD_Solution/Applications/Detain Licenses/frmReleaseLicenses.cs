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
    public partial class frmReleaseLicenses : Form
    {
        public clsLDLApplicationsBusiness ReleaseApplication;
        public clsDetainedLicenses DetainedLicenses;

        int _LocalLicenseID = -1;
        int _RewApplicationID = -1;
        int _PersonID = -1;
        int _LicenseID = -1;

        public frmReleaseLicenses(int LicenseID = -1)
        {
            InitializeComponent();
            this._LicenseID = LicenseID;
        }
        void LoadData()
        {
            labDetainID.Text = DetainedLicenses.DetainID.ToString();
            labDetainDate.Text = clsFormat.DateToShort(DetainedLicenses.DetainDate);
            labApplicationFees.Text = clsApplicationTypesBusiness.Find((int)clsApplicationBusiness.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();
            labLicenseID.Text = DetainedLicenses.LicenseID.ToString();
            labCreatedID.Text = clsUsersBusines.Find(DetainedLicenses.CreatedByUserID).UserName;
            labFineFees.Text = DetainedLicenses.FineFees.ToString();

            labTotalFees.Text = (Convert.ToDecimal(labApplicationFees.Text) + DetainedLicenses.FineFees).ToString();
        }
        void DataLoadApplication()
        {
            ReleaseApplication = new clsLDLApplicationsBusiness();
            
            ReleaseApplication.ApplicationPersonID = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID).PersonID;
            ReleaseApplication.ApplicationStatus = clsApplicationBusiness.Status.Completed;
            ReleaseApplication.LastStatusDate = DateTime.Now;
            ReleaseApplication.LicenseClassID = ucSearchLicense1.Licenses.LicenseClass;
            ReleaseApplication.ApplicationDate = ucSearchLicense1.Licenses.IssueDate;
            ReleaseApplication.CreatedByUserID = clsGlobal.user.UserID;
            ReleaseApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.ReleaseDetainedDrivingLicsense;
        }
        void DataDetainedLicenses()
        {
            DetainedLicenses.ReleaseApplicationID = ReleaseApplication.ApplicationID;
            DetainedLicenses.ReleaseDate = DateTime.Now;
            DetainedLicenses.ReleasedByUserID = clsGlobal.user.UserID;
            DetainedLicenses.IsReleased = true;
        }

        private void frmInternationalLicensesApplication_Load(object sender, EventArgs e)
        {
            if(_LicenseID != -1)
            {
                ucSearchLicense1.txtLicenseID.Text = _LicenseID.ToString();
                ucSearchLicense1.btnSearch_Click(null, null);
                ucSearchLicense1.gbFilters.Enabled = false;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            DataLoadApplication();

            if (ReleaseApplication.Save())
            {
                //DetainedLicenses = new clsDetainedLicenses();
                DataDetainedLicenses();

                if(DetainedLicenses.Save())
                {
                    labApplicationID.Text = ReleaseApplication.ApplicationID.ToString();

                    MessageBox.Show("Detained Licenses Released Successfully", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labLinkShowLicensesInfo.Enabled = true;
                    btnRelease.Enabled = false;

                    _LocalLicenseID = ucSearchLicense1.Licenses.LicenseID;
                }
                else
                    MessageBox.Show("Faild Released License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Faild to Released Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ucSearchLicense1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            labLicenseID.Text = SelectedLicenseID.ToString();

            labLinkShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            DetainedLicenses = clsDetainedLicenses.FindByLicenseID(SelectedLicenseID);
            

            if (DetainedLicenses == null)
            {
                MessageBox.Show(@"Selected License is not Detained, Choose another one", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                btnRelease.Enabled = false;
                return;
            }
            
            _PersonID = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID).PersonID;
            LoadData();
            
            if (DetainedLicenses.IsReleased)
            {
                MessageBox.Show(@"Selected License is not Detained, Choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                btnRelease.Enabled = false;
                return;
            }
            
            btnRelease.Enabled = true;
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
