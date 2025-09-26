using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{

    public class clsUsersRepository : IUsersRepository
    {
        IEmployeesRepository _employeesRepository;
        public clsUsersRepository(IEmployeesRepository employeesRepository) 
        {   
            this._employeesRepository = employeesRepository;
        }

        public clsUser FillObject (SqlDataReader reader)
        {
            clsUser user = new clsUser();

            user.Employee = _employeesRepository.FillObject(reader);

            // user data
            user.Id = short.Parse(reader["UserID"].ToString());
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            if (reader["AccessCode"] != DBNull.Value)
                user.AccessCode = Convert.ToInt32(reader["AccessCode"]);

            else
                user.AccessCode = -1;

            return user;
        }
        public  List<clsUser> GetAll ()
        {
            List<clsUser> users = new List<clsUser>();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From DetailedUSers";

            SqlCommand cmd = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsUser user = FillObject(reader);

                    users.Add(user);
                    
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching users " + ex.Message);
            }
            finally { connection.Close(); }


            return users;
        }

        public short Insert(clsUser user)
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
            catch (Exception ex) { throw new Exception("Error while inserting user " + ex.Message); }
            finally { connection.Close(); }

            return UserId;
        }

        public bool Update (clsUser user)
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
            catch (Exception ex) { throw new Exception("Error while updating user " + ex.Message); }


            finally { connection.Close(); }

            return AffectedRows > 0;
        }

        public bool Delete (short UserID)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Delete From Users 
                Where UserID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", UserID);


            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw new Exception("Error while deleting user " + ex.Message); }
            finally { connection.Close(); }

            return AffectedRows > 0;
        }
    }
}
