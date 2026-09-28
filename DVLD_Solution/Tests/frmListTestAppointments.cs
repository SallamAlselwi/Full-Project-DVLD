using DVLD_Business_Layer;
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

namespace DVLD_Solution.Tests
{
    public partial class frmListTestAppointments : Form
    {
        clsLDLApplicationsBusiness LDL;
        clsTestTypesBusiness.enTestType TestType;
        public frmListTestAppointments(int LDLAppID, clsTestTypesBusiness.enTestType testType)
        {
            InitializeComponent();
            
            LDL = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(LDLAppID);
            this.TestType = testType;
        }

        void LoadeTestType()
        {
            if (LDL != null)
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
            }
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            LoadeTestType();
            ucDrivingLicenseApplicationInfo1.LoadData(LDL.LocalDrivingLicenseApplicationID);
        }
    }
}
