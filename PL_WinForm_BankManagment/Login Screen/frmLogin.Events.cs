using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment
{
    partial class frmLogin
    {


        private void btnEnter_MouseClick(object sender, EventArgs e)
        {
            if (CheckUser(txtUsername.Text, txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Retry;
                MessageBox.Show("Invalid username or password");
            }

            this.Close();

        }

        private void btnCancel_MouseClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnEnter_MouseClick(sender, e);
                    break;

                case Keys.Escape:
                    btnCancel_MouseClick(sender, e);
                    break;
            }
        }

    }
}
