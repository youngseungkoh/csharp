using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Text = "Modal Windows";
            f.Width = 200;
            f.Height = 100;
            f.BackColor = Color.Blue;

            f.ShowDialog();
        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Text = "Modaless Windows";
            f.Width = 200;
            f.Height = 100;

            f.BackColor = Color.Black;

            f.Show();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("하하하", "메세지박스", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
