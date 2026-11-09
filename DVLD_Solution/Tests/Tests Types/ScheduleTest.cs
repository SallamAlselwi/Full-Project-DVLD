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
    public partial class ScheduleTest : Form
    {
        int DLAppID;
        clsTestTypesBusiness.enTestType TestType;
        clsLDLApplicationsBusiness LDL;
        clsTestAppointmentsBusiness TestAppointment;
        public ScheduleTest(int DLAppID, clsTestTypesBusiness.enTestType TestType)
        {
            InitializeComponent();

            this.DLAppID = DLAppID;
            this.TestType = TestType;
        }

        void LoadData()
        {
            LDL = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(DLAppID);

            labDLAppID.Text = LDL.LocalDrivingLicenseApplicationID.ToString();
            labClassName.Text = clsLicenseClassesBusiness.Find(LDL.LicenseClassID).ClassName;
            labPersonName.Text = LDL.ApplicantFullName;
            //labTrial.Text =
            labFees.Text = clsLicenseClassesBusiness.Find(LDL.LicenseClassID).ClassFees.ToString();


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
            TestAppointment = new clsTestAppointmentsBusiness();

            TestAppointment.TestTypeID = (int)TestType;
            TestAppointment.LocalDrivingLicenseApplicationID = LDL.LocalDrivingLicenseApplicationID;
            TestAppointment.AppointmentDate = dateTimePicker1.Value;
            TestAppointment.PaidFees = LDL.PaidFees;
            TestAppointment.CreatedByUserID = clsGlobal.user.UserID;

            if (TestAppointment.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Data Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
