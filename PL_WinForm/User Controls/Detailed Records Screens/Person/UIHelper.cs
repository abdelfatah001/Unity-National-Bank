using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PL_WinForm.User_Controls.Details_Presenter
{
    partial class ctrlDetailedPerson
    {
        public void LockUpdate()
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            cbCountries.Enabled = false;
        }

        public void DelockUpdate()
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            cbCountries.Enabled = true;
        }

    }
}
