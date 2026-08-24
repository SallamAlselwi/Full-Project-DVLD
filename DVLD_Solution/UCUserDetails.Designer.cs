namespace DVLD_Solution
{
    partial class UCUserDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labIsActive = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.labUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucPersonDetails1 = new DVLD_Solution.UCPersonDetails();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labIsActive);
            this.groupBox1.Controls.Add(this.labUserName);
            this.groupBox1.Controls.Add(this.labUserID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(969, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // labIsActive
            // 
            this.labIsActive.AutoSize = true;
            this.labIsActive.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labIsActive.Location = new System.Drawing.Point(750, 37);
            this.labIsActive.Name = "labIsActive";
            this.labIsActive.Size = new System.Drawing.Size(52, 17);
            this.labIsActive.TabIndex = 5;
            this.labIsActive.Text = "[????]";
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labUserName.Location = new System.Drawing.Point(441, 37);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(52, 17);
            this.labUserName.TabIndex = 4;
            this.labUserName.Text = "[????]";
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labUserID.Location = new System.Drawing.Point(120, 37);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(52, 17);
            this.labUserID.TabIndex = 3;
            this.labUserID.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(678, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Is Active:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(359, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(59, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            // 
            // ucPersonDetails1
            // 
            this.ucPersonDetails1.AutoSize = true;
            this.ucPersonDetails1.Location = new System.Drawing.Point(12, 11);
            this.ucPersonDetails1.Margin = new System.Windows.Forms.Padding(1);
            this.ucPersonDetails1.Name = "ucPersonDetails1";
            this.ucPersonDetails1.Size = new System.Drawing.Size(1164, 310);
            this.ucPersonDetails1.TabIndex = 0;
            // 
            // UCUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucPersonDetails1);
            this.Name = "UCUserDetails";
            this.Size = new System.Drawing.Size(1330, 524);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCPersonDetails ucPersonDetails1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labIsActive;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
