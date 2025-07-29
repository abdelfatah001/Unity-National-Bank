using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Currencies
{
    public class clsReadCurrencys
    {
        public static List<clsCurrency> GetAllCurrencies ()
        {
            List<clsCurrency> currencies = new List<clsCurrency> ();
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string Query = "Select * From Currencies";

            SqlCommand cmd = new SqlCommand(Query, connection);

            try
            { 
                connection.Open ();
                SqlDataReader reader = cmd.ExecuteReader ();
                while (reader.Read())
                {
                    clsCurrency currency = new clsCurrency();
                    currency.Id = Convert.ToInt16(reader["CurrencyID"]);
                    currency.Code = reader["CurrencyCode"].ToString();
                    currency.Name = reader["CurrencyName"].ToString();
                    currency.ExchangeRate = Convert.ToDouble(reader["ExchangeRate"]);
                }
                reader.Close ();
            }
            catch {  }
            finally { connection.Close(); }

            return currencies;
        }

    }
}
