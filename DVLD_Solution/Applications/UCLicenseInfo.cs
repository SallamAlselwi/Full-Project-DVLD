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

namespace DVLD_Solution.Applications
{
    public partial class UCLicenseInfo : UserControl
    {
        public clsLicensesBuisness License;
        clsLDLApplicationsBusiness LDLApp;
        public UCLicenseInfo()
        {
            InitializeComponent();
        }
        void _LoadDate()
        {
            clsPeopleBusiness Person = clsPeopleBusiness.Find(LDLApp.ApplicationPersonID);
            if (Person == null)
            {
                return;
            }

            labClassName.Text = clsLicenseClassesBusiness.Find(LDLApp.LicenseClassID).ClassName;
            labPersonName.Text = LDLApp.ApplicantFullName;
            labLiceseID.Text = License.LicenseID.ToString();
            labNationalNo.Text = Person.NationalNo.ToString();
            labIssueDate.Text = clsFormat.DateToShort(License.IssueDate);
            labIssueReason.Text = License.IssueReason.ToString();
            labDateOfBirth.Text = Person.DateOfBirth.ToString();
            labDriverID.Text = License.DriverID.ToString();
            labExpirationDate.Text = clsFormat.DateToShort(License.ExpirationDate);

            if (License.Notes != null && License.Notes != "")
                labNotes.Text = License.Notes.ToString();
            else
                labNotes.Text = "No Notes";

            if (License.IsActive)
                labIsActive.Text = "Yes";
            else
                labIsActive.Text = "No";

            labIsDetained.Text = "No";

            labGender.Text = Person.GenderTXT.ToString();
            if (Person.Gender == 0)
            {
                pictureGender.Image = Resources.Man_32;
            }
            else
            {
                pictureGender.Image = Resources.Woman_32;
            }

            if (Person.ImagePath != null || Person.ImagePath != "")
            {
                picturePerson.ImageLocation = Person.ImagePath;
            }
            else
                picturePerson.Image = (Person.Gender == 0) ? Resources.Male_512 : Resources.Female_512;
            try
            {
                clsDetainedLicenses DetainedLicenses = clsDetainedLicenses.FindByLicenseID(License.LicenseID);
                if (DetainedLicenses != null && !DetainedLicenses.IsReleased)
                    labIsDetained.Text = "Yes";
                else
                    labIsDetained.Text = "No";
            }
            catch (Exception ex)
            {

            }
        }
        public void LoadDataByLDLAppID(int LDLAppID)
        {
            LDLApp = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(LDLAppID);
            if (LDLApp == null)
            {
                return;
            }

            License = clsLicensesBuisness.FindApplicationID(LDLApp.ApplicationID);
            if (License == null)
            {
                return;
            }

            _LoadDate();
        }
        public void LoadDataByLicenseID(int LicenseID)
        {
            License = clsLicensesBuisness.FindLicenseID(LicenseID);
            if(License == null )
            {
                return;
            }

            LDLApp = clsLDLApplicationsBusiness.FindByApplicationID(License.ApplicationID);
            if (LDLApp == null)
            {
                return;
            }

            _LoadDate();
        }
    }
}
