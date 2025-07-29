using Models;
using DAL_BankManagment.Persons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Clients
{
    public class clsReadClients
    {

        public static List<clsClient> GetAllClients()
        {
            List<clsClient> clients = new List<clsClient>();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Clients";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsClient client = new clsClient();

                    client.Status = (clsClient.enClientStatus)Convert.ToInt32(reader["ClientStatusID"]);
                    client.Person = clsGetPerson.GetPerson(Convert.ToInt16(reader["PersonID"]));
                    client.JoinData = Convert.ToDateTime(reader["JoinDate"]);

                    clients.Add(client);
                }

                reader.Close(); 
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return clients;
        }
    }
}
