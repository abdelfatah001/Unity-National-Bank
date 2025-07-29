using DAL_BankManagment.Clients;
using DAL_BankManagment.Currencies;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Accounts
{
    public class clsGetAccount
    {

        public static clsAccount GetAccount(short Id)
        {
            clsAccount account = new clsAccount();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Select * From Accounts Where AccountID = @AccountID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@AccountID", Id);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    account.AccountName = (reader["AccountName"]).ToString();
                    account.Balance = Convert.ToDouble(reader["Balance"]);
                    account.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    account.client = clsGetClient.GetClient(Convert.ToInt16(reader["ClientID"]));
                    account.currency = clsGetCurrency.GetCurrency(Convert.ToInt16(reader["CurrencyID"]));
                    account.Status = (clsAccount.enAccountStatus)(Convert.ToInt32(reader["AccountStatusID"]));
                }
                else
                    account = null;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return account;
        }



    }
}
