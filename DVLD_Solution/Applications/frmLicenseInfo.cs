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
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int LDLAppID = -1, int LicenseID = -1)
        {
            InitializeComponent();

            if(LDLAppID != -1)
                ucLicenseInfo1.LoadDataByLDLAppID(LDLAppID);
            else if(LicenseID != -1)
                ucLicenseInfo1.LoadDataByLicenseID(LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
