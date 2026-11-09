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
    public partial class frmDetainLicenses : Form
    {
        public clsDetainedLicenses DetainedLicenses;

        int _LocalLicenseID = -1;
        int _RewApplicationID = -1;
        int _PersonID = -1;

        public frmDetainLicenses()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            labDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            labLicenseID.Text = ucSearchLicense1.Licenses.LicenseID.ToString();
            labCreatedID.Text = clsGlobal.user.UserName;
        }
        void DataDetainedLicenses()
        {
            DetainedLicenses.LicenseID = ucSearchLicense1.Licenses.LicenseID;
            DetainedLicenses.ReleaseDate = DateTime.Now;
            DetainedLicenses.FineFees = Convert.ToDecimal(txtFineFees.Text);
            DetainedLicenses.CreatedByUserID = clsGlobal.user.UserID;
            DetainedLicenses.IsReleased = false;
        }

        private void frmInternationalLicensesApplication_Load(object sender, EventArgs e)
        {
            
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(txtFineFees.Text == "")
            {
                MessageBox.Show("Enter The Fine Fess", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                txtFineFees.Focus();
                return;

            }

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            
            DetainedLicenses = new clsDetainedLicenses();
            
            DataDetainedLicenses();

            if(DetainedLicenses.Save())
            {
                labDetainID.Text = DetainedLicenses.DetainID.ToString();

                MessageBox.Show("Detained Licenses Released Successfully", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labLinkShowLicensesInfo.Enabled = true;
                btnDetain.Enabled = false;

                _LocalLicenseID = ucSearchLicense1.Licenses.LicenseID;
            }
            else
                MessageBox.Show("Faild Released License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
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

            clsDetainedLicenses DL = clsDetainedLicenses.FindByLicenseID(SelectedLicenseID);

            _PersonID = clsDrivers.FindByDriverID(ucSearchLicense1.Licenses.DriverID).PersonID;
            LoadData();
            
            if (DL != null && !DL.IsReleased)
            {
                MessageBox.Show(@"Selected License is already Detained, Choose another one", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                btnDetain.Enabled = false;
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
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

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
