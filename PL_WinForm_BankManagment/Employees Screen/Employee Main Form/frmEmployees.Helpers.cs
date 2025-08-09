using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Employees_Screen
{
    partial class frmEmployees
    {


        private void ShowEmployeeDetailsForm (clsEmployee employee)
        {
            frmEmployeeDetails frm = new frmEmployeeDetails(employee, this);
            frm.Show();
        }


    }
}
