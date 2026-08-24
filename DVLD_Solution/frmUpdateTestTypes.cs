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
    public partial class frmUpdateTestTypes : Form
    {
        clsTestTypesBusiness TestTypes;
        public frmUpdateTestTypes()
        {
            InitializeComponent();
        }
        public frmUpdateTestTypes(int TestTypeID)
        {
            InitializeComponent();

            this.TestTypes = clsTestTypesBusiness.FindTestTypes(TestTypeID);

            labID.Text = TestTypes.TestTypeID.ToString();
            txtTitle.Text = TestTypes.TestTypeTitle;
            txtrichDescription.Text = TestTypes.TestTypeDescription;
            txtFees.Text = TestTypes.TestTypeFees.ToString();
        }

        bool _ChackChange()
        {
            if (txtFees.Text != TestTypes.TestTypeFees.ToString() || txtTitle.Text != TestTypes.TestTypeTitle || txtrichDescription.Text != TestTypes.TestTypeDescription)
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
                TestTypes.TestTypeTitle = txtTitle.Text;
                TestTypes.TestTypeDescription = txtrichDescription.Text;
                TestTypes.TestTypeFees = Convert.ToDecimal(txtFees.Text);

                if (TestTypes.Save())
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
