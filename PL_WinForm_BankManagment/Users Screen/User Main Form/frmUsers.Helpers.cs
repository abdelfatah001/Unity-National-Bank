using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Users_Screen
{
    partial class frmUsers
    {

        private void ShowUserDetailsForm (clsUser user)
        {
            frmUserDetails frm = new frmUserDetails(user, this);
            frm.Show();
        }


        public void UpdateUpdatedUserInDGV (int index, clsUser user)
        {
            DataGridViewRow row = dgvUsers.Rows[index];

            row.Cells["ID"].Value = user.Id;
            row.Cells["Username"].Value = user.UserName;
            row.Cells["Password"].Value = user.Password;
            row.Cells["AccessCode"].Value = user.AccessCode;
            row.Cells["EmployeeID"].Value = user.Employee.Id;
        }

    }
}
