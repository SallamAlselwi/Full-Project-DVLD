namespace DVLD_Solution
{
    partial class frmNewLocalDrivingLicenseApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabpApplicationInfo = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labUserName = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labFees = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labDLApplicationID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucSearchPerson1 = new DVLD_Solution.UCSearchPerson();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(339, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Local Driving License Application";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 100);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 700);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1222, 100);
            this.panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD_Solution.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(841, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 44);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD_Solution.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(983, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 44);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnNext.Image = global::DVLD_Solution.Properties.Resources.Next_32;
            this.btnNext.Location = new System.Drawing.Point(935, 507);
            this.btnNext.Name = "btnNext";
            this.btnNext.Padding = new System.Windows.Forms.Padding(3);
            this.btnNext.Size = new System.Drawing.Size(125, 44);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabpApplicationInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1222, 600);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.ucSearchPerson1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1214, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabpApplicationInfo
            // 
            this.tabpApplicationInfo.Controls.Add(this.comboBox1);
            this.tabpApplicationInfo.Controls.Add(this.labUserName);
            this.tabpApplicationInfo.Controls.Add(this.pictureBox5);
            this.tabpApplicationInfo.Controls.Add(this.label11);
            this.tabpApplicationInfo.Controls.Add(this.labFees);
            this.tabpApplicationInfo.Controls.Add(this.pictureBox4);
            this.tabpApplicationInfo.Controls.Add(this.label9);
            this.tabpApplicationInfo.Controls.Add(this.pictureBox3);
            this.tabpApplicationInfo.Controls.Add(this.label7);
            this.tabpApplicationInfo.Controls.Add(this.labApplicationDate);
            this.tabpApplicationInfo.Controls.Add(this.pictureBox2);
            this.tabpApplicationInfo.Controls.Add(this.label5);
            this.tabpApplicationInfo.Controls.Add(this.labDLApplicationID);
            this.tabpApplicationInfo.Controls.Add(this.pictureBox1);
            this.tabpApplicationInfo.Controls.Add(this.label2);
            this.tabpApplicationInfo.Location = new System.Drawing.Point(4, 25);
            this.tabpApplicationInfo.Name = "tabpApplicationInfo";
            this.tabpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabpApplicationInfo.Size = new System.Drawing.Size(1214, 571);
            this.tabpApplicationInfo.TabIndex = 1;
            this.tabpApplicationInfo.Text = "Application Info";
            this.tabpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(322, 212);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(297, 24);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labUserName.Location = new System.Drawing.Point(318, 317);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(126, 23);
            this.labUserName.TabIndex = 14;
            this.labUserName.Text = "[UserName]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Solution.Properties.Resources.User_32__2;
            this.pictureBox5.Location = new System.Drawing.Point(272, 317);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(57, 317);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 23);
            this.label11.TabIndex = 12;
            this.label11.Text = "Created By";
            // 
            // labFees
            // 
            this.labFees.AutoSize = true;
            this.labFees.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labFees.Location = new System.Drawing.Point(318, 263);
            this.labFees.Name = "labFees";
            this.labFees.Size = new System.Drawing.Size(71, 23);
            this.labFees.TabIndex = 11;
            this.labFees.Text = "[Fees]";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Solution.Properties.Resources.money_32;
            this.pictureBox4.Location = new System.Drawing.Point(272, 263);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(57, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "Application Fees:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Solution.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox3.Location = new System.Drawing.Point(272, 210);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(57, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "License Class:";
            // 
            // labApplicationDate
            // 
            this.labApplicationDate.AutoSize = true;
            this.labApplicationDate.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labApplicationDate.Location = new System.Drawing.Point(318, 157);
            this.labApplicationDate.Name = "labApplicationDate";
            this.labApplicationDate.Size = new System.Drawing.Size(72, 23);
            this.labApplicationDate.TabIndex = 5;
            this.labApplicationDate.Text = "[????]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Solution.Properties.Resources.Calendar_32;
            this.pictureBox2.Location = new System.Drawing.Point(272, 157);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(57, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Date:";
            // 
            // labDLApplicationID
            // 
            this.labDLApplicationID.AutoSize = true;
            this.labDLApplicationID.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labDLApplicationID.Location = new System.Drawing.Point(318, 103);
            this.labDLApplicationID.Name = "labDLApplicationID";
            this.labDLApplicationID.Size = new System.Drawing.Size(72, 23);
            this.labDLApplicationID.TabIndex = 2;
            this.labDLApplicationID.Text = "[????]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Solution.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(272, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(57, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L.Application ID:";
            // 
            // ucSearchPerson1
            // 
            this.ucSearchPerson1.Location = new System.Drawing.Point(8, 6);
            this.ucSearchPerson1.Name = "ucSearchPerson1";
            this.ucSearchPerson1.Size = new System.Drawing.Size(1187, 476);
            this.ucSearchPerson1.TabIndex = 1;
            // 
            // frmNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 800);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNewLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.NewLocalDrivingLicenseApplication_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabpApplicationInfo.ResumeLayout(false);
            this.tabpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabpApplicationInfo;
        private UCSearchPerson ucSearchPerson1;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labFees;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labDLApplicationID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}