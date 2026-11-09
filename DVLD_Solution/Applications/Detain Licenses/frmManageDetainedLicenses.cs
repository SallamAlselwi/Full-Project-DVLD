using DVLD_Business_Layer;
using DVLD_Solution.Applications.International_Licenses;
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
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        
        DataTable DTDetainedReleases;
        async void _LoadData()
        {
            DTDetainedReleases = await clsDetainedLicenses.GetAllDetainedLicenses();

            dataGridView1.DataSource = DTDetainedReleases;

            label4.Text = dataGridView1.RowCount.ToString();

            comFilter.SelectedIndex = 0;
        }
        private void showDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetails personDetails = new PersonDetails(dataGridView1.CurrentRow.Cells["N.No"].Value.ToString());

            personDetails.ShowDialog();

            _LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DTDetainedReleases != null)
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
            if (comFilter.SelectedItem.ToString() != "L.ID" && comFilter.SelectedItem.ToString() != "D.ID")
            {
                if (textBox1.Text != "")
                {
                    DataRow[] rows = DTDetainedReleases.Select($"{comFilter.SelectedItem.ToString()} lIKE '{textBox1.Text}%'");
                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();

                }
                else
                    dataGridView1.DataSource = DTDetainedReleases;
            }
            else if (comFilter.SelectedItem.ToString() == "L.ID" || comFilter.SelectedItem.ToString() == "D.ID")
            {
                if (textBox1.Text != "")
                {    
                    DataRow[] rows = DTDetainedReleases.Select($"{comFilter.SelectedItem.ToString()} = {int.Parse(textBox1.Text)}");

                    if (rows.Length > 0)
                        dataGridView1.DataSource = rows.CopyToDataTable();
                }
                else
                    dataGridView1.DataSource = DTDetainedReleases;

            }
            else
                dataGridView1.DataSource = DTDetainedReleases;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comFilter.SelectedItem.ToString() == "D.ID" || comFilter.SelectedItem.ToString() == "L.ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
               
            }
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Is.Released"].Value.ToString()))
                return;

            frmReleaseLicenses ReleaseLicenses = new frmReleaseLicenses(int.Parse(dataGridView1.CurrentRow.Cells["L.ID"].Value.ToString()));

            ReleaseLicenses.ShowDialog();

            _LoadData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Is.Released"].Value.ToString()))
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
            else
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenses DetainLicenses = new frmDetainLicenses();

            DetainLicenses.ShowDialog();
        }
    }
}
