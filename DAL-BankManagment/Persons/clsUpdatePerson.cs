using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;


namespace DAL_BankManagment.Persons
{
    public class clsUpdatePerson
    {
        public static bool UpdatePerson (clsPerson person)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update Persons
                    Set
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Email = @Email,
                        Phone = @Phone,
                        CountryID = @CountryID
                    Where 
                        PersonID = @ID";

            SqlCommand cmd = new SqlCommand (query, connection);

            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", person.LastName);
            cmd.Parameters.AddWithValue("@Email", person.Email);
            cmd.Parameters.AddWithValue("@Phone", person.Phone);
            cmd.Parameters.AddWithValue("@CountryID", person.Country.Id);

            cmd.Parameters.AddWithValue("@ID", person.Id);


            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update person : " + ex.Message);

            }
            finally { connection.Close(); }





            return AffectedRows > 0;
        }


    }
}
