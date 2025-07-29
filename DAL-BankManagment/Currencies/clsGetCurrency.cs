using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Currencies
{
    public class clsGetCurrency
    {
        public static clsCurrency GetCurrency(short id)
        {
            clsCurrency currency = new clsCurrency();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Currencies Where CurrencyID = @CurrencyID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@CurrencyID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    currency.Id = id;
                    currency.Code = reader["CurrencyCode"].ToString();
                    currency.Name = reader["CurrencyName"].ToString();
                    currency.ExchangeRate = Convert.ToDouble(reader["ExchangeRate"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally { connection.Close(); }

            return currency;
        }

        private enum enSearch { Name = 1, Code = 2 };

        public static clsCurrency GetCurrency(string NameOrCode)
        {
            enSearch enSearch = new enSearch();

            if (NameOrCode.Length > 3)
                enSearch = enSearch.Name;

            else 
                enSearch = enSearch.Code;


            clsCurrency currency = new clsCurrency();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string NameQuery = "Select * From Currencies Where CurrencyName = @CurrencyName";
            string CodeQuery = "Select * From Currencies Where CurrencyCode = @CurrencyCode";

            SqlCommand cmd = null;

            if (enSearch == enSearch.Name)
            {
                cmd = new SqlCommand(NameQuery, connection);
                cmd.Parameters.AddWithValue("@CurrencyName", NameOrCode);
            }
            else
            {
                cmd = new SqlCommand(CodeQuery, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", NameOrCode);
            }


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    currency.Id = Convert.ToInt16(reader["CurrencyId"]);

                    if (enSearch == enSearch.Name)
                    {
                        currency.Name =NameOrCode;
                        currency.Code = reader["CurrencyCode"].ToString();
                    }
                    else
                    {
                        currency.Name = reader["CurrencyName"].ToString();
                        currency.Code = NameOrCode; 
                    }
             
                    currency.ExchangeRate = Convert.ToDouble(reader["ExchangeRate"]);

                }
                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally { connection.Close(); }

            return currency;
        }


    }
}
