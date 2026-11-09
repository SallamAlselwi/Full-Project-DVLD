using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution.Tests.Controls
{
    public partial class UCDrivingLicenseApplicationInfo : UserControl
    {
        int PersonID = 0;
        public clsLDLApplicationsBusiness LDL;
        public clsApplicationBusiness application;
        public UCDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int LocalDrivingLicenseApplicationID)
        {
            LDL = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LDL != null)
            {
                labDLAppID.Text = LDL.LocalDrivingLicenseApplicationID.ToString();
                labApplied.Text = clsLicenseClassesBusiness.Find(LDL.LicenseClassID).ClassName;
                labPassed.Text = LDL.GetPassedTestCount().ToString() + "/3";


                application = clsApplicationBusiness.FindBaseApplication(LDL.ApplicationID);
                
                labID.Text = application.ApplicationID.ToString();
                labStatus.Text = application.ApplicationStatus.ToString();
                labFees.Text = application.PaidFees.ToString();
                labType.Text = clsApplicationTypesBusiness.FindApplicationTypes(application.ApplicationTypeID).ApplicationTypeTitle.ToString();
                labApplicant.Text = application.ApplicantFullName.ToString();
                labDate.Text = application.ApplicationDate.ToString();
                labStatusDate.Text = application.LastStatusDate.ToString();
                labCreatedBy.Text = application.CreatedByUserID.ToString();

                PersonID = application.ApplicationPersonID;
            }
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonDetails personDetails = new PersonDetails(PersonID);

            personDetails.ShowDialog();
        }
    }
}
