namespace PL_WinForm.Transactions
{
    partial class frmTransactions
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbTransfere = new System.Windows.Forms.RadioButton();
            this.rbWithdraw = new System.Windows.Forms.RadioButton();
            this.rbDeposit = new System.Windows.Forms.RadioButton();
            this.pnlSubScreen = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(216, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Transactions";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbTransfere
            // 
            this.rbTransfere.AutoSize = true;
            this.rbTransfere.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbTransfere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbTransfere.Location = new System.Drawing.Point(409, 91);
            this.rbTransfere.Name = "rbTransfere";
            this.rbTransfere.Size = new System.Drawing.Size(91, 19);
            this.rbTransfere.TabIndex = 6;
            this.rbTransfere.TabStop = true;
            this.rbTransfere.Tag = "2";
            this.rbTransfere.Text = "Transfere";
            this.rbTransfere.UseVisualStyleBackColor = true;
            this.rbTransfere.CheckedChanged += new System.EventHandler(this.ChangeScreen);
            // 
            // rbWithdraw
            // 
            this.rbWithdraw.AutoSize = true;
            this.rbWithdraw.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbWithdraw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbWithdraw.Location = new System.Drawing.Point(266, 91);
            this.rbWithdraw.Name = "rbWithdraw";
            this.rbWithdraw.Size = new System.Drawing.Size(87, 19);
            this.rbWithdraw.TabIndex = 5;
            this.rbWithdraw.TabStop = true;
            this.rbWithdraw.Tag = "1";
            this.rbWithdraw.Text = "Withdraw";
            this.rbWithdraw.UseVisualStyleBackColor = true;
            this.rbWithdraw.CheckedChanged += new System.EventHandler(this.ChangeScreen);
            // 
            // rbDeposit
            // 
            this.rbDeposit.AutoSize = true;
            this.rbDeposit.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbDeposit.Location = new System.Drawing.Point(128, 91);
            this.rbDeposit.Name = "rbDeposit";
            this.rbDeposit.Size = new System.Drawing.Size(84, 19);
            this.rbDeposit.TabIndex = 4;
            this.rbDeposit.TabStop = true;
            this.rbDeposit.Tag = "0";
            this.rbDeposit.Text = "Deposite";
            this.rbDeposit.UseVisualStyleBackColor = true;
            this.rbDeposit.CheckedChanged += new System.EventHandler(this.ChangeScreen);
            // 
            // pnlSubScreen
            // 
            this.pnlSubScreen.Location = new System.Drawing.Point(0, 152);
            this.pnlSubScreen.Name = "pnlSubScreen";
            this.pnlSubScreen.Size = new System.Drawing.Size(671, 466);
            this.pnlSubScreen.TabIndex = 8;
            // 
            // frmTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(673, 619);
            this.Controls.Add(this.pnlSubScreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbTransfere);
            this.Controls.Add(this.rbWithdraw);
            this.Controls.Add(this.rbDeposit);
            this.Name = "frmTransactions";
            this.Text = "frmTransacrion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbTransfere;
        private System.Windows.Forms.RadioButton rbWithdraw;
        private System.Windows.Forms.RadioButton rbDeposit;
        private System.Windows.Forms.Panel pnlSubScreen;
    }
}