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

namespace DVLD_Solution
{
    public partial class Main : Form
    {
        clsUsersBusines user;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_People managepeole = new Manage_People();

            managepeole.MdiParent = this;
            managepeole.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Users manageUsers = new Manage_Users();

            manageUsers.MdiParent = this;
            manageUsers.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are sure you are Leave?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsGlobal.user != null)
            {
                UserDetails userDetails = new UserDetails(clsGlobal.user.UserID);

                userDetails.ShowDialog();
            }

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.user != null)
            {
                frmChangePassword fmrChangePassword = new frmChangePassword(clsGlobal.user.UserID);

                fmrChangePassword.ShowDialog();
            }
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage_ApplicationTypes applicationTypes = new frmManage_ApplicationTypes();

            applicationTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frmLocal = new frmNewLocalDrivingLicenseApplication();

            frmLocal.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage_TestTypes applicationTypes = new frmManage_TestTypes();

            applicationTypes.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMange_LocalDrivingLicenseApplication LDLA = new frmMange_LocalDrivingLicenseApplication();

            LDLA.MdiParent = this;
            LDLA.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports reports = new frmReports();

            reports.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage_Drivers drivers = new frmManage_Drivers();
            drivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicensesApplication NewInternationalLicensesApplication = new frmNewInternationalLicensesApplication();

            NewInternationalLicensesApplication.ShowDialog();
        }

        private void internationalLicenseApplicetionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMangeInterNationalDrivingLicenseApplication MangeInterNationalDrivingLicenseApplication = new frmMangeInterNationalDrivingLicenseApplication();

            MangeInterNationalDrivingLicenseApplication.ShowDialog();
        }

        private void renewDrivingLienseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense frmRenewDrivingLicense = new frmRenewDrivingLicense();

            frmRenewDrivingLicense.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementLostDamagedLicense ReplacementLostDamagedLicense = new frmReplacementLostDamagedLicense();

            ReplacementLostDamagedLicense.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses ManageDetainedLicenses = new frmManageDetainedLicenses();

            ManageDetainedLicenses.ShowDialog();
        }

        private void releseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicenses DetainLicenses = new frmReleaseLicenses();

            DetainLicenses.ShowDialog();
        }

        private void detainLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicenses DetainLicenses = new frmDetainLicenses();

            DetainLicenses.ShowDialog();
        }
    }
}
