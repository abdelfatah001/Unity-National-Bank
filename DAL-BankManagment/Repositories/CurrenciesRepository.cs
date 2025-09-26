using Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{

    
    public class clsCurrencyRepository : ICurrencyRepository
    {
        ICountriesRepository _countriesRepository;

        public clsCurrencyRepository (ICountriesRepository countriesRepository)
        {
            this._countriesRepository = countriesRepository;
        }

        public clsCurrency FillObject (SqlDataReader reader)
        {
            clsCurrency currency = new clsCurrency();

            currency.country = _countriesRepository.FillObject (reader);

            // currency data
            currency.Id = Convert.ToInt16(reader["CurrencyID"]);
            currency.Code = reader["CurrencyCode"].ToString();
            currency.Name = reader["CurrencyName"].ToString();
            currency.ExchangeRate = Convert.ToDouble(reader["ExchangeRate"]);
            currency.country.Id = Convert.ToInt16(reader["CountryID"]);
            currency.country.Name = reader["CountryName"].ToString();

            return currency;
        }

        public List<clsCurrency> GetAll()
        {
            List<clsCurrency> currencies = new List<clsCurrency>();
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string Query = "Select * From DetailedCurrencies";

            SqlCommand cmd = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsCurrency currency = FillObject (reader);

                    currencies.Add(currency);
                }
                reader.Close();
            }
            catch (Exception e) { throw new Exception("Error while fetching Currencies , " + e); }
            finally { connection.Close(); }

            return currencies;
        }

    }
}
