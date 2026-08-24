using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution
{
    public partial class frmChangePassword : Form
    {
        clsUsersBusines user;
        public frmChangePassword(int UserID = -1)
        {
            InitializeComponent();

            if(UserID > 0)
            {
                this.user = clsUsersBusines.Find(UserID);
                ucUserDetails1.Loading(user.UserID);
            } 
        }
        bool _CheckPassword()
        {
            if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCurrentPassword.Text == user.Password)
            {
                if (user.ChangePassword(txtNewPassword.Text, txtConfirmPassword.Text))
                {
                    MessageBox.Show("Successful Change Password","",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    txtConfirmPassword.Text = "";
                    txtCurrentPassword.Text = "";
                    txtNewPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Nusuccessful Change Password","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("The Current Password is not correct!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (_CheckPassword())
            {
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
            }
        }
    }
}
