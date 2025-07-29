using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Clients
{
    public class clsUpdateClient
    {

        public static bool UpdateClient(clsClient client)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update From Clients
                Set
                    ClientSatusID = @StatusID
                Where
                    ClientID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StatusID", (short)client.Status);
            cmd.Parameters.AddWithValue("@ID", client.Id);

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
