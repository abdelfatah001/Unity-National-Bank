using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Models;
using DAL_BankManagment.Countries;


namespace DAL_BankManagment.Persons
{
    public class clsGetPerson
    {

        public static clsPerson GetPerson (short id)
        {
            clsPerson person = new clsPerson();
            
            SqlConnection connection = new SqlConnection (DBConnection._connectionString);

            string query = "Select * From Persons Where PersonId = @PersonId";

            SqlCommand cmd = new SqlCommand (query, connection);

            cmd.Parameters.AddWithValue("@PersonId", id);

            try
            {
                connection.Open ();
                SqlDataReader reader = cmd.ExecuteReader ();

                if (reader.Read())
                {
                    person.Id = id;
                    person.FirstName = reader["FirstName"].ToString();
                    person.LastName = reader["LastName"].ToString();

                    if (reader["Email"] != DBNull.Value)
                        person.Email = reader["Email"].ToString();
                    else
                        person.Email = "";

                    if (reader["Phone"] != DBNull.Value)
                        person.Phone = reader["Phone"].ToString();
                    else
                        person.Phone = "";

                    person.Age =
                        (byte)((DateTime.Now.Year) - (Convert.ToDateTime(reader["DateOfBirth"]).Year));

                    person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    person.Country = clsGetCountry.GetCountry(Convert.ToInt16(reader["CountryID"]));
                }
                else
                    person = null;

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Get Person, : " + ex.Message);
            }
            finally { connection.Close(); }



            return person;

        }

    }
}
