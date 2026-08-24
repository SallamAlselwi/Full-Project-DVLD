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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD_Solution
{
    public partial class AddEditNewUser : Form
    {
        clsUsersBusines user;
        string title = "AddNew User";
        public AddEditNewUser()
        {
            InitializeComponent();
            
            user = new clsUsersBusines();
        }
        public AddEditNewUser(int UserID)
        {
            InitializeComponent();

            this.user = clsUsersBusines.Find(UserID);
            _FillFields();
        }
        void _FillFields()
        {
            searchPerson.Loading(this.user.PersonID);

            labUserID.Text = this.user.UserID.ToString();
            txtUserName.Text = this.user.UserName;
            txtConfirmPassword.Text = this.user.Password;
            txtPassword.Text = this.user.Password;

            checkboxIsActive.Checked = this.user.IsActive;

            labAddEidit.Text = "Update User";
            this.Text = "Update User";
            title = "Update User";

            tabControl1.SelectedTab = tabpLoginInfo;
        }
        bool _CheckPassword()
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(searchPerson.personDetails.person != null)
            {
                if (!clsUsersBusines.IsUserExist(searchPerson.personDetails.person.PersonID))
                {
                    tabControl1.SelectedTab = tabpLoginInfo;
                }
                else
                {
                    MessageBox.Show("Selected Person already has a user, Choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Choose Person to Make it User", title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text))
            {

                if (_CheckPassword())
                {
                    user.Person   = searchPerson.personDetails.person;
                    user.UserName = txtUserName.Text;
                    user.Password = txtPassword.Text;
                    user.IsActive = checkboxIsActive.Checked;

                    user.Save();

                    labUserID.Text = user.UserID.ToString();

                    if(user.UserID > 0)
                        MessageBox.Show($"Succesfully {title}", title, MessageBoxButtons.OK,MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Unsuccesfully", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Password is not the same", "False Match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    
            }
            else
            {
                MessageBox.Show("Fill UserName", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (!clsUsersBusines.IsUserNameExist(txtUserName.Text))
            {
                label6.Visible = false;
            }
            else
            {
                label6.Visible = true;

            }

            //if (clsUsersBusines.IsUserNameExist(txtUserName.Text))
            //{
            //    label6.Visible = true;
            //    txtUserName.Focus();
            //}
            //else
            //{
            //    label6.Visible = false;
            //}
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (_CheckPassword())
            {
                label7.Visible = false;
            }
            else
            {
                label7.Visible = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
