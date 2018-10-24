using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Maximum = 100;
            progressBar1.Maximum = 100;
            progressBar1.Value = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = int.Parse(txtLoopCount.Text);
            progressBar1.Step = int.Parse(txtLoopCount.Text) / 100;
            for(int i = 0; i <= int.Parse(txtLoopCount.Text); i++)
            {
                progressBar1.Value = i;
            }
        }
    }
}
