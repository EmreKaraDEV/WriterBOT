namespace WriterBOT
{
    public partial class Form1 : Form
    {
        /*
         WriterBOT, Powered By Emreki.
         A Open Source Project.
         WriterBOT is a BOT program that writes specified texts for entertainment purposes.
         Form1 has been created for you to accept the necessary terms of use before opening WriterBOT.

         WebSite = https://emreki.art.blog/
         GitHub = https://github.com/EmreKaraDEV
         YouTube = https://www.youtube.com/c/EmreKaraTV
         */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Requests the start of WriterBOT upon acceptance of the terms of use.
            if (checkBox1.Checked == true) {
                startWriterBOT();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*It is responsible for activating the necessary button to open WriterBOT
            within the acceptance of the terms of use.*/
            button1.Enabled = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Specifies that the application will be closed because the terms of use are rejected and closes it.
            MessageBox.Show("You cannot use WriterBOT because you don't accept the WriterBOT terms of use. If you do not accept the WriterBOT terms of use, delete the WriterBOT application completely. The application will be closed.", "Unable to start WriterBOT.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Properties.Settings.Default.isTermsDenied = true;
            Properties.Settings.Default.Save();
            /* When the terms of use are rejected, the application saves it. 
             * It provides a warning when the application is opened again.
             */
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             If we have not previously rejected the terms of use, the application will open normally. 
             But if we reach the save that we have previously rejected the terms of use, the application will warn us.
             */
            if (Properties.Settings.Default.isTermsDenied == true)
            {
                this.Visible = false;
                switch (MessageBox.Show("We have detected that you have rejected the WriterBOT terms of use. If you do not accept the terms of use, let's close the application again. If you have decided to accept the terms of use, the application will continue to work.\n\nWill you accept the WriterBOT terms of use ?", "You rejected the WriterBOT terms of use.", MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                {
                    case DialogResult.Yes: //If we indicate that we will accept the terms of use, the application will open.
                        this.Visible = true;
                        Properties.Settings.Default.isTermsDenied = false; //And it will forget that we reject the terms of use. :)
                        Properties.Settings.Default.Save();
                        break;
                    case DialogResult.No: //If we declare that we will reject the terms of use again, the application will be closed directly.
                        Environment.Exit(0);
                        break;
                }
            }
            else if(Properties.Settings.Default.isTermsOfUseCompletelyAccepted == true)
            {
                startWriterBOT();
            }
        }
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        private void startWriterBOT()
        {   //Indicates that the terms of use are accepted. It wait 3 seconds for the user to read this information.
            try
            {
                this.ControlBox = false;
                textBox1.Visible = false;
                checkBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                this.Size = new Size(433, 100);
                Label l = new Label();
                l.Text = "You have accepted the WriterBOT Terms of Use. Starting WriterBOT.";
                l.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(l);
                l.SetBounds(2, 10, 431, 30);
                t.Interval = 1000;
                t.Tick += T_Tick;
                t.Enabled = true;
            }
            catch
            {

            }
        }

        int second = 0;
        private void T_Tick(object? sender, EventArgs e)
        {
            try
            {
                second++;
                if (second >= 2)
                {
                    mainForm mf = new mainForm();
                    mf.Show();
                    this.Hide();
                    t.Enabled = false;
                }
            }
            catch
            {

            }
        }
    }
}