using DVLD_Business_Layer;
using DVLD_Business_Layer.Tests;
using DVLD_Solution.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution.Tests.Tests_Types
{
    public partial class TakeTest : Form
    {
        int DLAppID;
        int AppointmentID;
        clsTestTypesBusiness.enTestType TestType;
        clsLDLApplicationsBusiness LDL;
        clsTestAppointmentsBusiness TestAppointment;
        clsTestsBusiness Test;

        public TakeTest(int DLAppID, clsTestTypesBusiness.enTestType TestType, int AppointmentID)
        {
            InitializeComponent();

            this.DLAppID = DLAppID;
            this.TestType = TestType;
            this.AppointmentID = AppointmentID;
        }

        void LoadData()
        {
            LDL = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(DLAppID);

            labDLAppID.Text = LDL.LocalDrivingLicenseApplicationID.ToString();
            labClassName.Text = clsLicenseClassesBusiness.Find(LDL.LicenseClassID).ClassName;
            labPersonName.Text = LDL.ApplicantFullName;
            //labTrial.Text =

            if (AppointmentID > 0)
            {
                TestAppointment = clsTestAppointmentsBusiness.FindTestAppointment(AppointmentID, LDL.LocalDrivingLicenseApplicationID);
                labFees.Text = TestAppointment.PaidFees.ToString();

                labDate.Text = (TestAppointment.AppointmentDate.ToString());
            }
        }

        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            switch (this.TestType)
            {
                case clsTestTypesBusiness.enTestType.Vision:
                    groupBox1.Text = "Vision Test";
                    pictureTitel.Image = Resources.Vision_512;
                    break;

                case clsTestTypesBusiness.enTestType.Written:
                    groupBox1.Text = "Written Test";
                    pictureTitel.Image = Resources.Written_Test_512;
                    break;

                case clsTestTypesBusiness.enTestType.PracticalStreet:
                    groupBox1.Text = "Street Test";
                    pictureTitel.Image = Resources.driving_test_512;
                    break;

            }

            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.", "Confirm", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
                )
            { 
                return;
            }

            Test = new clsTestsBusiness();

            Test.TestAppointmentID = AppointmentID;
            Test.Notes = richTextBox1.Text;
            Test.CreatedByUserID = clsGlobal.user.UserID;
            
            if(radioPass.Checked)
                Test.TestResult = true;
            else if(radioFail.Checked)
                Test.TestResult = false;

            if (Test.Save())
            {
                TestAppointment.IsLocked = true;
                TestAppointment.Save();
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labTakeTestID.Text = Test.TestID.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Data Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
