using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Employees_Screen
{
    partial class frmEmployeeDetails
    {

        public event EventHandler CloseEmoloyeeDetails;

        // Close form on saving or canceling
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SaveEmployeeAfterUpdate();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Updatable)
            {
                this.Close();
            }
            else // Mode == enMode.ReadOnly
            {
                CloseEmoloyeeDetails?.Invoke(this, EventArgs.Empty);    
            }
        }


        // picture box back events
        private void pcBack_MouseLeave(object sender, EventArgs e)
        {
            pcBack.Image = Properties.Resources.backk;

        }

        private void pcBack_MouseEnter(object sender, EventArgs e)
        {
            pcBack.Image = Properties.Resources.back;

        }

        // Swap Between Employees and thier managers
        private void btnShowManager_Click(object sender, EventArgs e)
        {
            ShowManagerInsteadOfEmployee();
        }

        private void pcBack_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Updatable)
            {
                ShowEmployeeInsteadOfManager();

            }
            else // Mode == enMode.ReadOnly

            {
                CloseEmoloyeeDetails?.Invoke(this, EventArgs.Empty);
            }
        }




    }
}
