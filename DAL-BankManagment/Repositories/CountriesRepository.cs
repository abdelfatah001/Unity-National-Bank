using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{


    public class clsCountriesRepository : ICountriesRepository
    {
        public clsCountriesRepository() { }

        public clsCountry FillObject (SqlDataReader reader)
        {
            clsCountry country = new clsCountry();
            country.Id = Convert.ToInt16(reader["CountryID"]);
            country.Name = reader["CountryName"].ToString();

            return country; 
        }

        public List<clsCountry> GetAll ()
        {
            List<clsCountry> countries = new List<clsCountry>();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Countries";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clsCountry country = FillObject(reader);
                    
                    countries.Add(country);
                }
            }
            catch (Exception ex) { throw new Exception("Error while fetchimg countries : " + ex); }
            finally { connection.Close(); }

            return countries;
        }
    }
}
