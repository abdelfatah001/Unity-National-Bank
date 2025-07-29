using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BankManagment.Persons
{
    public class clsInsertPerson
    {
        public static short InsertPerson (clsPerson person)
        {
            short PersonID = 0;
            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Insert into Persons (FirstName, LastName, DateOfBirth, Email, Phone, CountryID)
                Values (@FirstName, @LastName, @DateOfBirth, @Email, @Phone, @CountryID) 
                Select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", person.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            cmd.Parameters.AddWithValue("@Email", person.Email);
            cmd.Parameters.AddWithValue("@Phone", person.Phone);
            cmd.Parameters.AddWithValue("@CountryID", person.Country.Id);

            try
            {
                connection.Open();

                object ob = cmd.ExecuteScalar();

                if (ob != null && short.TryParse(ob.ToString(), out short result))
                    PersonID = result;

            }
            catch (Exception ex)  {  }
            finally { connection.Close(); }


            return PersonID;
        }
        
           


    }
}
