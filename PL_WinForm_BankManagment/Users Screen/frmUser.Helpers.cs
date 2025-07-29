using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment
{
    partial class frmUsers
    {
        private void LoadUsers()
        {
            try
            {
                clsUsersManager.LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateDataGridView()
        {
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add("ID", "ID");
            dgvUsers.Columns.Add("Username", "User Name");
            dgvUsers.Columns.Add("Password", "Password");
            dgvUsers.Columns.Add("AccessCode", "Access Code");
            dgvUsers.Columns.Add("EmployeeID", "Employee ID");

            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
        }

        private void FillUsersDGV ()
        {
            if (clsUsersManager.Users.Count == 0)
                LoadUsers();
            
            CreateDataGridView();

            if (clsUsersManager.Users.Count == 0)
            {
                MessageBox.Show("There is no existed users");
                return;
            }

            foreach (clsUser user in clsUsersManager.Users)
            {
                int RowIndex = dgvUsers.Rows.Add (user.Id, user.UserName,
                    user.Password, user.AccessCode, user.Employee.Id);

                dgvUsers.Rows[RowIndex].Tag = user;
            }
        }

        private void ShowUserDetailsForm (clsUser user)
        {
            frmUserDetails frm = new frmUserDetails(user);
            frm.Show();
        }

    }
}
