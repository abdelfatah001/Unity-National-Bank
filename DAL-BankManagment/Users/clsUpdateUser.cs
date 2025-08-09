using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Users
{
    public class clsUpdateUser
    {

        public static bool UpdateUser(clsUser user)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update Users
                Set
                    UserName = @UserName,
                    Password = @Password,
                    AccessCode = @AccessCode
                Where 
                    UserID = @Id";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@AccessCode", user.AccessCode);
            cmd.Parameters.AddWithValue("@Id", user.Id);

            try
            {
                connection.Open();

                AffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            { 
                throw new Exception("Error in update user : " + ex.Message);    
            }

            finally { connection.Close(); }

            return AffectedRows > 0;
        }

    }
}
