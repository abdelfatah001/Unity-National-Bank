namespace PL_WinForm.Screens.Employees
{
    partial class frmDetailedEmployee
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
            this.ctrlDetailedEmployee1 = new PL_WinForm.User_Controls.Details_Presenter.ctrlDetailedEmployee();
            this.SuspendLayout();
            // 
            // ctrlDetailedEmployee1
            // 
            this.ctrlDetailedEmployee1.AddService = null;
            this.ctrlDetailedEmployee1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedEmployee1.Location = new System.Drawing.Point(-2, -1);
            this.ctrlDetailedEmployee1.Name = "ctrlDetailedEmployee1";
            this.ctrlDetailedEmployee1.SelectedRecord = null;
            this.ctrlDetailedEmployee1.Size = new System.Drawing.Size(634, 356);
            this.ctrlDetailedEmployee1.TabIndex = 0;
            this.ctrlDetailedEmployee1.UpdateService = null;
            // 
            // frmDetailedEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(630, 352);
            this.Controls.Add(this.ctrlDetailedEmployee1);
            this.Name = "frmDetailedEmployee";
            this.ShowInTaskbar = false;
            this.Text = "frmDetailedEmployee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDetailedEmployee_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.Details_Presenter.ctrlDetailedEmployee ctrlDetailedEmployee1;
    }
}