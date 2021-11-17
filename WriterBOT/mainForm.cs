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
    public partial class mainForm : Form
    {
        /*
         WriterBOT, Powered By Emreki.
         A Open Source Project.
         WriterBOT is a BOT program that writes specified texts for entertainment purposes.
         This is the main part of the WriterBOT application. WriterBOT completes the requested task here.
         */

        //Don't forget to visit the links below and support me!
        private string WebSite = "https://emreki.art.blog/";
        private string GitHub = "https://github.com/EmreKaraDEV";
        private string YouTube = "https://www.youtube.com/c/EmreKaraTV";
        public string getWebSite() { return WebSite; }
        public string getGitHub() { return GitHub; }    
        public string getYouTube() { return YouTube; }
        
        public mainForm()
        {
            InitializeComponent();
        }

        //Basic
        private string version = "1.0 BETA"; //Version info
        private bool botActive = false; //Declares whether WriteBOT is currently running.

        //Textboxs (Lines) , Line Count, Max Line Count, New Textbox Location X, New Textbox Location Y
        private List<TextBox> txtBoxList = new List<TextBox>();
        private int txtBoxCount = 0, maxTxtBoxCount=1, txtBoxX = 12, txtBoxY = 185; //It is used when creating the textbox.

        //Timer: Second Time, Max Second Time, Delay Time(Before the WriterBOT process starts, it is wait for this period of time.)
        private int timeSecond, maxTimeSecond = 0, delayTime = 2;

        //It is used to decide whether to close the entire application when closing the mainForm.
        private bool closeAll = true;

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.Text = "WriterBOT " + version;

            //Saved settings are loads.
            workModeBox.SelectedIndex = Properties.Settings.Default.workModeIndex;
            delayTimeBox.SelectedIndex = Properties.Settings.Default.delayTime;
            checkBox1.Checked = Properties.Settings.Default.runWithNotepad;
            checkBox2.Checked = Properties.Settings.Default.pressEnterWhenProcessFinished;

            createTxtBox(); //By default it creates 1 text box.

            closeAll = true;
        }

        //setRunning prepares WriterBOT to start or end run.
        private void setRunning(bool isRunning)
        { //True = WriterBOT Process is running now! , False = WriterBOT process is stopped.
            timerSecond.Enabled = isRunning;
            botActive = isRunning;

            if (isRunning == true)
            {
                delayTime = Properties.Settings.Default.delayTime;
                maxTimeSecond += delayTime;
                timeSecond = 0;
                runBtn.Text = "Stop WriterBOT";
                info.Text = "Warning! WriterBOT is getting ready! After " + delayTime + " seconds WriterBOT will perform the desired task!";
                progressBar.Value = 0;
                if (delayTime > 0) { 
                    progressBar.Maximum = delayTime; 
                } else { 
                    progressBar.Maximum = 1; 
                }
                if (Properties.Settings.Default.runWithNotepad == true) { 
                    Process.Start("notepad.exe"); 
                }
            }
            else if(isRunning == false)
            {
                timerCore.Enabled = false;
                runBtn.Text = "Run WriterBOT";
                progressBar.Value = 0;
                info.Text = "WriterBOT isn't running now!";
                isCoreBusy = false;
            }
            //Many settings are disabled from here when the WriterBOT process runs.
            runBtn.Enabled = !isRunning;
            addNew.Enabled = !isRunning;
            delLast.Enabled = !isRunning;
            optionsBtn.Enabled = !isRunning;
            aboutBtn.Enabled = !isRunning;
            workModeBox.Enabled = !isRunning;
            delayTimeBox.Enabled = !isRunning;
            checkBox1.Enabled = !isRunning;
            checkBox2.Enabled = !isRunning;
            foreach (TextBox tb in txtBoxList)
            {
                tb.Enabled = !isRunning;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   //It can start and stop the WriterBOT process.
            try
            {
                if (botActive == false)
                {
                    if (workModeBox.Text != "" && txtBoxCount > 0)
                    {
                        switch(MessageBox.Show("While WriterBOT is running, it will write the desired texts. You will be responsible for all problems that may occur from this process. Do you want to continue? If you click yes, WriterBOT will work.", "Be careful when using WriterBOT!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            case DialogResult.Yes:
                                setRunning(true);
                                break;
                            case DialogResult.No:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make sure Work Mode is selected and there are no blank lines.", "Writer BOT cannot be run!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (botActive == true)
                {
                    setRunning(false);
                }
            }
            catch(Exception exception)
            {
                emreki_BugLogger(exception, "WriterBOT CannotRunOrStopWriterBOT Error");
            }
        }

        private void addNew_Click(object sender, EventArgs e)
        {   //Makes a request to add a new line. If the conditions are true, a new line is added.
            try
            {
                createTxtBox();
            }
            catch(Exception exception)
            {
                emreki_BugLogger(exception, "WriterBOT AddTextBox Error");
            }
        }

        private void createTxtBox()
        {   //Adds new line. If the line add limit is reached, the line is not added.
            try
            {
                if (txtBoxCount < maxTxtBoxCount)
                {
                    TextBox txt = new TextBox();
                    txt.SetBounds(txtBoxX, txtBoxY, 449, 23);
                    txt.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
                    txtBoxY += 2 + txt.Size.Height;
                    this.Controls.Add(txt);
                    txtBoxList.Add(txt);
                    txtBoxCount++;
                    editUI(this.Height + 25);
                }
                else if(txtBoxCount >= maxTxtBoxCount)
                {
                    MessageBox.Show("Unfortunately, a maximum of "+maxTxtBoxCount+ " line are allowed.", "Line limit reached!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch(Exception exception){
                emreki_BugLogger(exception, "WriterBOT CreateTextBox Error");
            }
        }

        private void editUI(int formSizeY)
        {
            this.Size = new Size(489, formSizeY); //The form size is edited as a new line is added or removed.
            textCountInfo.Text = "Line Count: " + txtBoxCount;
        }

        private void removeTxtBox()
        {   //Deletes the most recently added line.
            if (txtBoxCount > 0)
            {
                TextBox dtxt = txtBoxList[txtBoxList.Count - 1];
                txtBoxY -= 2 + dtxt.Size.Height;
                txtBoxList.RemoveAt(txtBoxList.Count - 1);
                this.Controls.Remove(dtxt);
                txtBoxCount--;
                editUI(this.Height - 25);
            }
            else
            {
                MessageBox.Show("Because there is no line left that can be deleted!", "You cannot delete any more line!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void delLast_Click(object sender, EventArgs e)
        {   //Makes a request to delete the most recently added line.
            try
            {
                removeTxtBox();
            }catch (Exception exception)
            {
                emreki_BugLogger(exception, "WriterBOT DeleteTextBox Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   //About information
            try
            {
                switch (MessageBox.Show("WriterBOT was developed by Emre Kara \"Emreki\". The purpose of the application is to automatically write a few lines of text for entertainment purposes. The user of the application is responsible for its use outside of its purpose. Emre Kara \"Emreki\" cannot be held responsible for its use outside of its purpose of the application.\n\nWould you like to know more about Emreki ? We will direct you to Emreki Web, Emreki GitHub, Emreki YouTube pages.", "About WriterBOT", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {getWebSite()}") { CreateNoWindow = true });
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {getGitHub()}") { CreateNoWindow = true });
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {getYouTube()}") { CreateNoWindow = true });
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            catch(Exception exception)
            {
                emreki_BugLogger(exception, "WriterBOT About Error");
            }
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {   //Allows WriterBOT to close completely.
            try { 
                if (closeAll == true) {
                    Environment.Exit(0); 
                } 
            } 
            catch(Exception exception) {
                emreki_BugLogger(exception, "WriterBOT CannotClose Error");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //It is responsible for setting the WriterBOT Work Mode.
            try
            {
                //The current number of lines is reduced to 1 as the number of allowed lines will change.
                while (txtBoxCount > 1) { removeTxtBox(); }
                //In this section, the maximum number of lines and duration are determined.
                if (workModeBox.SelectedIndex == 0) { 
                    maxTxtBoxCount = 32; maxTimeSecond = 1; 
                }
                else if (workModeBox.SelectedIndex == 1 || workModeBox.SelectedIndex == 4 || workModeBox.SelectedIndex == 7) { 
                    maxTimeSecond = 3; maxTxtBoxCount = 16; 
                }
                else if (workModeBox.SelectedIndex == 2 || workModeBox.SelectedIndex == 5 || workModeBox.SelectedIndex == 8) {
                    maxTimeSecond = 5; maxTxtBoxCount = 8; 
                }
                else if (workModeBox.SelectedIndex == 3 || workModeBox.SelectedIndex == 6 || workModeBox.SelectedIndex == 9) {
                    maxTimeSecond = 10; maxTxtBoxCount = 4; 
                }
                //Here, the speed mode is determined.
                if (workModeBox.SelectedIndex == 4 || workModeBox.SelectedIndex == 5 || workModeBox.SelectedIndex == 6)
                {
                    timerCore.Interval = 1000;  //Slow Speed Mode
                }
                else if (workModeBox.SelectedIndex == 7 || workModeBox.SelectedIndex == 8 || workModeBox.SelectedIndex == 9)
                {
                    timerCore.Interval = 500;   //High Speed Mode
                }
                if (workModeBox.SelectedIndex == 10)
                {   //Infinity Very Slow Speed Mode
                    timerCore.Interval = 5000; 
                    maxTimeSecond = 1000; maxTxtBoxCount = 1;
                    //Since the process will not end in infinity mode,
                    //the press Enter key feature should be disabled when the process is finished.
                    checkBox2.Checked = false; 
                    checkBox2.Enabled = false;
                }
                else { checkBox2.Enabled = true; } 

                Properties.Settings.Default.workModeIndex = workModeBox.SelectedIndex;
                Properties.Settings.Default.Save();
            }catch (Exception exception)
            {
                emreki_BugLogger(exception, "WriterBOT Work Mode Selection Error");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {   //It is responsible for setting the number of seconds to wait before the WriterBOT process is started.
            Properties.Settings.Default.delayTime = delayTimeBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {   //Manages the runtime of the WriterBOT process. But this Timer is not related with the working speed.
            try
            {
                progressBar.Value = timeSecond;
                timeSecond++;

                if (timeSecond >= delayTime)
                {   
                    runBtn.Enabled = true;
                    if (workModeBox.SelectedIndex > 3)
                    {
                        info.Text = "WriterBOT is running! If WriterBOT itself becomes an active window while it is running, it may not work properly.";
                        progressBar.Maximum = maxTimeSecond;
                        if(timeSecond >= maxTimeSecond - 100) { 
                            timeSecond = delayTime + 1; 
                        } //Infinity Mode
                        if (timeSecond >= maxTimeSecond && workModeBox.SelectedIndex != 10) {
                            progressBar.Value = maxTimeSecond;
                            setRunning(false);
                        }
                        else if(timeSecond < maxTimeSecond)
                        {   //After the waiting time required for the WriterBOT process to run, timerCore runs, which will perform the operations at different speed during the time it will run.
                            if (timerCore.Enabled == false) { timerCore.Enabled = true; }
                        }
                    }
                    else
                    {   //TimerCore is not run in processes that do not have a certain amount of time and need a certain amount of work. The direct process is executed.
                        progressBar.Value = progressBar.Maximum;
                        if (workModeBox.SelectedIndex == 0 && isCoreBusy == false) { WriterCore(1); } //Work 1 time
                        if (workModeBox.SelectedIndex == 1 && isCoreBusy == false) { WriterCore(3); } //Work 3 time
                        if (workModeBox.SelectedIndex == 2 && isCoreBusy == false) { WriterCore(5); } //Work 5 time
                        if (workModeBox.SelectedIndex == 3 && isCoreBusy == false) { WriterCore(10); } //Work 10 time
                    }
                }
            }
            catch(Exception exception)
            {
                emreki_BugLogger(exception, "WriterBOT TimerSecond Error");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {   //If we want, the Notepad application is started as soon as the WriterBOT process starts running.
            //So WriterBOT writes lines to the Notepad application if we want.
            Properties.Settings.Default.runWithNotepad = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {   //It allows us to decide whether to send an automatic Enter key after the whole process is finished.
            Properties.Settings.Default.pressEnterWhenProcessFinished = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }
        
        private void optionsBtn_Click(object sender, EventArgs e)
        {   //It is responsible for opening the options window.
            options op = new options();
            op.Show();
            closeAll = false;
            this.Close();
        }

        private void timerCore_Tick(object sender, EventArgs e)
        {   //Timer named timerCore works according to the speed determined by Work Mode for as long as timerSecond allows.
            //Every time timerCore runs, it make for the desired action.
            try {
                WriterCore(0);
            }
            catch (Exception exception)
            {
                emreki_BugLogger(exception, "WriterBOT Core Error");
            }
        }

        private bool isCoreBusy = false;
        /*
         * WriterCore busy state is determined. Even if it is a one-time operation, 
         * timerSecond always wants to perform that operation. 
         * However, WriterCore indicates that it is busy with this bool. 
         * In this way, the timerSecond cannot request that the one-time operation be 
         * repeated over and over again.
         */
        private void WriterCore(int workCount = 1)
        {   //It allows the operation to be done once or for a period of time.
            isCoreBusy = true;
            if(workCount > 0)
            {
                for (int i = 0; i < workCount; i++)
                {
                    WriteNow();
                }
                setRunning(false);
                isCoreBusy = false;
            }
            else if(workCount == 0)
            {   /*In short, it is not known how many times timed process will be run.
                 * Therefore, by saying do it 0 times, it is indicated that this is a timed process.
                 */
                WriteNow();
            }
        }

        private void WriteNow()
        {   //Makes all lines write now.
            foreach (TextBox txtBox in txtBoxList)
            {
                if (txtBox.Text != "")
                {
                    SendKeys.Send(txtBox.Text);
                } //It automatically sends Shift-Enter after writing each line.
                SendKeys.Send("+{ENTER}");
            } //If requested, an automatic Enter key is sent after all processes are completed.
            if (Properties.Settings.Default.pressEnterWhenProcessFinished == true) {
                SendKeys.Send("{ENTER}"); 
            }
        }

        /*
         Emreki Bug Logger First Version
         By sending the errors caught by the Try Catch method here, 
         a bug log file is created. In this way, the record of the errors encountered 
         can be sent to Emreki.
         */

        private void emreki_BugLogger(Exception exception, string specialDescription = "Not Found")
        {   //If Emreki Bug Logger start run while the WriterBOT process is running, the WriterBOT process is stopped.
            if (timerSecond.Enabled == true) { 
                setRunning(false);
            }
            StreamWriter sw;
            try {
                sw = new StreamWriter(Application.StartupPath + "\\WriterBOT_Bug_Logs.txt", true);
                sw.WriteLine("NEW BUG REPORT\nPlease help fix the errors by submitting this error file to this site: "+getWebSite()+"\nApplication Version: " + version+ "\nTime to encounter the bug: " + DateTime.Now.ToString() + "\nException: " +exception.Message+ "\nSpecial description: "+specialDescription);
                sw.Flush();
                sw.Close();
                MessageBox.Show("An error was encountered while running the application. That's why we created a file where you can report the error to Emreki. Please forward the file indicating the error to Emreki. The application will continue to work if possible, but it is best to restart the application.\nName of the file where the error is logged: WriterBOT_Bug_Logs\nThis file is located in the application's file location.", "Something went wrong :) Application Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch { 
                MessageBox.Show("An error occurred, but another error occurred while preparing to report that error.", "Error upon error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        /*
         Example Bug Log: Application File Location/ WriterBOT_Bug_Logs.txt
         
         NEW BUG REPORT
         Please help fix the errors by submitting this site: https://emreki.art.blog/
         Application Version: V1.0 BETA
         Time to encounter the bug: Date Time Now
         Exception: exception message
         Special Description: WriterBOT Core Error
         NEW BUG REPORT
         Every new bug report continues to be added to this file like this.
         */
    }
}
