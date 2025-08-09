using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Employees_Screen
{
    partial class frmEmployeeDetails
    {



        private void ChangeDisplayedEmployeeByThis (clsEmployee emp)
        {
            if (_SelectedEmployee.ManagerId == -1)
            {
                MessageBox.Show("This has no Manager");
                return;
            }


            FillFormWithPersoneData(emp);

            cbxCountry.SelectedItem = emp.Person.Country.Name;
            cbxDepartment.SelectedItem = emp.Department;

            if (emp.ManagerId == -1)
                this.cbxManager.SelectedIndex = 0;
            else
                this.cbxManager.SelectedItem = emp.Manager.strEmployee();

        }

        private void ShowManagerInsteadOfEmployee ()
        {

            OpenShowManagerMode();

            _history.Push(_SelectedEmployee);

            ChangeDisplayedEmployeeByThis(_SelectedEmployee.Manager);

            _SelectedEmployee = _SelectedEmployee.Manager;

            if (_SelectedEmployee.ManagerId == -1)
                DisableShowManagerButton();


        }



        private void ShowEmployeeInsteadOfManager ()
        {
            EnableShowManagerButton();

            _SelectedEmployee = _history.Pop();
            ChangeDisplayedEmployeeByThis(_SelectedEmployee);

            if (_history.Count == 0)
            {
                CloseShowManagerMode();
            }
        }

    }
}
