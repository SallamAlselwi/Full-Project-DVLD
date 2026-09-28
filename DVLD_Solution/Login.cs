using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business_Layer;

namespace DVLD_Solution
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            _GetRemamberMe();
        }

        void _SaveRemamberMe()
        {
            StreamWriter streamWriter = new StreamWriter("Remamber me.txt");
            if (checkRemamber.Checked)
            {
                streamWriter.WriteLine(txtUserName.Text);
                streamWriter.WriteLine(txtPassword.Text);
            }
            else
            {
                streamWriter.WriteLine("");
                streamWriter.WriteLine("");
            }
            streamWriter.Close();
        }
        void _GetRemamberMe()
        {
            StreamReader streamReader = new StreamReader(@"Remamber me.txt");

            while (!streamReader.EndOfStream)
            {
                txtUserName.Text = streamReader.ReadLine();
                txtPassword.Text = streamReader.ReadLine();
            }
            streamReader.Close();
            if (txtUserName.Text != "")
                checkRemamber.Checked = true;
            streamReader.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobal.user = clsUsersBusines.GetUserByUserNameAndPassword(txtUserName.Text, txtPassword.Text);
            //clsUsersBusines user = clsUsersBusines.GetUserByUserNameAndPassword(txtUserName.Text, txtPassword.Text);

            if (clsGlobal.user != null)
            {
                _SaveRemamberMe();
                
                if(clsGlobal.user.IsActive)
                {
                    Main form1 = new Main();

                    txtUserName.Text = "";
                    txtPassword.Text = "";

                    this.Visible = false;

                    form1.ShowDialog();
                    
                    this.Visible = true;
                    _GetRemamberMe();

                }
                else
                {
                    MessageBox.Show("Invald Login, You aren't Active!\nContact your Manager", "Wrong Credinality", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else 
            {
                MessageBox.Show("Invald Username or Password!", "Wrong Credinality", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
