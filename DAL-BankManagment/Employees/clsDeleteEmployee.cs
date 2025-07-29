using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Employees
{
    public class clsDeleteEmployee
    {
        public static bool DeleteEmployee (short Id)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = @"Delete From Employees 
                            Where EmployeeID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", Id);


            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { } 

            finally { connection.Close(); }

            return (AffectedRows > 0);
        }
    }
}
