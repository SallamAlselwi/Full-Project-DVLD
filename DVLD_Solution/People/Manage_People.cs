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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Solution
{
    public partial class Manage_People : Form
    {
        public Manage_People()
        {
            InitializeComponent();
        }
        
        DataTable dataTPeople;

        private async void Manage_People_Load(object sender, EventArgs e)
        {
            dataTPeople = await clsPeopleBusiness.GetAllPeople();

            dataGridView1.DataSource = dataTPeople;

            dataGridView1.Columns["Address"].Visible = false;

            label4.Text = dataGridView1.RowCount.ToString();

            comFilter.SelectedIndex = 0;
            comboboxMaleFemale.SelectedIndex = 0;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo();

            addEditPersonInfo.ShowDialog();

            Manage_People_Load(null, EventArgs.Empty);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {

            }
        }

        private void showDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetails personDetails = new PersonDetails(int.Parse(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString()));

            personDetails.ShowDialog();

            Manage_People_Load(null, EventArgs.Empty);


        }

        private void eidtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo(int.Parse(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString()));

            addEditPersonInfo.ShowDialog();

            Manage_People_Load(null, EventArgs.Empty);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Deletion in The Database", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";

            if(dataTPeople != null)
                if (comFilter.SelectedItem.ToString() == "Gendor")
                {
                    comboboxMaleFemale.SelectedIndex = 0;

                    textBox1.Visible = false;
                    comboboxMaleFemale.Visible = true;
                }
                else if (comFilter.SelectedIndex >= 1)
                {
                    comboboxMaleFemale.SelectedIndex = 0;
                    textBox1.Visible = true;
                    comboboxMaleFemale.Visible = false;

                    textBox1.Focus();
                }
                else
                {
                    comboboxMaleFemale.SelectedIndex = 0;

                    textBox1.Visible = false;
                    comboboxMaleFemale.Visible = false;
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comFilter.SelectedItem.ToString() != "PersonID")
            {
                if (textBox1.Text != "")
                {
                    DataRow[] rows = dataTPeople.Select($"{comFilter.SelectedItem} lIKE '{textBox1.Text}%'");
                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();

                }
                else
                    dataGridView1.DataSource = dataTPeople;
            }
            else if (comFilter.SelectedItem.ToString() == "PersonID")
            {
                if (textBox1.Text != "")
                {    
                    DataRow[] rows = dataTPeople.Select($"{comFilter.SelectedItem.ToString()} = {int.Parse(textBox1.Text)}");

                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                    dataGridView1.DataSource = dataTPeople;

            }
            //else if(comFilter.SelectedItem.ToString() == "Gendor")
            //{
            //    textBox1.AllowDrop = true;
            //    //textBox1.
            //}
            else
                dataGridView1.DataSource = dataTPeople;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "PersonID" || comFilter.SelectedItem.ToString() == "Phone")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
               
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboboxMaleFemale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comFilter.SelectedItem.ToString() == "Gendor")
            {
                DataRow[] rows = dataTPeople.Select($"Gendor = '{comboboxMaleFemale.SelectedItem.ToString()}'");

                if (rows.Length > 0)
                    dataGridView1.DataSource = rows.CopyToDataTable();
                 
                if (comboboxMaleFemale.SelectedItem.ToString() == "All")
                    dataGridView1.DataSource = dataTPeople;
                
            }
            
        }
    }
}
