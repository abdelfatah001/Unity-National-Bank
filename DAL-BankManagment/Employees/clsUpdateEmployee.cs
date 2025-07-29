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
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update Employees 
                Set
                    Salary = @Salary,
                    ManagerID = @ManagerID
                Where 
                    EmployeeID = @EmployeeID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@EmployeeID", employee.Id);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@ManagerID", employee.ManagerId);

            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            { connection.Close(); }

            return (AffectedRows > 0);
        }

    }
}
