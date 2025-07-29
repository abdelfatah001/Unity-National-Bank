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
    public class clsGetClient
    {
        
        public static clsClient GetClient (short Id)
        {
            clsClient client = new clsClient();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Select * From Clients Where ClientID = @CLientID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CLientID", Id);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    client.Id = Id;
                    client.Status = (clsClient.enClientStatus)reader["ClientStatusID"];
                    client.Person = clsGetPerson.GetPerson(Convert.ToInt16(reader["PersonID"]));
                    client.JoinData = Convert.ToDateTime(reader["JoinDate"]);
                }
                else
                    client = null;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return client;
        }


        public static clsClient GetClient(string Name)
        {
            clsClient client = new clsClient();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Select * From Clients
                  Join Persons on Clients.PersonID = Persons.PersonID
                  Where LastName = @LastName";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LastName", Name);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    client.Id = Convert.ToInt16(reader["ClientID"]);
                    client.Status = (clsClient.enClientStatus)reader["ClientStatusID"];
                    client.Person = clsGetPerson.GetPerson(Convert.ToInt16(reader["PersonID"]));
                    client.JoinData = Convert.ToDateTime(reader["JoinDate"]);
                }

                else
                    client = null;

                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return client;
        }


    }
}
