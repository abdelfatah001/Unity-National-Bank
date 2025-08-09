using Manager;
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


        // Save User Data after Update 
        private bool IsUserDataChanged()
        {
            return
                (txtUsername.Text != _SelectedUser.UserName || txtPassword.Text != _SelectedUser.Password);
        }

        private bool IsUserAccessChanged()
        {
            return int.Parse(lblAccessCode.Text) != _SelectedUser.AccessCode;
        }

        private void UpdateSelectedUser()
        {
            _SelectedUser.UserName = txtUsername.Text;
            _SelectedUser.Password = txtPassword.Text;

            if (IsUserAccessChanged())
            {
                _SelectedUser.AccessCode = int.Parse(lblAccessCode.Text);
            }
        }

        private void SaveUserAfterUpdate()
        {
            if (!IsUserDataChanged() && !IsUserAccessChanged())
            {
                this.Close();
                return;
            }
            UpdateSelectedUser();

            // Update Database and Datastructure
            try
            {
                clsUsersManager.UpdateUser(_SelectedUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Update the DGV
            _UserForm.UpdateUpdatedUserInDGV(_UserForm.IndexOfClickedUser, _SelectedUser);
        }

        private void ChangeUserAccessabilty(object sender, EventArgs e)
        {
            CheckBox SelectedCb = (CheckBox)sender;

            if (SelectedCb == cbAdmin)
            {
                if (SelectedCb.Checked == false)
                {
                    UncheckAllAccessibilityBox();
                    lblAccessCode.Text = "0";
                }
                else
                {
                    CheckAllAccessibilityBox();
                    lblAccessCode.Text = "1962";
                }

                return;
            }


            if (SelectedCb.Checked == false)
            {
                cbAdmin.Checked = false;
                lblAccessCode.Text =
                (int.Parse(lblAccessCode.Text) - int.Parse(SelectedCb.Tag.ToString())).ToString();

            }

            else
            {
                lblAccessCode.Text =
                (int.Parse(lblAccessCode.Text) + int.Parse(SelectedCb.Tag.ToString())).ToString();
            }
        }

    }
}
