using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Security.Authentication;

namespace DAL_BankManagment.Countries
{
    public class clsReadCountry
    {
        public static List<clsCountry> GetAllCountries ()
        {
            List<clsCountry> countries = new List<clsCountry> ();

            SqlConnection connection = new SqlConnection (DBConnection._connectionString);

            string query = "Select * From Countries";

            SqlCommand command = new SqlCommand (query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader ();
                while (reader.Read())
                {
                    clsCountry country = new clsCountry();
                    country.Id = Convert.ToInt16 (reader["CountryID"]);
                    country.Name = reader["CountryName"].ToString();
                    //country.Currency =  clsCurrency.

                    countries.Add (country);
                }
            }
            catch (Exception ex)   {  }
            finally { connection.Close(); }

            return countries;
        }

    }
}
