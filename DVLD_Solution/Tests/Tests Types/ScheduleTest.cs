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
        int AppointmentID;
        bool isRetake;
        clsTestTypesBusiness.enTestType TestType;
        clsLDLApplicationsBusiness LDL;
        clsTestAppointmentsBusiness TestAppointment;
        public ScheduleTest(int DLAppID, clsTestTypesBusiness.enTestType TestType, int AppointmentID = -1, bool isRetake = false)
        {
            InitializeComponent();

            this.DLAppID = DLAppID;
            this.TestType = TestType;
            this.AppointmentID = AppointmentID;
            this.isRetake = isRetake;
        }

        void LoadData()
        {
            LDL = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(DLAppID);

            labDLAppID.Text = LDL.LocalDrivingLicenseApplicationID.ToString();
            labClassName.Text = clsLicenseClassesBusiness.Find(LDL.LicenseClassID).ClassName;
            labPersonName.Text = LDL.ApplicantFullName;
            //labTrial.Text =
            labFees.Text = clsTestTypesBusiness.FindTestTypes((int)TestType).TestTypeFees.ToString();

            if (isRetake)
            {
                groupBox2.Enabled = true;

                labRAppFees.Text = clsApplicationTypesBusiness.FindApplicationTypes(7).ApplicationFees.ToString();
            }

            labTotalFees.Text = (Convert.ToDouble(labRAppFees.Text) + Convert.ToDouble(labFees.Text)).ToString();
            
            if (AppointmentID > 0)
            {
                TestAppointment = clsTestAppointmentsBusiness.FindTestAppointment(AppointmentID, LDL.LocalDrivingLicenseApplicationID);

                dateTimePicker1.Value = Convert.ToDateTime(TestAppointment.AppointmentDate);

                labFees.Text = TestAppointment.PaidFees.ToString();
                
                if (TestAppointment.IsLocked)
                {
                    label1.Visible = true;
                    btnSave.Enabled = false;
                    dateTimePicker1.Enabled = false;
                }
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
            if(AppointmentID < 0)
            {
                TestAppointment = new clsTestAppointmentsBusiness();

                TestAppointment.TestTypeID = (int)TestType;
                TestAppointment.LocalDrivingLicenseApplicationID = LDL.LocalDrivingLicenseApplicationID;
                TestAppointment.AppointmentDate = dateTimePicker1.Value;
                TestAppointment.PaidFees = int.Parse(labTotalFees.Text);
                TestAppointment.CreatedByUserID = clsGlobal.user.UserID;

                if (isRetake)
                {
                    TestAppointment.TestAppointmentID = (int)clsApplicationBusiness.enApplicationType.RetakeTest;
                }
            }
            else
            {
                TestAppointment.AppointmentDate = dateTimePicker1.Value;
            }

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
