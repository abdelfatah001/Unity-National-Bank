using Models;
using PL_WinForm_BankManagment.Employees_Screen;
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
        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridView dgvEmployees = (DataGridView)sender;
                DataGridViewRow Row = dgvEmployees.Rows[e.RowIndex];

                clsEmployee employee = Row.Tag as clsEmployee;

                if (employee != null)
                {
                    IndexOfClickedEmployee = e.RowIndex;
                    ShowEmployeeDetailsForm(employee);
                }

            }
        }
    }
}
