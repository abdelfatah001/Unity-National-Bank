namespace PL_WinForm.Screens.Accounts
{
    partial class frmDetailedAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedAccount));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlDetailedAccounts1 = new PL_WinForm.User_Controls.Details_Presenter.Account.ctrlDetailedAccounts();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.ctrlDetailedAccounts1);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 324);
            this.panel1.TabIndex = 0;
            // 
            // ctrlDetailedAccounts1
            // 
            this.ctrlDetailedAccounts1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedAccounts1.Location = new System.Drawing.Point(3, 0);
            this.ctrlDetailedAccounts1.MaximumSize = new System.Drawing.Size(643, 570);
            this.ctrlDetailedAccounts1.MinimumSize = new System.Drawing.Size(643, 320);
            this.ctrlDetailedAccounts1.Name = "ctrlDetailedAccounts1";
            this.ctrlDetailedAccounts1.SelectedRecord = null;
            this.ctrlDetailedAccounts1.Size = new System.Drawing.Size(643, 493);
            this.ctrlDetailedAccounts1.TabIndex = 0;
            this.ctrlDetailedAccounts1.UpdateService = null;
            // 
            // frmDetailedAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 325);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedAccount";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDetailedAccount_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private User_Controls.Details_Presenter.Account.ctrlDetailedAccounts ctrlDetailedAccounts1;
    }
}