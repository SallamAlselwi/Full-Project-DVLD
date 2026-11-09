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
        bool resultTest = false;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypesBusiness.enTestType testType)
        {
            InitializeComponent();

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestType = testType;
        }

        bool isLocked()
        {
            if(dataGridView1.Rows.Count<=0) 
                return true;
            
            return Convert.ToBoolean(dataGridView1.CurrentRow.Cells["isLocked"].Value);
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
            
            if(!isLocked())
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ScheduleTest scheduleTest;
            if(dataGridView1.Rows.Count<=0)
            { 
                scheduleTest = new ScheduleTest(LocalDrivingLicenseApplicationID, TestType); 
            }
            else
            {

                if (resultTest)
                {
                    MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                scheduleTest = new ScheduleTest(LocalDrivingLicenseApplicationID, TestType, -1, true);

            }
            

            scheduleTest.ShowDialog();
            LoadeTestType();

        }

        private void eiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt16(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);
            ScheduleTest scheduleTest = new ScheduleTest(LocalDrivingLicenseApplicationID, TestType, AppointmentID); 
            
            scheduleTest.ShowDialog();
            LoadeTestType();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt16(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);

            TakeTest takeTest = new TakeTest(LocalDrivingLicenseApplicationID, TestType, AppointmentID);
            
            takeTest.ShowDialog();
            clsTestsBusiness Test = clsTestsBusiness.FindByTestAppointmentID(AppointmentID);
            if(Test != null)
                resultTest = Convert.ToBoolean(Test.TestResult);
            LoadeTestType();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (isLocked())
                takeTestToolStripMenuItem.Enabled = false;
        }
    }
}
