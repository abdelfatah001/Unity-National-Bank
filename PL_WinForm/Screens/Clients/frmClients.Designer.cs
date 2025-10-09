namespace PL_WinForm.Clients
{
    partial class frmClients
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
            this.ctrlClientManager1 = new PL_WinForm.User_Controls.ctrlClientManager();
            this.SuspendLayout();
            // 
            // ctrlClientManager1
            // 
            this.ctrlClientManager1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlClientManager1.Location = new System.Drawing.Point(-3, 0);
            this.ctrlClientManager1.Name = "ctrlClientManager1";
            this.ctrlClientManager1.Size = new System.Drawing.Size(689, 659);
            this.ctrlClientManager1.TabIndex = 0;
            // 
            // frmClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 660);
            this.Controls.Add(this.ctrlClientManager1);
            this.IsMdiContainer = true;
            this.Name = "frmClients";
            this.Text = "frmClients";
            this.ResumeLayout(false);

        }

        #endregion

        private PL_WinForm.User_Controls.ctrlClientManager ctrlClientManager1;
    }
}