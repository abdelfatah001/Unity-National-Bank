using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Clients
{
    public class clsInsertClient
    {

        public static short InsertClient(clsClient client)
        {
            short ClientId = -1;
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Insert Into Clients (ClientStatusID, PersonID, JoinDate)
                 Values (@ClientStatusID, PersonID, JoinDate)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ClienStatusID", Convert.ToInt32(client.Status));
            cmd.Parameters.AddWithValue("@PersonID", client.Person.Id);
            cmd.Parameters.AddWithValue("@JoinDate", client.JoinData);


            try
            {
                connection.Open();

                object ob = cmd.ExecuteScalar();

                if (ob != null && short.TryParse(ob.ToString(), out short result)) 
                    ClientId = result;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return ClientId;
        }

    }
}
