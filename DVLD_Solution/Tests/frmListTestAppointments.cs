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

namespace DVLD_Solution.Tests
{
    public partial class frmListTestAppointments : Form
    {
        clsLDLApplicationsBusiness LDL;
        public frmListTestAppointments(int LDLAppID)
        {
            InitializeComponent();
            
            LDL = clsLDLApplicationsBusiness.FindByLocalDrivingAppLicenseID(LDLAppID);
        }

        void LodeData()
        {
            if (LDL == null)
            {
                switch ()
                {

                }
            }
        }
    }
}
