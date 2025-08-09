using Manager;
using Models;
using PL_WinForm_BankManagment.Employees_Screen;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Users_Screen
{
    partial class frmUserDetails
    {
        private void FillUserAccessibilityList()
        {
            _UserAccessibility.Add(cbReadAccounts);
            _UserAccessibility.Add(cbAdminAccounts);
            _UserAccessibility.Add(cbReadClients);
            _UserAccessibility.Add(cbAdminClients);
            _UserAccessibility.Add(cbReadUsers);
            _UserAccessibility.Add(cbAdminUsers);
            _UserAccessibility.Add(cbReadEmployees);
            _UserAccessibility.Add(cbAdminEmployees);
            _UserAccessibility.Add(cbCurrencies);
            _UserAccessibility.Add(cbRegistrations);
            _UserAccessibility.Add(cbTransactions);
            _UserAccessibility.Add(cbAdmin);
        }

        private void CheckAllAccessibilityBox()
        {
            foreach (var cb in _UserAccessibility)
            {
                cb.Checked = true;
            }
        }
        private void UncheckAllAccessibilityBox()
        {
            foreach (var cb in _UserAccessibility)
            {
                cb.Checked = false;
            }
        }

        private void AssignUser ()
        {
            if (_SelectedUser.Employee.ManagerId != -1) 
            _SelectedUser.Employee.Manager = clsEmployeesManager.GetManager(_SelectedUser.Employee.ManagerId);
        }


    }
}
