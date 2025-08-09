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
    partial class frmEmployeeDetails
    {


        // Save Employee Data after Update 



        private bool IsEmployeeDataChanged()
        {
            /*if (SelectedEmployee.Manager.strEmployee() != cbxManager.Text.ToString())
                MessageBox.Show("Manager changed");*/


            return
                ((_SelectedEmployee.Manager == null && cbxManager.SelectedIndex != 0) || // if it changed from has no manager to has manager
                  _SelectedEmployee.Manager != null && (_SelectedEmployee.Manager.strEmployee() != cbxManager.Text.ToString()) ||
                 _SelectedEmployee.Department.ToString() != cbxDepartment.Text ||
                 _SelectedEmployee.Salary != double.Parse(txtSalary.Text));

        }

        private bool IsEmployeePersonDataChanged()
        {
            return
                 (_SelectedEmployee.Person.FirstName != txtFirstName.Text ||
                  _SelectedEmployee.Person.LastName != txtLastName.Text ||
                  _SelectedEmployee.Person.Email != txtEmail.Text ||
                  _SelectedEmployee.Person.Phone != txtPhone.Text ||
                  _SelectedEmployee.Person.Country.Name != cbxCountry.Text);
        }

        private void UpdateSelectedEmployeePersonData()
        {
            _SelectedEmployee.Person.FirstName = txtFirstName.Text;
            _SelectedEmployee.Person.LastName = txtLastName.Text;
            _SelectedEmployee.Person.Email = txtEmail.Text;
            _SelectedEmployee.Person.Phone = txtPhone.Text;
            _SelectedEmployee.Person.Age = byte.Parse(lblAge.Text);
            _SelectedEmployee.Person.Country = clsCountriesManager.GetCountry(cbxCountry.Text);
        }



        private void UpdateSelectedEmployeeData()
        {
            if (cbxManager.SelectedIndex == 0 || cbxManager.SelectedItem.ToString() == _SelectedEmployee.strEmployee())
            {
                _SelectedEmployee.ManagerId = -1;
                _SelectedEmployee.Manager = null;
            }
            else
            {
                _SelectedEmployee.ManagerId = short.Parse(cbxManager.Text.Split('-')[0].Trim());
                _SelectedEmployee.Manager = clsEmployeesManager.GetManager(_SelectedEmployee.ManagerId);
            }

       

            _SelectedEmployee.Department = (clsEmployee.enDepartments)(cbxDepartment.SelectedIndex + 1);
            _SelectedEmployee.Salary = double.Parse(txtSalary.Text);

        }



        private void SaveEmployeeAfterUpdate()
        {
            bool IsEmployeeChanged = IsEmployeeDataChanged();

            bool IsPersonChanged = IsEmployeePersonDataChanged();


            if (!IsEmployeeChanged && !IsPersonChanged)
            {
                this.Close();
                return;
            }

            bool UpdateSuccess = true;


            if (IsPersonChanged)
            {
                UpdateSelectedEmployeePersonData();
                try
                {
                    UpdateSuccess &= clsEmployeesManager.UpdatePerson(_SelectedEmployee.Person);
                    _EmployeeForm.UpdateUpdatedEmployeeInDGV(_SelectedEmployee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            if (IsEmployeeChanged)
            {
                UpdateSelectedEmployeeData();
                try
                {
                    UpdateSuccess &= clsEmployeesManager.UpdateEmployee(_SelectedEmployee);
                    _EmployeeForm.UpdateUpdatedEmployeeInDGV(_SelectedEmployee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (UpdateSuccess)
                MessageBox.Show("Employee updated successfully");

            else
                MessageBox.Show("Not all data updated");
                
            this.Close();

        }

    }
}
