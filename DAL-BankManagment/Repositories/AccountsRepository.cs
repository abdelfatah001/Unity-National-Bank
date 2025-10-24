using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{ 

    public class clsAccountsRepository : IAccountsRepository 

    {

        IClientsRepository _clientsRepository;

        public clsAccountsRepository (IClientsRepository clientsRepository)
        {
            this._clientsRepository = clientsRepository;
        }

        public clsAccount FillObject (SqlDataReader reader)
        {
            clsAccount account = new clsAccount();

            try
            {
                account.client = _clientsRepository.FillObject(reader);
            }
            catch (Exception ex) { throw ex; }
            // account data
            account.Id = short.Parse(reader["AccountID"].ToString());
            account.AccountName = (reader["AccountName"]).ToString();
            account.Password = (reader["Password"]).ToString();
            account.Balance = Convert.ToDouble(reader["Balance"]);
            account.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
            account.Status = (clsAccount.enAccountStatus) (Convert.ToInt32(reader["AccountStatusID"]));
            account.currency.Name = reader["CurrencyName"].ToString();
            account.currency.Id = short.Parse(reader["CurrencyID"].ToString());

            return account;
        }

        public List<clsAccount> GetAll()
        {
            List<clsAccount> accounts = new List<clsAccount>();


            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From DetailedAccounts";


            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsAccount account = FillObject(reader);

                    accounts.Add(account);
                }

                reader.Close();
            }
            catch (Exception ex) { throw new Exception("Error while fetching accounts " + ex);  }

            finally { connection.Close(); }

            return accounts;
        }

        public short Insert(clsAccount account)
        {
            short AccountId = -1;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Insert into Accounts (AccountName, Password, Balance, CreatedDate, ClientID, AccountStatusID, CurrencyID)
                 Values (@AccountName, @Password, @Balance, @CreatedDate, @ClientID, @AccountStatusID, @CurrencyID)
                 Select SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Balance", account.Balance);
            cmd.Parameters.AddWithValue("@Password", account.Password);
            cmd.Parameters.AddWithValue("@CreatedDate", account.CreatedDate);
            cmd.Parameters.AddWithValue("@ClientID", account.client.Id);
            cmd.Parameters.AddWithValue("@AccountStatusID", Convert.ToInt32(account.Status));
            cmd.Parameters.AddWithValue("@CurrencyID", account.currency.Id);
            cmd.Parameters.AddWithValue("@AccountName", account.AccountName);

            try
            {
                connection.Open();

                object ob = cmd.ExecuteScalar();
                if (ob != null && short.TryParse(ob.ToString(), out short result))
                    AccountId = result;

            }
            catch (Exception ex) { throw new Exception("Error while inserting accounts " + ex); }
            finally { connection.Close(); }

            return AccountId;
        }

        public bool Update(clsAccount account)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update Accounts
                Set
                    Balance = @Balance,
                    AccountStatusID = @AccStatus,
                    Password = @Password
                Where 
                    AccountID = @ID";


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Balance", account.Balance);
            cmd.Parameters.AddWithValue("@Password", account.Password);
            cmd.Parameters.AddWithValue("@AccStatus", (int) account.Status);
            cmd.Parameters.AddWithValue("@ID", account.Id);

            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw new Exception("Error while updating accounts " + ex); }
            finally { connection.Close(); }

            return AffectedRows > 0;
        }

        public bool Delete (short AccountID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Delete From Accounts
                Where AccountId = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", AccountID);

            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw new Exception("Error while deleting accounts " + ex); }
            finally { connection.Close(); }

            return AffectedRows > 0;
        }

    }

}
