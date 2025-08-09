using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Users_Screen
{
    partial class frmUserDetails
    {
        private void btnShowEmployeeDetails_Click(object sender, EventArgs e)
        {
            DisappearUserPanel();
            ShowEmployeeForm(_SelectedUser.Employee);
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUserAfterUpdate();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
