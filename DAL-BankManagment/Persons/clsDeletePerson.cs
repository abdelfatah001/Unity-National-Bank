using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL_BankManagment.Persons
{

    public class clsDeletePerson
    {

        public static bool DeletePerson (short Id)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Delete From Persons 
                  Where PersonID = @ID";

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
