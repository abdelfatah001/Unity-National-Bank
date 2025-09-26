namespace PL_WinForm.Users
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.ctrlUsersManager1 = new PL_WinForm.User_Controls.ctrlUsersManager();
            this.SuspendLayout();
            // 
            // ctrlUsersManager1
            // 
            this.ctrlUsersManager1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlUsersManager1.Location = new System.Drawing.Point(0, -1);
            this.ctrlUsersManager1.Name = "ctrlUsersManager1";
            this.ctrlUsersManager1.Size = new System.Drawing.Size(689, 658);
            this.ctrlUsersManager1.TabIndex = 0;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 655);
            this.Controls.Add(this.ctrlUsersManager1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsers";
            this.Text = "frmUsers";
            this.ResumeLayout(false);

        }

        #endregion

        private PL_WinForm.User_Controls.ctrlUsersManager ctrlUsersManager1;
    }
}