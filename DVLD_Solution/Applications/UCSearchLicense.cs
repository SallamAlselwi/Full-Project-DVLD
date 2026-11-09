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

namespace DVLD_Solution.Applications
{
    public partial class UCSearchLicense : UserControl
    {
        public clsLicensesBuisness Licenses;

        public UCSearchLicense()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int _LicenseID = -1;
        public void btnSearch_Click(object sender, EventArgs e)
        {
            Licenses = clsLicensesBuisness.FindLicenseID(int.Parse(txtLicenseID.Text));
            
            if (Licenses == null)
            {
                MessageBox.Show($"This License {txtLicenseID.Text} is not Find!", "Find", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (Licenses.LicenseClass != 3)
            //{
            //    MessageBox.Show(@"The license you entered is not the one required to obtain an international license. 
            //                        \nThe required license is 'Class 3 - Ordinary driving license'.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            ucLicenseInfo1.LoadDataByLicenseID(Licenses.LicenseID);
            _LicenseID = ucLicenseInfo1.License.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnLicenseSelected(_LicenseID);
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, null);
            }
        }

        private void UCSearchLicense_Load(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }
    }
}
