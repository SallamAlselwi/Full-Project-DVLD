using DVLD_Business_Layer;
using DVLD_Solution.Applications;
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
    public partial class frmManage_Drivers : Form
    {
        public frmManage_Drivers()
        {
            InitializeComponent();
        }
        
        DataTable dataTDrivers;

        private async void LoadData()
        {
            dataTDrivers = await clsDrivers.GetAllDrivers();

            dataGridView1.DataSource = dataTDrivers;

            label4.Text = dataGridView1.RowCount.ToString();

            comFilter.SelectedIndex = 0;
        }

        private void showDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eidtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Deletion in The Database", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dataTDrivers != null)
                if (comFilter.SelectedIndex >= 1)
                {
                    textBox1.Text = "";
                    
                    textBox1.Visible = true;
                    textBox1.Focus();
                }
                else
                {
                    textBox1.Text = "";

                    textBox1.Visible = false;
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "NationalNo" || comFilter.SelectedItem.ToString() == "FullName")
            {
                if (textBox1.Text != "")
                {
                    DataRow[] rows = dataTDrivers.Select($"{comFilter.SelectedItem} lIKE '{textBox1.Text}%'");
                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();

                }
                else
                    dataGridView1.DataSource = dataTDrivers;
            }
            else if (comFilter.SelectedItem.ToString() == "PersonID" || comFilter.SelectedItem.ToString() == "DriverID")
            {
                if (textBox1.Text != "")
                {    
                    DataRow[] rows = dataTDrivers.Select($"{comFilter.SelectedItem.ToString()} = {int.Parse(textBox1.Text)}");

                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                    dataGridView1.DataSource = dataTDrivers;

            }
            else
                dataGridView1.DataSource = dataTDrivers;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "PersonID" || comFilter.SelectedItem.ToString() == "DriverID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManage_Drivers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt16(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString());

            frmLicenseHistory LicenseHistory = new frmLicenseHistory(PersonID);

            LicenseHistory.ShowDialog();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(null, null);
        }
    }
}
