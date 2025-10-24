namespace PL_WinForm.Screens.Clients
{
    partial class frmDetailedClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailedClient));
            this.ctrlDetailedClient1 = new PL_WinForm.User_Controls.Details_Presenter.ctrlDetailedClient();
            this.SuspendLayout();
            // 
            // ctrlDetailedClient1
            // 
            this.ctrlDetailedClient1.AddService = null;
            this.ctrlDetailedClient1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedClient1.Location = new System.Drawing.Point(1, 0);
            this.ctrlDetailedClient1.Name = "ctrlDetailedClient1";
            this.ctrlDetailedClient1.SelectedRecord = null;
            this.ctrlDetailedClient1.Size = new System.Drawing.Size(633, 292);
            this.ctrlDetailedClient1.TabIndex = 0;
            this.ctrlDetailedClient1.UpdateService = null;
            // 
            // frmDetailedClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(633, 291);
            this.Controls.Add(this.ctrlDetailedClient1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetailedClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDetailedClient_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.Details_Presenter.ctrlDetailedClient ctrlDetailedClient1;
    }
}