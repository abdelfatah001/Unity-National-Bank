using Models;
using PL_WinForm_BankManagment.Employees_Screen;
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

        private void DisappearUserPanel()
        {
            pnlUserInfo.Visible = false;
        }

        private void ShowUserPanel()
        {
            pnlUserInfo.Visible = true;
        }

        private void ShowEmployeeForm(clsEmployee employee)
        {
            Panel pnlEmp = new Panel();

            frmEmployeeDetails frm = new frmEmployeeDetails(_SelectedUser.Employee);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;

            this.Size = new System.Drawing.Size(707, 492);

            frm.Dock = DockStyle.Fill;

            frm.CloseEmoloyeeDetails += (s, e) =>
            {
                this.Size = new System.Drawing.Size(668, 652);

                // Remove employee panel
                this.Controls.Remove(pnlEmp);
                pnlEmp.Dispose();

                // Show the user panel again
                ShowUserPanel();
            };


            pnlEmp.Controls.Add(frm);
            pnlEmp.Dock = DockStyle.Fill;
            frm.Show();

            this.Controls.Add(pnlEmp);
        }
    }
}
