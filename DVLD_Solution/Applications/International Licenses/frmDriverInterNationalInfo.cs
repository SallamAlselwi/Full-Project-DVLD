using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Solution.Applications.International_Licenses
{
    public partial class frmDriverInterNationalInfo : Form
    {
        int InternationalLicenseID;
        public frmDriverInterNationalInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            this.InternationalLicenseID = InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverInterNationalInfo_Load(object sender, EventArgs e)
        {
            ucInterNationalLicenseInfo1.LoadDate(InternationalLicenseID);
        }
    }
}
