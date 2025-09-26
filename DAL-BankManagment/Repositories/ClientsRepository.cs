using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class clsClientsRepository : IClientsRepository
    {

        IPersonsRepository _personsRepository;

        public clsClientsRepository (IPersonsRepository personsRepository) 
        {
            this._personsRepository = personsRepository;
        }

        public clsClient FillObject(SqlDataReader reader)
        {
            clsClient client = new clsClient ();
            try
            {
                client.Person = _personsRepository.FillObject(reader);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            client.Id = Convert.ToInt16(reader["ClientID"]);
            client.Status = (clsClient.enClientStatus)Convert.ToInt32(reader["ClientStatusID"]);
            client.JoinData = Convert.ToDateTime(reader["JoinDate"]);

            return client;
        }

        public List<clsClient> GetAll ()
        {
            List<clsClient> clients = new List<clsClient>();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From DetailedClients\r\n";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsClient client = FillObject(reader);

                    clients.Add(client);
                }

                reader.Close();
            }
            catch (Exception ex) { throw new Exception("Error while fetching clients : " + ex); }
            finally { connection.Close(); }

            return clients;
        } 

        public short Insert(clsClient client)
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
            catch (Exception ex) { throw new Exception("Error while inserting client : " + ex); }
            finally { connection.Close(); }

            return ClientId;
        }


        public bool Update (clsClient client)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update Clients
                Set
                    ClientStatusID = @StatusID

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
            catch (Exception ex) { throw new Exception("Error while updating client : " + ex); }
            finally { connection.Close(); }

            return AffectedRows > 0;
        }

        public bool Delete (short ClientID)
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
            catch (Exception ex) { throw new Exception("Error while deleting client : " + ex); }
            finally { connection.Close(); }

            return AffectedRows > 0;

        }
    }
}
