using PL_WinForm.User_Controls;

namespace PL_WinForm.Employees
{
    partial class frmEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployees));
            this.ctrlEmployeeManager1 = new PL_WinForm.User_Controls.ctrlEmployeeManager();
            this.SuspendLayout();
            // 
            // ctrlEmployeeManager1
            // 
            this.ctrlEmployeeManager1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlEmployeeManager1.Location = new System.Drawing.Point(0, -2);
            this.ctrlEmployeeManager1.Name = "ctrlEmployeeManager1";
            this.ctrlEmployeeManager1.Size = new System.Drawing.Size(689, 658);
            this.ctrlEmployeeManager1.TabIndex = 0;
            // 
            // frmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 656);
            this.Controls.Add(this.ctrlEmployeeManager1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmEmployees";
            this.ResumeLayout(false);

        }

        #endregion


        private PL_WinForm.User_Controls.ctrlEmployeeManager ctrlEmployeeManager1;
    }
}