using DVLD_Business_Layer;
using DVLD_Business_Layer.Tests;
using DVLD_Solution.Properties;
using DVLD_Solution.Tests.Tests_Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution.Tests
{
    public partial class frmListTestAppointments : Form
    {
        int LocalDrivingLicenseApplicationID;
        
        clsTestTypesBusiness.enTestType TestType;

        clsTestAppointmentsBusiness testAppointmen;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypesBusiness.enTestType testType)
        {
            InitializeComponent();

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestType = testType;
        }

        void LoadeTestType()
        {
            switch (this.TestType)
            {
                case clsTestTypesBusiness.enTestType.Vision:
                    labTitleTest.Text = "Vision Test Appointments";
                    this.Text = labTitleTest.Text;
                    pictureBoxTitle.Image = Resources.Vision_512;
                    break;

                case clsTestTypesBusiness.enTestType.Written:
                    labTitleTest.Text = "Written Test Appointments";
                    this.Text = labTitleTest.Text;
                    pictureBoxTitle.Image = Resources.Written_Test_512;
                    break;

                case clsTestTypesBusiness.enTestType.PracticalStreet:
                    labTitleTest.Text = "Street Test Appointments";
                    this.Text = labTitleTest.Text;
                    pictureBoxTitle.Image = Resources.driving_test_512;
                    break;
                    
            }

            ucDrivingLicenseApplicationInfo1.LoadData(LocalDrivingLicenseApplicationID);

            dataGridView1.DataSource = clsTestAppointmentsBusiness.GetAppointmentDates(LocalDrivingLicenseApplicationID, (int)TestType);

            labCountRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            LoadeTestType();

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            ScheduleTest scheduleTest = new ScheduleTest(LocalDrivingLicenseApplicationID, TestType);

            scheduleTest.ShowDialog();
            LoadeTestType();
        }
    }
}
