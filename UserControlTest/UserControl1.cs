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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public event Action<string> OnCalck;

        protected virtual void OnCalckEvent(string Name)
        {
            Action<string> handler = OnCalck;
            if (handler != null)
            { 
                handler(Name);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;

            if(OnCalck != null)
                OnCalckEvent((string)label1.Text);

        }
    }
}
