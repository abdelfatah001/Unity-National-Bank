using Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using DAL_BankManagment.Persons;

namespace DAL_BankManagment.Employees
{
    public class clsReadEmployee
    {

        private static List<clsEmployee> SetEmployees()
        {
            List<clsEmployee> employees = new List<clsEmployee>();

           SqlConnection connection = new SqlConnection(DBConnection._connectionString);

           string query = "Select * From Employees";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    clsEmployee employee = new clsEmployee();
                    employee.Salary = Convert.ToDouble(reader["Salary"]);
                    employee.Person = clsGetPerson.GetPerson(Convert.ToInt16(reader["PersonID"]));

                    byte DepartmentID = Convert.ToByte(reader["DepartmentID"]);
                    employee.Department = (clsEmployee.enDepartments)DepartmentID;

                    employee.ManagerId = Convert.ToInt16(reader["ManagerID"]);

                    employees.Add(employee);
                }

                reader.Close();
            }
            catch (Exception exec)
            {
            }
            finally { connection.Close(); }

            return employees;
        }

        private static void SetEmployeesManagers(List<clsEmployee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.ManagerId != 0) 
                    employee.Manager = clsGetEmployee.GetEmployee(employee.ManagerId, employees);
            }
        }

        public static List<clsEmployee> GetAllEmployees ()
        {
            List<clsEmployee> employees = new List<clsEmployee>();

            employees = SetEmployees();
            SetEmployeesManagers(employees);

            return employees;
        }


    }
}
