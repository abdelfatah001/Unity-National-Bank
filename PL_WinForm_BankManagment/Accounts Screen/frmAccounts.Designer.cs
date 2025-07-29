namespace PL_WinForm_BankManagment
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
            this.Accounts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Accounts
            // 
            this.Accounts.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accounts.Location = new System.Drawing.Point(171, 82);
            this.Accounts.Name = "Accounts";
            this.Accounts.Size = new System.Drawing.Size(162, 51);
            this.Accounts.TabIndex = 1;
            this.Accounts.Text = "Accounts";
            // 
            // frmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(673, 619);
            this.Controls.Add(this.Accounts);
            this.Name = "frmAccounts";
            this.Text = "frmAccounts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Accounts;
    }
}