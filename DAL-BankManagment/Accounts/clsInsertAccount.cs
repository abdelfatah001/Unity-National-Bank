using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DAL_BankManagment.Accounts
{
    public class clsInsertAccount
    {

        public static short InsertAccount (clsAccount account)
        {
            short AccountId = -1;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Insert into Accounts (AccountName, Balance, CreatedDate, ClientID, AccountStatusID, CurrencyID)
                 Values (@AccountName, @Balance, @CreatedDate, @ClientID, @AccountStatusID, @CurrencyID)
                 Select SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Balance", account.Balance);
            cmd.Parameters.AddWithValue("@CreatedDate", account.CreatedDate);
            cmd.Parameters.AddWithValue("@ClientID", account.client.Id);
            cmd.Parameters.AddWithValue("@AccountStatusID",Convert.ToInt32(account.Status));
            cmd.Parameters.AddWithValue("@CurrencyID", account.currency.Id);
            cmd.Parameters.AddWithValue("@AccountName", account.AccountName);

            try
            {
                connection.Open();

                object ob = cmd.ExecuteScalar();
                if (ob != null && short.TryParse(ob.ToString(), out short result))
                    AccountId = result;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return AccountId;
        }
        

    }
}
