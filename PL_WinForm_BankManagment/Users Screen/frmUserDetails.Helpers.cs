using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PL_WinForm_BankManagment
{
    partial class frmUserDetails
    {
        // Fill Form with Data
        private void FillFormWithUserData()
        {
            txtUsername.Text = SelectedUser.UserName;
            txtPassword.Text = SelectedUser.Password;

            lblFirstName.Text = SelectedUser.Employee.Person.FirstName;
            lblLastName.Text = SelectedUser.Employee.Person.LastName;
            lblEmployeeId.Text = SelectedUser.Employee.Id.ToString();

            if (SelectedUser.AccessCode == 1962 || SelectedUser.AccessCode == -1)
                lblAccessCode.Text = "full access";

            else
            {
                lblAccessCode.Font.Size = new Font(Candara.Font.FontFamily, 10); ;
                lblAccessCode.Text = SelectedUser.AccessCode.ToString();
            }

        }

        // Save User Data after Update 
        private bool IsUserDataChanged()
        {
            return
                (txtUsername.Text != SelectedUser.UserName || txtPassword.Text != SelectedUser.Password);
        }

        private bool IsUserAccessChanged()
        {
            return int.Parse(lblAccessCode.Text) != SelectedUser.AccessCode;
        }

        private void UpdateSelectedUsers()
        {
            SelectedUser.UserName = txtUsername.Text;
            SelectedUser.Password = txtPassword.Text;

            /*if (IsUserAccessChanged())
            {
                SelectedUser.AccessCode = int.Parse(lblAccessCode.Text);
            }*/
        }

        private void SaveUserAfterUpdate()
        {
            if (!IsUserDataChanged() /*&& !IsUserAccessChanged()*/)
            {
                this.Close();
                return;
            }
            UpdateSelectedUsers();
            clsUsersManager.UpdateUser(SelectedUser);
            this.Close();
        }

        private void ChangeUserAccessabilty (object sender, EventArgs e)
        {

        }

    }
}
