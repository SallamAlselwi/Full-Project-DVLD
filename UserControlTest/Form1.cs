using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_OnCalck(string obj)
        {
            //MessageBox.Show(obj + " Nice");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(textBox1.Text);
            frm.DataBack += TotextBox; 
            frm.ShowDialog();
        }

        public void TotextBox(string obj)
        {
            textBox1.Text = obj;
        }
    }
}
