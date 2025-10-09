namespace PL_WinForm.User_Controls.Details_Presenter
{
    partial class ctrlDetailedClient
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
            this.lblClientId = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.lbl_JoinDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctrlDetailedPerson1 = new PL_WinForm.User_Controls.Details_Presenter.ctrlDetailedPerson();
            this.SuspendLayout();
            // 
            // lblClientId
            // 
            this.lblClientId.AllowDrop = true;
            this.lblClientId.BackColor = System.Drawing.Color.Transparent;
            this.lblClientId.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblClientId.ForeColor = System.Drawing.Color.Red;
            this.lblClientId.Location = new System.Drawing.Point(194, 25);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(112, 23);
            this.lblClientId.TabIndex = 1;
            this.lblClientId.Text = "Client Id";
            // 
            // lblId
            // 
            this.lblId.AllowDrop = true;
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblId.ForeColor = System.Drawing.Color.Red;
            this.lblId.Location = new System.Drawing.Point(312, 25);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(112, 23);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(157, 208);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(140, 21);
            this.cbStatus.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(30, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Status";
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblJoinDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJoinDate.Location = new System.Drawing.Point(463, 207);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(140, 23);
            this.lblJoinDate.TabIndex = 13;
            this.lblJoinDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_JoinDate
            // 
            this.lbl_JoinDate.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_JoinDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_JoinDate.Location = new System.Drawing.Point(338, 207);
            this.lbl_JoinDate.Name = "lbl_JoinDate";
            this.lbl_JoinDate.Size = new System.Drawing.Size(106, 23);
            this.lbl_JoinDate.TabIndex = 12;
            this.lbl_JoinDate.Text = "Join Date";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(316, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(219, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctrlDetailedPerson1
            // 
            this.ctrlDetailedPerson1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedPerson1.Location = new System.Drawing.Point(0, 51);
            this.ctrlDetailedPerson1.Name = "ctrlDetailedPerson1";
            this.ctrlDetailedPerson1.SelectedRecord = null;
            this.ctrlDetailedPerson1.Size = new System.Drawing.Size(632, 151);
            this.ctrlDetailedPerson1.TabIndex = 0;
            // 
            // ctrlDetailedClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblJoinDate);
            this.Controls.Add(this.lbl_JoinDate);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.ctrlDetailedPerson1);
            this.Name = "ctrlDetailedClient";
            this.Size = new System.Drawing.Size(633, 292);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblJoinDate;
        private System.Windows.Forms.Label lbl_JoinDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private ctrlDetailedPerson ctrlDetailedPerson1;
    }
}
