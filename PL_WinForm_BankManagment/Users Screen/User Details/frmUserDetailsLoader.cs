using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Users_Screen
{
    partial class frmUserDetails
    {



        // Fill Form with Data

        private void DecodeUserAccessCode()
        {
            if (_SelectedUser.AccessCode == 0)
                return;

            if (_SelectedUser.AccessCode == 1962)
            {
                CheckAllAccessibilityBox();
            }

            else
            {
                foreach (var cb in _UserAccessibility)
                {
                    int CheckBoxAccessCode = int.Parse(cb.Tag.ToString());
                    if ((_SelectedUser.AccessCode & CheckBoxAccessCode) == CheckBoxAccessCode)
                    {
                        cb.Checked = true;
                    }
                }
            }

        }


        private void FillFormWithUserData()
        {
            if (_SelectedUser != null)
            {
                txtUsername.Text = _SelectedUser.UserName;
                txtPassword.Text = _SelectedUser.Password;

                lblFirstName.Text = _SelectedUser.Employee.Person.FirstName;
                lblLastName.Text = _SelectedUser.Employee.Person.LastName;
                lblEmployeeId.Text = _SelectedUser.Employee.Id.ToString();

                DecodeUserAccessCode();

                lblAccessCode.Font = new Font(lblAccessCode.Font.FontFamily, 18, lblAccessCode.Font.Style);
                lblAccessCode.Text = _SelectedUser.AccessCode.ToString();
            }
            else
            {
                this.Close();
                MessageBox.Show("Error with passing user object");
            }
        }

    }
}
