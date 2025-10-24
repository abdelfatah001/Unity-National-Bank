namespace PL_WinForm.Screens.Users
{
    partial class frmDetailedUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedUsers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlDetailedUsers1 = new PL_WinForm.User_Controls.Details_Presenter.User.ctrlDetailedUsers();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ctrlDetailedUsers1);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 450);
            this.panel1.TabIndex = 0;
            // 
            // ctrlDetailedUsers1
            // 
            this.ctrlDetailedUsers1.AddService = null;
            this.ctrlDetailedUsers1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedUsers1.Location = new System.Drawing.Point(0, 2);
            this.ctrlDetailedUsers1.MaximumSize = new System.Drawing.Size(643, 763);
            this.ctrlDetailedUsers1.MinimumSize = new System.Drawing.Size(643, 450);
            this.ctrlDetailedUsers1.Name = "ctrlDetailedUsers1";
            this.ctrlDetailedUsers1.SelectedRecord = null;
            this.ctrlDetailedUsers1.Size = new System.Drawing.Size(643, 450);
            this.ctrlDetailedUsers1.TabIndex = 0;
            this.ctrlDetailedUsers1.UpdateService = null;
            // 
            // frmDetailedUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(666, 451);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedUsers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDetailedUsers_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.Details_Presenter.User.ctrlDetailedUsers ctrlDetailedUsers1;
        private System.Windows.Forms.Panel panel1;
    }
}