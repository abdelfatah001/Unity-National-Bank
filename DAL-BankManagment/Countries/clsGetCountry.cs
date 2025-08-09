using DAL_BankManagment.Currencies;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Countries
{
    public class clsGetCountry
    {


        public static clsCountry GetCountry(short Id)
        {
            clsCountry country = new clsCountry();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Countries Where CountryID = @CountryID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@CountryID", Id);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    country.Id = Id;
                    country.Name = reader["CountryName"].ToString();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get country " + ex.Message); 
            }
            finally { connection.Close(); }


            return country;
        }

        public static clsCountry GetCountry(string Name)
        {
            clsCountry country = new clsCountry();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Countries Where CountryName = @CountryName";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@CountryName", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    country.Id = Convert.ToInt16(reader["CountryID"]);
                    country.Name = Name;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get country " + ex.Message);
            }
            finally { connection.Close(); }


            return country;
        }

        public static clsCountry GetCountryByCurrencyID(short Id)
        {
            clsCountry country = new clsCountry();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Countries Where CurrencyID = @CurrencyID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("CurrencyID", Id);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    country.Id = Convert.ToInt16(reader["CountryID"]);
                    country.Name = reader["CountryName"].ToString();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get country " + ex.Message);
            }
            finally { connection.Close(); }


            return country;
        }

    }
}
