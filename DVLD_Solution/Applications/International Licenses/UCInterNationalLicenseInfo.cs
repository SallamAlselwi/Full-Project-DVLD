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

namespace DVLD_Solution.Applications.International_Licenses
{
    public partial class UCInterNationalLicenseInfo : UserControl
    {
        public UCInterNationalLicenseInfo()
        {
            InitializeComponent();
        }

        public bool LoadDate(int InterNationalLicenseID)
        {
            clsInternationalLicenses InternationalLicenses = clsInternationalLicenses.Find(InterNationalLicenseID);

            if( InternationalLicenses == null )
            {
                return false;
            }
            
            clsPeopleBusiness Person = clsPeopleBusiness.Find(InternationalLicenses.DriverInfo.PersonID);
            clsLicensesBuisness License = clsLicensesBuisness.FindLicenseID(InternationalLicenses.InternationalLicenseID);
            
            labName.Text = InternationalLicenses.ApplicantFullName;
            labIntLicenseID.Text = InternationalLicenses.InternationalLicenseID.ToString();
            labLicenseID.Text = License.LicenseID.ToString();
            labNationalNo.Text = Person.NationalNo;
            labGendor.Text = Person.GenderTXT;
            if(Person.Gender == 0)
            {
                pictureGendor.Image = Resources.Male_512;
            }
            else
                pictureGendor.Image = Resources.Female_512;
            labIssueDate.Text = InternationalLicenses.IssueDate.ToString();
            labAppliactionID.Text = InternationalLicenses.ApplicationID.ToString();

            if (InternationalLicenses.IsActive)
                labIsActive.Text = "Yes";
            else
                labIsActive.Text = "No";
            labDateOfBirth.Text = Person.DateOfBirth.ToString();
            labDriverID.Text = License.DriverID.ToString();
            labExprirationDate.Text = InternationalLicenses.ExpirationDate.ToString();



            return true;
        }
    }
}
