namespace PL_WinForm.Screens.Clients
{
    partial class frmAddClients
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
            this.ctrlDetailedClient1 = new PL_WinForm.User_Controls.Details_Presenter.ctrlDetailedClient();
            this.SuspendLayout();
            // 
            // ctrlDetailedClient1
            // 
            this.ctrlDetailedClient1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedClient1.Location = new System.Drawing.Point(-1, -2);
            this.ctrlDetailedClient1.Name = "ctrlDetailedClient1";
            this.ctrlDetailedClient1.SelectedRecord = null;
            this.ctrlDetailedClient1.Size = new System.Drawing.Size(633, 292);
            this.ctrlDetailedClient1.TabIndex = 0;
            this.ctrlDetailedClient1.UpdateService = null;
            // 
            // frmAddClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 285);
            this.Controls.Add(this.ctrlDetailedClient1);
            this.Name = "frmAddClients";
            this.Text = "frmAddClients";
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.Details_Presenter.ctrlDetailedClient ctrlDetailedClient1;
    }
}