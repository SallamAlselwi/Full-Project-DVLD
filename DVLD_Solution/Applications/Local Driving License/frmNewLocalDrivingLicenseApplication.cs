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
using static DVLD_Business_Layer.clsLDLApplicationsBusiness;

namespace DVLD_Solution
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        clsApplicationTypesBusiness applicationTypes;
        
        clsLDLApplicationsBusiness _LocalDrivingLicenseApplication;
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            applicationTypes = clsApplicationTypesBusiness.FindApplicationTypes(1);
        }

        private void FullApplication(int LicenseClassID)
        {
            _LocalDrivingLicenseApplication = new clsLDLApplicationsBusiness();

            _LocalDrivingLicenseApplication.ApplicationPersonID = ucSearchPerson1.personDetails.person.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplicationBusiness.Status.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(labFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.user.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ucSearchPerson1.personDetails.person != null)
            {
                tabControl1.SelectedTab = tabpApplicationInfo;
                
                //if ()
                //{
                //    tabControl1.SelectedTab = tabpApplicationInfo;
                //}
                //else
                //{
                //    MessageBox.Show("Selected Person already has a ..., Choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else
            {
                MessageBox.Show("Choose Person to Make it User", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void NewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = clsLicenseClassesBusiness.GetAllLicenseClasses();

            comboBox1.DisplayMember = "ClassName";
            comboBox1.ValueMember = "LicenseClassID";

            comboBox1.SelectedValue = 3;

            labFees.Text = clsLicenseClassesBusiness.Find(Convert.ToInt16(comboBox1.SelectedValue.ToString())).ClassFees.ToString();
            labApplicationDate.Text = DateTime.Now.ToString();
            labUserName.Text = clsGlobal.user.UserName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text != "System.Data.DataRowView")
                labFees.Text = clsLicenseClassesBusiness.Find(Convert.ToInt16(comboBox1.SelectedValue.ToString())).ClassFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int LicenseClassID = clsLicenseClassesBusiness.FindByDriverID(comboBox1.Text).LicenseClassID;
            int LicenseClassID = int.Parse(comboBox1.SelectedValue.ToString());

            int ActiveApplicationID = clsApplicationBusiness.GetActiveApplicationIDForLicenseClass(ucSearchPerson1.personDetails.person.PersonID, clsApplicationBusiness.enApplicationType.NewDrivingLicense, LicenseClassID);


            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }

            if (clsLicensesBuisness.IsLicenseExistByPersonID(ucSearchPerson1.personDetails.person.PersonID, LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FullApplication(LicenseClassID);

            if (_LocalDrivingLicenseApplication.Save())
            {
                labDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                /*//change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                */

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            /*if (id > 0)
            {
                MessageBox.Show($"Chooser another license Class, the selected Person Already have an active _LocalDrivingLicenseApplication for selected class with id={id}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            FullApplication();
            
            
            if(_LocalDrivingLicenseApplication.Save())
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Data Failed", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
