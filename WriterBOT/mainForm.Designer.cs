namespace WriterBOT
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.addNew = new System.Windows.Forms.Button();
            this.delLast = new System.Windows.Forms.Button();
            this.textCountInfo = new System.Windows.Forms.Label();
            this.workModeText = new System.Windows.Forms.Label();
            this.workModeBox = new System.Windows.Forms.ComboBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.timerSecond = new System.Windows.Forms.Timer(this.components);
            this.timerCore = new System.Windows.Forms.Timer(this.components);
            this.aboutBtn = new System.Windows.Forms.Button();
            this.delayTimeText = new System.Windows.Forms.Label();
            this.delayTimeBox = new System.Windows.Forms.ComboBox();
            this.info = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.optionsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addNew
            // 
            this.addNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addNew.ForeColor = System.Drawing.Color.Black;
            this.addNew.Location = new System.Drawing.Point(297, 100);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(72, 26);
            this.addNew.TabIndex = 0;
            this.addNew.Text = "Add Line";
            this.addNew.UseVisualStyleBackColor = true;
            this.addNew.Click += new System.EventHandler(this.addNew_Click);
            // 
            // delLast
            // 
            this.delLast.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.delLast.ForeColor = System.Drawing.Color.Black;
            this.delLast.Location = new System.Drawing.Point(375, 100);
            this.delLast.Name = "delLast";
            this.delLast.Size = new System.Drawing.Size(86, 26);
            this.delLast.TabIndex = 1;
            this.delLast.Text = "Delete Line";
            this.delLast.UseVisualStyleBackColor = true;
            this.delLast.Click += new System.EventHandler(this.delLast_Click);
            // 
            // textCountInfo
            // 
            this.textCountInfo.AutoEllipsis = true;
            this.textCountInfo.ForeColor = System.Drawing.Color.Black;
            this.textCountInfo.Location = new System.Drawing.Point(187, 107);
            this.textCountInfo.Name = "textCountInfo";
            this.textCountInfo.Size = new System.Drawing.Size(104, 15);
            this.textCountInfo.TabIndex = 2;
            this.textCountInfo.Text = "Line Count: 0";
            this.textCountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // workModeText
            // 
            this.workModeText.AutoEllipsis = true;
            this.workModeText.ForeColor = System.Drawing.Color.Black;
            this.workModeText.Location = new System.Drawing.Point(12, 74);
            this.workModeText.Name = "workModeText";
            this.workModeText.Size = new System.Drawing.Size(75, 14);
            this.workModeText.TabIndex = 3;
            this.workModeText.Text = "Work Mode:";
            this.workModeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workModeBox
            // 
            this.workModeBox.DisplayMember = "0";
            this.workModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workModeBox.FormattingEnabled = true;
            this.workModeBox.Items.AddRange(new object[] {
            "Work 1 time (Can allow 32 Text)",
            "Work 3 time (Can allow only 16 Text)",
            "Work 5 time (Can allow only 8 Text)",
            "Work 10 time (Can allow only 4 Text)",
            "Work for 3 seconds at Slow Speed (Can allow only 16 Text)",
            "Work for 5 seconds at Slow Speed (Can allow only 8 Text)",
            "Work for 10 seconds at Slow Speed (Can allow only 4 Text)",
            "Work for 3 seconds at High Speed (Can allow only 16 Text)",
            "Work for 5 seconds at High Speed (Can allow only 8 Text)",
            "Work for 10 seconds at High Speed (Can allow only 4 Text)",
            "Work to Infinity at Very Slow Speed (Can allow only 1 Text)"});
            this.workModeBox.Location = new System.Drawing.Point(93, 71);
            this.workModeBox.Name = "workModeBox";
            this.workModeBox.Size = new System.Drawing.Size(368, 23);
            this.workModeBox.TabIndex = 4;
            this.workModeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // runBtn
            // 
            this.runBtn.ForeColor = System.Drawing.Color.Black;
            this.runBtn.Location = new System.Drawing.Point(255, 133);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(206, 44);
            this.runBtn.TabIndex = 5;
            this.runBtn.Text = "Run WriterBOT";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerSecond
            // 
            this.timerSecond.Interval = 1000;
            this.timerSecond.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // timerCore
            // 
            this.timerCore.Interval = 1000;
            this.timerCore.Tick += new System.EventHandler(this.timerCore_Tick);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutBtn.ForeColor = System.Drawing.Color.Black;
            this.aboutBtn.Location = new System.Drawing.Point(433, 4);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(28, 31);
            this.aboutBtn.TabIndex = 6;
            this.aboutBtn.Text = "?";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // delayTimeText
            // 
            this.delayTimeText.AutoEllipsis = true;
            this.delayTimeText.ForeColor = System.Drawing.Color.Black;
            this.delayTimeText.Location = new System.Drawing.Point(12, 106);
            this.delayTimeText.Name = "delayTimeText";
            this.delayTimeText.Size = new System.Drawing.Size(125, 16);
            this.delayTimeText.TabIndex = 7;
            this.delayTimeText.Text = "Delay time before run:";
            this.delayTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // delayTimeBox
            // 
            this.delayTimeBox.FormattingEnabled = true;
            this.delayTimeBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.delayTimeBox.Location = new System.Drawing.Point(143, 104);
            this.delayTimeBox.Name = "delayTimeBox";
            this.delayTimeBox.Size = new System.Drawing.Size(38, 23);
            this.delayTimeBox.TabIndex = 8;
            this.delayTimeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // info
            // 
            this.info.AutoEllipsis = true;
            this.info.ForeColor = System.Drawing.Color.Black;
            this.info.Location = new System.Drawing.Point(12, 2);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(396, 33);
            this.info.TabIndex = 9;
            this.info.Text = "WriterBOT isn\'t running now!";
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 38);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(449, 23);
            this.progressBar.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(12, 158);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Run with Notepad";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(12, 133);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(237, 19);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "Press Enter when the process is finished.";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // optionsBtn
            // 
            this.optionsBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsBtn.ForeColor = System.Drawing.Color.Black;
            this.optionsBtn.Location = new System.Drawing.Point(405, 4);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(28, 31);
            this.optionsBtn.TabIndex = 15;
            this.optionsBtn.Text = "!";
            this.optionsBtn.UseVisualStyleBackColor = true;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(473, 183);
            this.Controls.Add(this.optionsBtn);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.info);
            this.Controls.Add(this.delayTimeBox);
            this.Controls.Add(this.delayTimeText);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.workModeBox);
            this.Controls.Add(this.workModeText);
            this.Controls.Add(this.textCountInfo);
            this.Controls.Add(this.delLast);
            this.Controls.Add(this.addNew);
            this.Controls.Add(this.progressBar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WriterBOT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addNew;
        private Button delLast;
        private Label textCountInfo;
        private Label workModeText;
        private ComboBox workModeBox;
        private Button runBtn;
        private System.Windows.Forms.Timer timerSecond;
        private System.Windows.Forms.Timer timerCore;
        private Button aboutBtn;
        private Label delayTimeText;
        private ComboBox delayTimeBox;
        private Label info;
        private ProgressBar progressBar;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button optionsBtn;
    }
}