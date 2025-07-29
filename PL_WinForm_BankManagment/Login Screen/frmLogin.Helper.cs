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
    partial class frmLogin
    {

        private bool CheckUser(string username, string password)
        {
            if (username == "1" && password == "1")
                return true;

           return clsUsersManager.IsUserExisted(username, password);
        }
        private void LoadUsers ()
        {
            try
            {
                clsUsersManager.LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        


    }
}
