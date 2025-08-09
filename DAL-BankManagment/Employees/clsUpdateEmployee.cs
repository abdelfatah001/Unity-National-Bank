using DAL_BankManagment.Persons;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Employees
{
    public class clsUpdateEmployee
    {

        public static bool UpdateEmployee (clsEmployee employee)
        {
            int AffectedRows = 9;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update Employees 
                Set
                    DepartmentID = @DepartmentID,
                    Salary = @Salary,
                    ManagerID = @ManagerID

                Where 
                    EmployeeID = @EmployeeID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@EmployeeID", employee.Id);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@DepartmentID", (int) employee.Department);

            if (employee.ManagerId != -1)
                cmd.Parameters.AddWithValue("@ManagerID", (int) employee.ManagerId);

            else
                cmd.Parameters.AddWithValue("@ManagerID", DBNull.Value);


            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            { 
                throw new Exception("Failed to update employee : " + ex.Message);
            }
            finally
            { connection.Close(); }

            return AffectedRows > 0;
        }

    }
}
