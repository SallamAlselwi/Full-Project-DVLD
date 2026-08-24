using DVLD_Business_Layer;
using DVLD_Solution.Properties;
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

    public partial class UCUserDetails : UserControl
    {
        public clsUsersBusines user;
        public UCUserDetails()
        {
            InitializeComponent();
        }
        void _DeleteInfo()
        {
            user = null;
            labUserID.Text = "[????]";
            labUserName.Text = "[????]";
            labIsActive.Text = "[????]";
        }
        public bool Loading(int UserID)
        {
            bool isLoading = false;
            
            this.user = clsUsersBusines.Find(UserID);

            if (user != null)
            {
                ucPersonDetails1.Loading(user.PersonID);

                labUserID.Text = user.UserID.ToString();
                labUserName.Text = user.UserName;
                labIsActive.Text = user.IsActive.ToString();

                isLoading = true;
            }

            return isLoading;
        }
    }
}
