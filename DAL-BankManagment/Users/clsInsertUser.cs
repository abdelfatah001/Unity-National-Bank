using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Users
{
    public class clsInsertUser
    {

        public static short InsertUser(clsUser user)
        {
            short UserId = -1;
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Insert into Users (UserName, Password, AccessCode, EmployeeID)
                 Values (@UserName, @Password, @AccessCode, @EmployeeID)
                 Select SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@AccessCode", user.AccessCode);
            cmd.Parameters.AddWithValue("@EmployeeID", user.Employee.Id);

            try
            {
                connection.Open();
                object ob = cmd.ExecuteScalar();
                if (ob != null && short.TryParse(ob.ToString(), out short result))
                    UserId = result;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return UserId;  
        }
    }
}
