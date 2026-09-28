namespace DVLD_Solution
{
    partial class UCSearchPerson
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
            this.personDetails = new DVLD_Solution.UCPersonDetails();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnShearchPerson = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.comFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // personDetails
            // 
            this.personDetails.AutoSize = true;
            this.personDetails.Location = new System.Drawing.Point(14, 99);
            this.personDetails.Margin = new System.Windows.Forms.Padding(1);
            this.personDetails.Name = "personDetails";
            this.personDetails.Size = new System.Drawing.Size(1321, 310);
            this.personDetails.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddPerson);
            this.groupBox1.Controls.Add(this.btnShearchPerson);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.comFilter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVLD_Solution.Properties.Resources.AddPerson_32;
            this.btnAddPerson.Location = new System.Drawing.Point(519, 20);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(72, 48);
            this.btnAddPerson.TabIndex = 4;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnShearchPerson
            // 
            this.btnShearchPerson.Image = global::DVLD_Solution.Properties.Resources.SearchPerson;
            this.btnShearchPerson.Location = new System.Drawing.Point(441, 20);
            this.btnShearchPerson.Name = "btnShearchPerson";
            this.btnShearchPerson.Size = new System.Drawing.Size(72, 48);
            this.btnShearchPerson.TabIndex = 3;
            this.btnShearchPerson.UseVisualStyleBackColor = true;
            this.btnShearchPerson.Click += new System.EventHandler(this.btnShearchPerson_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(257, 33);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(169, 24);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.Visible = false;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // comFilter
            // 
            this.comFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFilter.FormattingEnabled = true;
            this.comFilter.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo"});
            this.comFilter.Location = new System.Drawing.Point(99, 33);
            this.comFilter.Name = "comFilter";
            this.comFilter.Size = new System.Drawing.Size(152, 24);
            this.comFilter.TabIndex = 1;
            this.comFilter.SelectedIndexChanged += new System.EventHandler(this.comFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(22, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter By";
            // 
            // UCSearchPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.personDetails);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCSearchPerson";
            this.Size = new System.Drawing.Size(1356, 555);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnShearchPerson;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox comFilter;
        private System.Windows.Forms.Label label2;
        public UCPersonDetails personDetails;
    }
}
