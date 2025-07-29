using Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BankManagment.Persons;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics.Eventing.Reader;


namespace DAL_BankManagment.Employees
{
    public class clsGetEmployee
    {

        public static clsEmployee GetEmployee (short Id, List<clsEmployee>employees)
        {
            clsEmployee employee = new clsEmployee();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Employees Where EmployeeID = @EmployeeID";

            SqlCommand cmd = new SqlCommand (query, connection);
            cmd.Parameters.AddWithValue ("@EmployeeID", Id);

            try
            {
                connection.Open (); 
                SqlDataReader reader = cmd.ExecuteReader ();
                if (reader != null)
                {
                    employee.Salary = Convert.ToDouble(reader["Salary"]);
                    try
                    {
                        employee.Person = clsGetPerson.GetPerson(Convert.ToInt16(reader["PersonID"]));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    if (reader["ManagerID"] != DBNull.Value)
                        employee.ManagerId = Convert.ToInt16(reader["ManagerID"]);
                    else
                        employee.ManagerId = 0;
                    

                    byte DepartmentID = Convert.ToByte(reader["DepartmentID"]);
                    employee.Department = (clsEmployee.enDepartments)DepartmentID;

                    if (employee.ManagerId != 0)
                    {
                        foreach (var emp in employees)
                        {
                            if (employee.ManagerId == emp.Id)
                            {
                                employee.Manager = emp;
                                break;
                            }
                        }
                    }

                    else
                        employee.Manager = null;
                }

                else
                    employee = null;

                reader.Close();
            }
            catch (Exception ex)  { }
            finally { connection.Close (); }

            return employee;
        }

        public static clsEmployee GetEmployee(short Id)
        {
            clsEmployee employee = new clsEmployee();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Employees Where EmployeeID = @EmployeeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EmployeeID", Id);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    employee.Id = Id;
                    employee.Salary = Convert.ToDouble(reader["Salary"]);
                    try
                    {
                        employee.Person = clsGetPerson.GetPerson(Convert.ToInt16(reader["PersonID"]));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    if (reader["ManagerID"] != DBNull.Value)
                        employee.ManagerId = Convert.ToInt16(reader["ManagerID"]);
                    else
                        employee.ManagerId = 0;


                    byte DepartmentID = Convert.ToByte(reader["DepartmentID"]);
                    employee.Department = (clsEmployee.enDepartments)DepartmentID;
                }

                else
                    employee = null;

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get employee, " + ex.Message);
            }
            finally { connection.Close(); }

            return employee;
        }
    }
}
