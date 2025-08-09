using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Users_Screen
{
    partial class frmUsers
    {
        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = dgvUsers.Rows[e.RowIndex];

                clsUser user = Row.Tag as clsUser;

                if (user != null)
                {
                    IndexOfClickedUser = e.RowIndex;
                    ShowUserDetailsForm(user);
                }
            }

        }
    }
}
