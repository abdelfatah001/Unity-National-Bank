using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Clients
{
    public class clsDeleteClient
    {

        public static bool DeleteClient(short ClientID)
        {
            int AffectedRows = 0;


            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Delete From Clients
                Where ClientID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ClientID);

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
