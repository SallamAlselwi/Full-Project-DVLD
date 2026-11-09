namespace DVLD_Solution.Applications.International_Licenses
{
    partial class frmDetainLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetainLicenses));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labCreatedID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.labLicenseID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labDetainDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labDetainID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labLinkShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.labLinkShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.ucSearchLicense1 = new DVLD_Solution.Applications.UCSearchLicense();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(368, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detained License";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFineFees);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labCreatedID);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.labLicenseID);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.labDetainDate);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labDetainID);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(32, 635);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1142, 163);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application New License Info";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(214, 112);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(116, 24);
            this.txtFineFees.TabIndex = 26;
            this.txtFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFineFees_KeyPress);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD_Solution.Properties.Resources.money_32;
            this.pictureBox9.Location = new System.Drawing.Point(177, 108);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(28, 29);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 25;
            this.pictureBox9.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "Fine Fees:";
            // 
            // labCreatedID
            // 
            this.labCreatedID.AutoSize = true;
            this.labCreatedID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labCreatedID.Location = new System.Drawing.Point(852, 73);
            this.labCreatedID.Name = "labCreatedID";
            this.labCreatedID.Size = new System.Drawing.Size(56, 21);
            this.labCreatedID.TabIndex = 23;
            this.labCreatedID.Text = "[???]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_Solution.Properties.Resources.User_32__2;
            this.pictureBox8.Location = new System.Drawing.Point(819, 68);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(28, 29);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 22;
            this.pictureBox8.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(652, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 21);
            this.label16.TabIndex = 21;
            this.label16.Text = "Created By:";
            // 
            // labLicenseID
            // 
            this.labLicenseID.AutoSize = true;
            this.labLicenseID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labLicenseID.Location = new System.Drawing.Point(852, 30);
            this.labLicenseID.Name = "labLicenseID";
            this.labLicenseID.Size = new System.Drawing.Size(56, 21);
            this.labLicenseID.TabIndex = 14;
            this.labLicenseID.Text = "[???]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Solution.Properties.Resources.International_32;
            this.pictureBox5.Location = new System.Drawing.Point(819, 26);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(652, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "License ID:";
            // 
            // labDetainDate
            // 
            this.labDetainDate.AutoSize = true;
            this.labDetainDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labDetainDate.Location = new System.Drawing.Point(210, 73);
            this.labDetainDate.Name = "labDetainDate";
            this.labDetainDate.Size = new System.Drawing.Size(56, 21);
            this.labDetainDate.TabIndex = 5;
            this.labDetainDate.Text = "[???]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(177, 68);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Detain Date:";
            // 
            // labDetainID
            // 
            this.labDetainID.AutoSize = true;
            this.labDetainID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labDetainID.Location = new System.Drawing.Point(210, 32);
            this.labDetainID.Name = "labDetainID";
            this.labDetainID.Size = new System.Drawing.Size(56, 21);
            this.labDetainID.TabIndex = 2;
            this.labDetainID.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Solution.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(177, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detain ID:";
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Image = global::DVLD_Solution.Properties.Resources.Detain_32;
            this.btnDetain.Location = new System.Drawing.Point(1068, 823);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(106, 41);
            this.btnDetain.TabIndex = 3;
            this.btnDetain.Text = "Detain";
            this.btnDetain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Solution.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(956, 823);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 41);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labLinkShowLicensesHistory
            // 
            this.labLinkShowLicensesHistory.AutoSize = true;
            this.labLinkShowLicensesHistory.Enabled = false;
            this.labLinkShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labLinkShowLicensesHistory.Location = new System.Drawing.Point(93, 823);
            this.labLinkShowLicensesHistory.Name = "labLinkShowLicensesHistory";
            this.labLinkShowLicensesHistory.Size = new System.Drawing.Size(175, 21);
            this.labLinkShowLicensesHistory.TabIndex = 5;
            this.labLinkShowLicensesHistory.TabStop = true;
            this.labLinkShowLicensesHistory.Text = "Show Licenses History";
            this.labLinkShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labLinkShowLicensesHistory_LinkClicked);
            // 
            // labLinkShowLicensesInfo
            // 
            this.labLinkShowLicensesInfo.AutoSize = true;
            this.labLinkShowLicensesInfo.Enabled = false;
            this.labLinkShowLicensesInfo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labLinkShowLicensesInfo.Location = new System.Drawing.Point(319, 823);
            this.labLinkShowLicensesInfo.Name = "labLinkShowLicensesInfo";
            this.labLinkShowLicensesInfo.Size = new System.Drawing.Size(152, 21);
            this.labLinkShowLicensesInfo.TabIndex = 6;
            this.labLinkShowLicensesInfo.TabStop = true;
            this.labLinkShowLicensesInfo.Text = "Show Licenses Info";
            this.labLinkShowLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labLinkShowLicensesInfo_LinkClicked);
            // 
            // ucSearchLicense1
            // 
            this.ucSearchLicense1.FilterEnabled = true;
            this.ucSearchLicense1.Location = new System.Drawing.Point(12, 69);
            this.ucSearchLicense1.Name = "ucSearchLicense1";
            this.ucSearchLicense1.Size = new System.Drawing.Size(1162, 569);
            this.ucSearchLicense1.TabIndex = 0;
            this.ucSearchLicense1.OnLicenseSelected += new System.Action<int>(this.ucSearchLicense1_OnLicenseSelected);
            // 
            // frmDetainLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1197, 878);
            this.Controls.Add(this.labLinkShowLicensesInfo);
            this.Controls.Add(this.labLinkShowLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucSearchLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detained License";
            this.Load += new System.EventHandler(this.frmInternationalLicensesApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCSearchLicense ucSearchLicense1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labCreatedID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labLicenseID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labDetainDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labDetainID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel labLinkShowLicensesHistory;
        private System.Windows.Forms.LinkLabel labLinkShowLicensesInfo;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFineFees;
    }
}