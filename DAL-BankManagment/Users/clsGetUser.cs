using DAL_BankManagment.Employees;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Users
{
    public class clsGetUser
    {

        public static clsUser GetUser (short UserId)
        {
            clsUser user = new clsUser();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Users Where UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserId", UserId);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user.Id = UserId;
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.AccessCode = Convert.ToInt32(reader["AccessCode"]);
                    user.Employee = clsGetEmployee.GetEmployee(Convert.ToInt16(reader["EmployeeID"]));
                }

                else 
                    user = null;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return user;
        }

        public static clsUser GetUser(string UserName)
        {
            clsUser user = new clsUser();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Users Where UserName = @UserName";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user.Id = Convert.ToInt16(reader["UserID"]);
                    user.UserName = UserName;
                    user.Password = reader["Password"].ToString();
                    user.AccessCode = Convert.ToInt32(reader["AccessCode"]);
                    user.Employee = clsGetEmployee.GetEmployee(Convert.ToInt16(reader["EmployeeID"]));
                }

                else
                    user = null;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return user;
        }

    }
}
