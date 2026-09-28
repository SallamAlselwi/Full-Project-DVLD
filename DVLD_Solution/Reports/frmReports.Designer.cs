namespace DVLD_Solution
{
    partial class frmReports
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
            this.btnReportPeople = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReportUsers = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReportPeople
            // 
            this.btnReportPeople.Location = new System.Drawing.Point(31, 39);
            this.btnReportPeople.Name = "btnReportPeople";
            this.btnReportPeople.Size = new System.Drawing.Size(121, 48);
            this.btnReportPeople.TabIndex = 0;
            this.btnReportPeople.Text = "Report People";
            this.btnReportPeople.UseVisualStyleBackColor = true;
            this.btnReportPeople.Click += new System.EventHandler(this.btnReportPeople_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReportUsers);
            this.panel1.Controls.Add(this.btnReportPeople);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 558);
            this.panel1.TabIndex = 1;
            // 
            // btnReportUsers
            // 
            this.btnReportUsers.Location = new System.Drawing.Point(31, 117);
            this.btnReportUsers.Name = "btnReportUsers";
            this.btnReportUsers.Size = new System.Drawing.Size(121, 48);
            this.btnReportUsers.TabIndex = 1;
            this.btnReportUsers.Text = "Report Users";
            this.btnReportUsers.UseVisualStyleBackColor = true;
            this.btnReportUsers.Click += new System.EventHandler(this.btnReportUsers_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(200, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1371, 558);
            this.webView21.TabIndex = 2;
            this.webView21.ZoomFactor = 1D;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 558);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.panel1);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportPeople;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Button btnReportUsers;
    }
}