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

namespace DVLD_Solution
{
    public partial class Manage_Users : Form
    {
        public Manage_Users()
        {
            InitializeComponent();
        }
        
        DataTable dataTUsers;
        async void _LoadUsers()
        {
            dataTUsers = await clsUsersBusines.GetAllUsers();

            dataGridView1.DataSource = dataTUsers;

            label4.Text = dataTUsers.Rows.Count.ToString();
        }

        private void Manage_Users_Load(object sender, EventArgs e)
        {
            _LoadUsers();
            comFilter.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }
        
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditNewUser addEditUserInfo = new AddEditNewUser();

            addEditUserInfo.ShowDialog();

            _LoadUsers();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {

            }
        }

        private void showDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetails userDetails = new UserDetails(int.Parse(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString()));

            userDetails.ShowDialog();

        }

        private void eidtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditNewUser addEditNewUser = new AddEditNewUser(int.Parse(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString()));

            addEditNewUser.ShowDialog();
            _LoadUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Deletion in The Database", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dataTUsers != null)
            { 
                if(comFilter.SelectedItem.ToString() == "IsActive")
                {
                    textBox1.Visible = false;
                    comboBox1.Visible = true;
                }
                else if (comFilter.SelectedIndex >= 1)
                {
                    comboBox1.Visible = false;
                    textBox1.Visible = true;
                }
                else
                {
                    comboBox1.Visible = false;
                    textBox1.Visible = false;
                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (comFilter.SelectedItem.ToString() != "PersonID" && comFilter.SelectedItem.ToString() != "UserID")
            {
                if (textBox1.Text != "")
                {
                    DataRow[] rows = dataTUsers.Select($"{comFilter.SelectedItem} lIKE '{textBox1.Text}%'");
                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();

                }
                else
                dataGridView1.DataSource = dataTUsers;
            }
            else if (comFilter.SelectedItem.ToString() == "PersonID" && comFilter.SelectedItem.ToString() != "UserID")
            {
                if (textBox1.Text != "")
                {    
                    DataRow[] rows = dataTUsers.Select($"{comFilter.SelectedItem.ToString()} = {int.Parse(textBox1.Text)}");

                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                dataGridView1.DataSource = dataTUsers;

            }
            else
                dataGridView1.DataSource = dataTUsers;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "PersonID" || comFilter.SelectedItem.ToString() == "UserID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
               
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "IsActive")
            {
                DataRow[] rows = dataTUsers.Select($"{comFilter.SelectedItem.ToString()} = {(comboBox1.SelectedItem.ToString() == "Yes")}");

                if (rows.Length > 0)
                    dataGridView1.DataSource = rows.CopyToDataTable();
                
                if (comboBox1.SelectedItem.ToString() == "All")
                    dataGridView1.DataSource = dataTUsers;
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(int.Parse(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString()));
        
            frmChangePassword.ShowDialog();
        
        }
    }
}
