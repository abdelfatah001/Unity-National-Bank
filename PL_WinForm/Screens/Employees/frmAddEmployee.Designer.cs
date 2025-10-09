namespace PL_WinForm.Screens.Employees
{
    partial class frmAddEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEmployee));
            this.ctrlDetailedEmployee1 = new PL_WinForm.User_Controls.Details_Presenter.ctrlDetailedEmployee();
            this.SuspendLayout();
            // 
            // ctrlDetailedEmployee1
            // 
            this.ctrlDetailedEmployee1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlDetailedEmployee1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDetailedEmployee1.Name = "ctrlDetailedEmployee1";
            this.ctrlDetailedEmployee1.SelectedRecord = null;
            this.ctrlDetailedEmployee1.Size = new System.Drawing.Size(646, 342);
            this.ctrlDetailedEmployee1.TabIndex = 0;
            this.ctrlDetailedEmployee1.UpdateService = null;
            // 
            // frmAddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 341);
            this.Controls.Add(this.ctrlDetailedEmployee1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddEmployee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddEmployee_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.Details_Presenter.ctrlDetailedEmployee ctrlDetailedEmployee1;
    }
}