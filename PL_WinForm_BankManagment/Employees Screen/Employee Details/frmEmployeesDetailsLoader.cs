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

        // Fill Form With Data

        private void LoadCountries()
        {
            if (clsCountriesManager.Countries.Count == 0)
            {
                try
                {
                    clsCountriesManager.LoadCountries();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }


        private void FillCountryComboBox()
        {
            foreach (clsCountry country in clsCountriesManager.Countries)
            {
                cbxCountry.Items.Add(country.Name);
            }
            cbxCountry.SelectedItem = _SelectedEmployee.Person.Country.Name;
        }
        private void FillDepartmentsComboBox()
        {
            for (short i = 1; i < 9; i++)
            {
                clsEmployee.enDepartments department = (clsEmployee.enDepartments)i;
                cbxDepartment.Items.Add(department);
            }
            cbxDepartment.SelectedItem = _SelectedEmployee.Department;
        }

        private void FillEmployeesComboBox()
        {
            cbxManager.Items.Add("- None -");

            foreach (clsEmployee emp in clsEmployeesManager.Employees)
            {
                cbxManager.Items.Add(emp.strEmployee());

            }


            if (_SelectedEmployee.ManagerId == -1)
                cbxManager.SelectedIndex = 0;

            else
                cbxManager.SelectedItem = _SelectedEmployee.Manager.strEmployee();

        }
        private void FillFormWithPersoneData (clsEmployee emp = null)
        {
            if (emp == null)
                emp =_SelectedEmployee;

            txtFirstName.Text = emp.Person.FirstName;
            txtLastName.Text = emp.Person.LastName;
            txtEmail.Text = emp.Person.Email;
            txtPhone.Text = emp.Person.Phone;
            lblAge.Text = emp.Person.Age.ToString();
            txtSalary.Text = emp.Salary.ToString();

        }
        

        private void FillFormWithEmployeeData()
        {
            cbxCountry.Text = _SelectedEmployee.Person.Country.Name;
            cbxDepartment.Text = _SelectedEmployee.Department.ToString();

            if (_SelectedEmployee.ManagerId == -1)
                cbxManager.Text = "- None -";

            else
                cbxManager.Text = _SelectedEmployee.Manager.strEmployee();

        }

        private void FillForm ()
        {

            FillFormWithPersoneData();

            if (Mode == enMode.Updatable)
            {
                FillCountryComboBox();
                FillDepartmentsComboBox();
                FillEmployeesComboBox();
            }

            else if (Mode == enMode.ReadOnly) 
            {
                FillFormWithEmployeeData();
            }

            

        }






    }
}
