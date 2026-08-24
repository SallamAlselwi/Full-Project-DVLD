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

namespace DVLD_Solution
{
    public partial class frmUpdateApplicationTypes : Form
    {
        clsApplicationTypesBusiness applicationTypes;
        public frmUpdateApplicationTypes()
        {
            InitializeComponent();
        }
        public frmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();

            this.applicationTypes = clsApplicationTypesBusiness.FindApplicationTypes(ApplicationTypeID);

            labID.Text = applicationTypes.ApplicationTypeID.ToString();
            txtTitle.Text = applicationTypes.ApplicationTypeTitle;
            txtFees.Text = applicationTypes.ApplicationFees.ToString();
        }

        bool _ChackChange()
        {
            if (txtFees.Text != applicationTypes.ApplicationFees.ToString() || txtTitle.Text != applicationTypes.ApplicationTypeTitle)
                return true;
            else
                return false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_ChackChange())
            {
                applicationTypes.ApplicationTypeTitle = txtTitle.Text;
                applicationTypes.ApplicationFees = Convert.ToDecimal(txtFees.Text);

                if (applicationTypes.Save())
                {
                    MessageBox.Show("Successfuly Updated","Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nonsuccessfuly Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nothing has Changed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
