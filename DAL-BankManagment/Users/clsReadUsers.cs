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
    public class clsReadUsers
    {
        public static List<clsUser> GetAllUsers()
        {
            List<clsUser> users = new List<clsUser>();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From Users";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsUser user = new clsUser();
                    user.Id = short.Parse(reader["UserID"].ToString());
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    if (reader["AccessCode"] != DBNull.Value)
                        user.AccessCode = Convert.ToInt32(reader["AccessCode"]);

                    else
                        user.AccessCode = -1;
                    try
                    {
                        user.Employee = clsGetEmployee.GetEmployee(Convert.ToInt16(reader["EmployeeID"]));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }


                    users.Add(user);
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                throw new Exception("Failed to Load Users, " + ex.Message);
            }
            finally { connection.Close(); }

            return users;
        }
    }
}
