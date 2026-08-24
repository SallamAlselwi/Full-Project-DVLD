using DVLD_Business_Layer;
using DVLD_Solution.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution
{
    public partial class AddEditPersonInfo : Form
    {
        clsPeopleBusiness person;
        public AddEditPersonInfo(int ID = -1)
        {
            InitializeComponent(); 
            
            DateOfBith.MaxDate = DateTime.Today.AddYears(-18);

            cmCountry.DataSource = clsCountriesBusiness.GetCountries();
            cmCountry.ValueMember = "CountryID";
            cmCountry.DisplayMember = "CountryName";

            if (ID > 0)
            { 
                this.person = clsPeopleBusiness.Find(ID);
                
                FullTheTextBox();
                
            }
            else
            {
                person = new clsPeopleBusiness();
                cmCountry.SelectedIndex = 190; 
            }

        }

        public delegate void DataBackHandler(int PersonID);
        public event DataBackHandler DataBack;

        byte gender = 0;

        string checkNationsalNo = "";

        bool IsAllDataFill()
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                MessageBox.Show("This Field is Required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFirstName.Focus();
                return false;
            }
            else if(string.IsNullOrWhiteSpace(tbSecondName.Text))
            {
                MessageBox.Show("This Field is Required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSecondName.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                MessageBox.Show("This Field is Required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbLastName.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(tbNationsalNo.Text))
            {
                MessageBox.Show("This Field is Required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNationsalNo.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(tbAdress.Text))
            {
                MessageBox.Show("This Field is Required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbAdress.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("This Field is Required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPhone.Focus();
                return false;
            }
            else
                return true;
        }
        void FullTheTextBox()
        {
            label1.Text = "Update Person";

            labPersonID.Text = person.PersonID.ToString();
            tbNationsalNo.Text = person.NationalNo;
            tbFirstName.Text = person.FirstName;
            tbSecondName.Text = person.SecondName;
            tbThirdName.Text = person.ThirdName;
            tbLastName.Text = person.LastName;
            tbEmail.Text = person.Email;
            tbPhone.Text = person.Phone;
            DateOfBith.Value = person.DateOfBirth;
            gender = person.Gender;
            cmCountry.SelectedValue = person.CountryInfo.CountryID;

            if (person.Gender == 0)
                rdMale.Checked = true;
            else 
                rdFemale.Checked = true;

            if (person.Address != null)
                tbAdress.Text = person.Address;

            if (person.ImagePath != null)
            { 
                pctImage.ImageLocation = person.ImagePath;

                btnRemoveImage.Visible = true;
            }
            else
                pctImage.Image = (person.Gender == 0) ? Resources.Male_512 : Resources.Female_512;

        }
        void FullThePerson()
        {
            person.NationalNo = tbNationsalNo.Text;
            person.FirstName = tbFirstName.Text;
            person.SecondName = tbSecondName.Text;
            person.ThirdName = tbThirdName.Text;
            person.LastName = tbLastName.Text;
            person.Email = tbEmail.Text;
            person.Phone = tbPhone.Text;
            person.Address = tbAdress.Text;
            person.DateOfBirth = DateOfBith.Value;
            person.Gender = gender;
            person.NationalityCountryID = int.Parse(cmCountry.SelectedValue.ToString());

            if (pctImage.ImageLocation != null)
            {
                if (!pctImage.ImageLocation.Equals(person.ImagePath))
                {
                    string destination = "";
                    if (person.ImagePath != "")
                        File.Delete(person.ImagePath);

                    destination = @"D:\Programmer\Abu-Hadhoud\Stage 2\Level 19\DVLD_Solution\ProfilePicture\" + person.NationalNo + "_" + person.FirstName + "_" + person.LastName + Path.GetExtension(pctImage.ImageLocation);
                    File.Copy(pctImage.ImageLocation, destination, true);
                    person.ImagePath = pctImage.ImageLocation;
                    
                }
            }
            else
                person.ImagePath = null;



        }
        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
        }

        private void tbNationsalNo_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            
            if (clsPeopleBusiness.IsPersonExist(textBox.Text) /*&& person.PersonID < 0*/)
            {
                label17.Visible = true;
                checkNationsalNo = textBox.Text;
            }
            else
            {
                label17.Visible = false;
                textBox.Tag = "T";
            }
            
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TextBox = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if(pctImage.ImageLocation == null)
            if (radioButton.Checked)
            {
                if (radioButton.Text == "Male")
                {
                    pctImage.Image = Resources.Male_512;
                    gender = 0;
                }
                else
                {
                    pctImage.Image = Resources.Female_512;
                    gender = 1;
                }
            }
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            pctImage.ImageLocation = openFileDialog1.FileName;

            btnRemoveImage.Visible = true;

            openFileDialog1.FileName = "";
            //string path = openFileDialog1.FileName;
            //MessageBox.Show(openFileDialog1.FileName);
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pctImage.ImageLocation = null;

            if (rdMale.Checked)
            {
                pctImage.Image = Resources.Male_512;
            }
            else
            {
                pctImage.Image = Resources.Female_512;
            }

            btnRemoveImage.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(person.PersonID);

            person = null;

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsAllDataFill())
            {
                if (checkNationsalNo != tbNationsalNo.Text)
                {
                    FullThePerson();
                   
                    if (person.Save())
                        MessageBox.Show($"Succesfully {label1.Text.Remove(label1.Text.IndexOf(' '))}");
                    else
                        MessageBox.Show($"Unsuccesfully {label1.Text.Remove(label1.Text.IndexOf(' '))}");

                    labPersonID.Text = person.PersonID.ToString();
                }
                else
                {
                    MessageBox.Show($"The {checkNationsalNo} is Added Befor");
                }

            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if(tbEmail.Text != "")
            {
                if (!tbEmail.Text.Contains('@') || !tbEmail.Text.Contains(".com"))
                    label3.Visible = true;
                else
                    label3.Visible = false;
            }
            else
                label3.Visible = false;
        }
    }
}
