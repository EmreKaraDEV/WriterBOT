using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriterBOT
{
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
        }
        mainForm mf = new mainForm();
        private void options_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.isTermsOfUseCompletelyAccepted;
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Emreki Web
            Process.Start(new ProcessStartInfo("cmd", $"/c start {mf.getWebSite()}") { CreateNoWindow = true });
        }

        private void button2_Click(object sender, EventArgs e)
        {   //EmreKaraDEV GitHub
            Process.Start(new ProcessStartInfo("cmd", $"/c start {mf.getGitHub()}") { CreateNoWindow = true });
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Emreki YouTube Channel
            Process.Start(new ProcessStartInfo("cmd", $"/c start {mf.getYouTube()}") { CreateNoWindow = true });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mf.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {   
            Properties.Settings.Default.isTermsOfUseCompletelyAccepted = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
