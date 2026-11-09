using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business_Layer;
using DVLD_Solution.Properties;

namespace DVLD_Solution
{
    public partial class PersonDetails : Form
    {
        //clsPeopleBusiness person;
        public PersonDetails()
        {
            InitializeComponent();
        }
        public PersonDetails(int ID)
        {
            InitializeComponent();

            ucPersonDetails1.Loading(ID);

        }
        public PersonDetails(string NationalNo)
        {
            InitializeComponent();

            ucPersonDetails1.Loading(NationalNo);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
