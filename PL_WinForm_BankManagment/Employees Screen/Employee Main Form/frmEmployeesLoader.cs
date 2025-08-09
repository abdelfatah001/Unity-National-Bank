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



        private void LoadEmployees()
        {
            if (clsEmployeesManager.Employees.Count == 0)
            {
                try
                {
                    clsEmployeesManager.LoadEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }

        }
        private void CreateDataGridViewColunms()
        {
            dgvEmployees.Columns.Clear();

            dgvEmployees.Columns.Add("ID", "ID");
            dgvEmployees.Columns.Add("FirstName", "First Name");
            dgvEmployees.Columns.Add("LastName", "Last Name");
            dgvEmployees.Columns.Add("Department", "Department");
            dgvEmployees.Columns.Add("Country", "Country");
            dgvEmployees.Columns.Add("Salary", "Salary");
            dgvEmployees.Columns.Add("Email", "Email");
            dgvEmployees.Columns.Add("Phone", "Phone");
            dgvEmployees.Columns.Add("Age", "Age");
            dgvEmployees.Columns.Add("ManagerId", "Manager ID");

            dgvEmployees.ReadOnly = true;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
        }

        private void FillEmployeesDGV()
        {


            CreateDataGridViewColunms();

            if (clsEmployeesManager.Employees.Count == 0)
            {
                MessageBox.Show("No Employees Founded");
            }

            foreach (clsEmployee employee in clsEmployeesManager.Employees)
            {

                int RowIndex = dgvEmployees.Rows.Add
                (employee.Id, employee.Person.FirstName, employee.Person.LastName, employee.Department.ToString(),
                employee.Person.Country.Name, employee.Salary, employee.Person.Email, employee.Person.Phone,
                employee.Person.Age, employee.ManagerId);



                dgvEmployees.Rows[RowIndex].Tag = employee;
            }




        }
        public void UpdateUpdatedEmployeeInDGV(clsEmployee employee)
        {
            int index = IndexOfClickedEmployee;
            DataGridViewRow row = dgvEmployees.Rows[index];

            if (row != null)
            {
                row.Cells["ID"].Value = employee.Id.ToString();
                row.Cells["FirstName"].Value = employee.Person.FirstName;
                row.Cells["LastName"].Value = employee.Person.LastName;
                row.Cells["Department"].Value = employee.Department;
                row.Cells["Country"].Value = employee.Person.Country.Name;
                row.Cells["Salary"].Value = employee.Salary;
                row.Cells["Email"].Value = employee.Person.Email;
                row.Cells["Phone"].Value = employee.Person.Phone;
                row.Cells["Age"].Value = employee.Person.Age;
                row.Cells["ManagerId"].Value = employee.ManagerId;
            }
        }

    }
}
