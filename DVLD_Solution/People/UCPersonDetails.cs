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

namespace DVLD_Solution
{
    public partial class UCPersonDetails : UserControl
    {
        public clsPeopleBusiness person;
        public UCPersonDetails() 
        {
            InitializeComponent();
            
            DeleteInfo();
        }
        bool _FillFields()
        {
            if (person != null)
            {
                labID.Text = person.PersonID.ToString();
                labName.Text = person.FullName;
                labNationalNO.Text = person.NationalNo;
                labGender.Text = person.GenderTXT;
                labEmail.Text = person.Email;
                labAddress.Text = person.Address;
                labDate.Text = person.DateOfBirth.ToString();
                labPhone.Text = person.Phone;
                labCountry.Text = person.CountryInfo.CountryName.ToString();

                if (person.ImagePath != null)
                    pctImage.ImageLocation = person.ImagePath;
                else
                    pctImage.Image = (person.Gender == 0) ? Resources.Male_512 : Resources.Female_512;
                return true;
            }
            else
                return false;
        }
        public void DeleteInfo()
        {
            person = null;
            labID.Text = "[????]";
            labNationalNO.Text = "[????]";
            labName.Text = "[????]";
            labGender.Text = "[????]";
            labEmail.Text = "[????]";
            labAddress.Text = "[????]";
            labDate.Text = "[????]";
            labPhone.Text = "[????]";
            labCountry.Text = "[????]";
        }

        public bool Loading(int ID)
        {
            this.person = clsPeopleBusiness.Find(ID);

            return _FillFields();
        }
        public bool Loading(string NationalNo)
        {
            this.person = clsPeopleBusiness.Find(NationalNo);

            return _FillFields();
        }
        public bool Loading(clsPeopleBusiness person)
        {
            this.person = person;

            return _FillFields();
        }

        private void btnEditPersonInfo_Click(object sender, EventArgs e)
        {
            if (person == null)
                return;
            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo(person.PersonID);

            addEditPersonInfo.ShowDialog();
        }
    }
}
