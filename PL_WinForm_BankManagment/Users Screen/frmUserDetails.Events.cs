using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment
{
    partial class frmUserDetails
    {
        private void btnShowEmployeeDetails_Click(object sender, EventArgs e)
        {
            ShowEmployeeForm(SelectedUser.Employee);
        }

        private void ShowEmployeeForm(clsEmployee employee)
        {
            //
        }

       
        

       
 


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUserAfterUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
