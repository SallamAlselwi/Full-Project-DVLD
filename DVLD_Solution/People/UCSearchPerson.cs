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
    public partial class UCSearchPerson : UserControl
    {
        public UCSearchPerson()
        {
            InitializeComponent();

            comFilter.SelectedIndex = 0;

            
        }
        public void Loading(int PersonID)
        {
            if (PersonID >= 0)
            {
                personDetails.Loading(PersonID);

                groupBox1.Enabled = false;
            }

        }
        void _DataBack(int PersonID)
        {
            personDetails.Loading(PersonID);
        }
        private void comFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;

            if (comFilter.SelectedIndex >= 1)
            {
                txtFilter.Visible = true;
                txtFilter.Focus();
            }
            else
            {
                txtFilter.Visible = false;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }

        private void btnShearchPerson_Click(object sender, EventArgs e)
        {
            if (comFilter.SelectedItem.ToString() != "None" && txtFilter.Text != "")
            {
                if (comFilter.SelectedItem.ToString() == "PersonID")
                {
                    if (!personDetails.Loading(int.Parse(txtFilter.Text)))
                    {
                        MessageBox.Show($"No Person with {comFilter.SelectedItem} = {txtFilter.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        personDetails.DeleteInfo();
                    }
                }
                else if (!personDetails.Loading(txtFilter.Text))
                {
                    MessageBox.Show($"No Person with {comFilter.SelectedItem} = {txtFilter.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    personDetails.DeleteInfo();
                }
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo();

            addEditPersonInfo.DataBack += _DataBack;
            addEditPersonInfo.ShowDialog();


        }
    }
}
