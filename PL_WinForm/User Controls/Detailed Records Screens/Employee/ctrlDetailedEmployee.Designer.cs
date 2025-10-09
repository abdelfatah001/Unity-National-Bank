namespace PL_WinForm.User_Controls.Details_Presenter
{
    partial class ctrlDetailedEmployee
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblEmployeeId = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.lblManagerId = new System.Windows.Forms.Label();
            this.btnShowManager = new System.Windows.Forms.Button();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.cbManager = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlDetailedPerson1 = new PL_WinForm.User_Controls.Details_Presenter.ctrlDetailedPerson();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AllowDrop = true;
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblId.ForeColor = System.Drawing.Color.Red;
            this.lblId.Location = new System.Drawing.Point(340, 15);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(81, 23);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployeeId
            // 
            this.lblEmployeeId.AllowDrop = true;
            this.lblEmployeeId.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployeeId.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEmployeeId.ForeColor = System.Drawing.Color.Red;
            this.lblEmployeeId.Location = new System.Drawing.Point(188, 15);
            this.lblEmployeeId.Name = "lblEmployeeId";
            this.lblEmployeeId.Size = new System.Drawing.Size(146, 23);
            this.lblEmployeeId.TabIndex = 3;
            this.lblEmployeeId.Text = "Employee Id";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(225, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(322, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbDepartments
            // 
            this.cbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(157, 210);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(135, 21);
            this.cbDepartments.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(16, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Department";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label5.Location = new System.Drawing.Point(342, 210);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(95, 23);
            this.Label5.TabIndex = 20;
            this.Label5.Text = "Salary";
            // 
            // lblManagerId
            // 
            this.lblManagerId.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblManagerId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblManagerId.Location = new System.Drawing.Point(93, 267);
            this.lblManagerId.Name = "lblManagerId";
            this.lblManagerId.Size = new System.Drawing.Size(106, 23);
            this.lblManagerId.TabIndex = 24;
            this.lblManagerId.Text = "ManagerId";
            // 
            // btnShowManager
            // 
            this.btnShowManager.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnShowManager.Location = new System.Drawing.Point(402, 263);
            this.btnShowManager.Name = "btnShowManager";
            this.btnShowManager.Size = new System.Drawing.Size(118, 25);
            this.btnShowManager.TabIndex = 26;
            this.btnShowManager.Text = "Show Manager";
            this.btnShowManager.UseVisualStyleBackColor = true;
            this.btnShowManager.Click += new System.EventHandler(this.btnShowManager_Click);
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(462, 211);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(135, 20);
            this.txtSalary.TabIndex = 27;
            // 
            // cbManager
            // 
            this.cbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManager.FormattingEnabled = true;
            this.cbManager.Location = new System.Drawing.Point(225, 265);
            this.cbManager.Name = "cbManager";
            this.cbManager.Size = new System.Drawing.Size(135, 21);
            this.cbManager.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlDetailedPerson1);
            this.panel1.Controls.Add(this.cbManager);
            this.panel1.Controls.Add(this.lblEmployeeId);
            this.panel1.Controls.Add(this.pbBack);
            this.panel1.Controls.Add(this.lblId);
            this.panel1.Controls.Add(this.txtSalary);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnShowManager);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.lblManagerId);
            this.panel1.Controls.Add(this.Label5);
            this.panel1.Controls.Add(this.cbDepartments);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 339);
            this.panel1.TabIndex = 30;
            // 
            // ctrlDetailedPerson1
            // 
            this.ctrlDetailedPerson1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedPerson1.Location = new System.Drawing.Point(0, 53);
            this.ctrlDetailedPerson1.Name = "ctrlDetailedPerson1";
            this.ctrlDetailedPerson1.SelectedRecord = null;
            this.ctrlDetailedPerson1.Size = new System.Drawing.Size(640, 151);
            this.ctrlDetailedPerson1.TabIndex = 30;
            // 
            // pbBack
            // 
            this.pbBack.Image = global::PL_WinForm.Properties.Resources.backk;
            this.pbBack.Location = new System.Drawing.Point(18, 6);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(44, 41);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 28;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            this.pbBack.MouseEnter += new System.EventHandler(this.pbBack_MouseEnter);
            this.pbBack.MouseLeave += new System.EventHandler(this.pbBack_MouseLeave);
            // 
            // ctrlDetailedEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.panel1);
            this.Name = "ctrlDetailedEmployee";
            this.Size = new System.Drawing.Size(646, 342);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label lblManagerId;
        private System.Windows.Forms.Button btnShowManager;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.ComboBox cbManager;
        private System.Windows.Forms.Panel panel1;
        private ctrlDetailedPerson ctrlDetailedPerson1;
    }
}
