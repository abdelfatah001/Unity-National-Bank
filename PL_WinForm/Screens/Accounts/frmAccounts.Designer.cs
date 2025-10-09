using PL_WinForm.User_Controls;

namespace PL_WinForm.Accounts
{
    partial class frmAccounts
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
            this.ctrlAccountManager1 = new PL_WinForm.User_Controls.ctrlAccountManager();
            this.SuspendLayout();
            // 
            // ctrlAccountManager1
            // 
            this.ctrlAccountManager1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlAccountManager1.Location = new System.Drawing.Point(0, -1);
            this.ctrlAccountManager1.Name = "ctrlAccountManager1";
            this.ctrlAccountManager1.Size = new System.Drawing.Size(689, 658);
            this.ctrlAccountManager1.TabIndex = 0;
            // 
            // frmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 655);
            this.Controls.Add(this.ctrlAccountManager1);
            this.IsMdiContainer = true;
            this.Name = "frmAccounts";
            this.Text = "frmAccounts";
            this.ResumeLayout(false);

        }

        #endregion


        private PL_WinForm.User_Controls.ctrlAccountManager ctrlAccountManager1;
    }
}