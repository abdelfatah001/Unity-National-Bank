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
        { // this function fill List with all employees data except each employee manager set it null
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

                    employee.Id = short.Parse(reader["EmployeeID"].ToString());
                    employee.Salary = Convert.ToDouble(reader["Salary"]);
                    try
                    {
                        employee.Person = clsGetPerson.GetPerson(Convert.ToInt16(reader["PersonID"]));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);    
                    }

                    byte DepartmentID = Convert.ToByte(reader["DepartmentID"]);
                    employee.Department = (clsEmployee.enDepartments)DepartmentID;
                    
                    if (reader["ManagerId"] != DBNull.Value)
                       employee.ManagerId = Convert.ToInt16(reader["ManagerID"]);

                    else
                        employee.ManagerId = -1;

                    employee.Manager = null;
                    employees.Add(employee);
                }

                reader.Close();
            }
            catch (Exception exec)
            {
                throw new Exception("Failed to load employees " + exec.Message);
            }
            finally { connection.Close(); }

            return employees;
        }

        public static clsEmployee GetManager (short Id, List<clsEmployee> employees)
        {
            foreach (clsEmployee employee in employees)
            {
                if (Id == employee.Id)
                    return employee; 
            }

            return null;
        }

        private static void SetEmployeesManagers(List<clsEmployee> employees)
        { // after filling the list with employees and make their manager is null
            // this function set employee manager foreach index in this list
            foreach (clsEmployee employee in employees)
            {
                // if this employee has manager and this manager is not assigned = null get it 
                if (employee.ManagerId != -1 && employee.Manager == null)
                {
                    try
                    {
                        employee.Manager = GetManager(employee.ManagerId, employees);
                    }
                    catch (Exception ex) 
                    { 
                        throw new Exception(ex.Message); 
                    }
                
                }
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
