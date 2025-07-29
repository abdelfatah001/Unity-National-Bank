using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Users
{
    public class clsDeleteUser
    {
        
        public static bool DeleteUser (short UserID)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Delete From Users 
                Where UserID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", UserID);


            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return AffectedRows > 0;
        }

    }
}
