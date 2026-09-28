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
        public UCDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int LocalDrivingLicenseApplicationID)
        {
            clsLDLApplicationsBusiness LDL = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LDL != null)
            {
                labDLAppID.Text = LDL.LocalDrivingLicenseApplicationID.ToString();
                labApplied.Text = clsLicenseClassesBusiness.Find(LDL.LicenseClassID).ClassName;
                labPassed.Text = LDL.GetPassedTestCount().ToString() + "/3";


                clsApplicationBusiness application = clsApplicationBusiness.FindBaseApplication(LDL.ApplicationID);
                
                labID.Text = application.ApplicationID.ToString();
                labStatus.Text = application.ApplicationStatus.ToString();
                labFees.Text = application.PaidFees.ToString();
                labType.Text = application.ApplicationTypeID.ToString();
                labApplicant.Text = application.ApplicantFullName.ToString();
                labDate.Text = application.ApplicationDate.ToString();
                labStatusDate.Text = application.LastStatusDate.ToString();
                labCreatedBy.Text = application.CreatedByUserID.ToString();
            }
        }
    }
}
