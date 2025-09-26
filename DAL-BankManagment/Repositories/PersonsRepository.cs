using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    
    public class clsPersonRepository : IPersonsRepository
    {
        public clsPersonRepository() { }

        public clsPerson FillObject (SqlDataReader reader)
        {
            clsPerson person = new clsPerson();

            person.Id = Convert.ToInt16(reader["PersonID"]);
            person.FirstName = reader["FirstName"].ToString();
            person.LastName = reader["LastName"].ToString();
            person.Age = (byte)(DateTime.Now.Year -  ((DateTime)reader["DateOfBirth"]).Year);
            if (reader["Email"] == DBNull.Value)
                person.Email = "";

            else
                person.Email = reader["Email"].ToString().Trim();

            if (reader["Phone"] == DBNull.Value)
                person.Phone = "";

            else
                person.Phone = reader["Phone"].ToString().Trim();

            person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

            person.Country.Id = Convert.ToInt16(reader["CountryID"]);
            person.Country.Name = reader["CountryName"].ToString();

            return person;
        }

        public List<clsPerson> GetAll()
        {
            List<clsPerson> people = new List<clsPerson>();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From DetailedPersons";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsPerson person = FillObject(reader);

                    people.Add(person);
                }
                reader.Close();
            }
            catch (Exception ex) { throw new Exception("Error while fetching people" + ex.Message); }
            
            finally { connection.Close(); }

            return people;
        }

        public short Insert (clsPerson person)
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
            catch (Exception ex) { throw new Exception("Error while inserting people" + ex.Message); }
            finally { connection.Close(); }


            return PersonID;
        }

        public bool Update(clsPerson person)
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

            SqlCommand cmd = new SqlCommand(query, connection);

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
                throw new Exception("Error while updating people" + ex.Message);

            }
            finally { connection.Close(); }





            return AffectedRows > 0;
        }

        public bool Delete (short Id)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Delete From Persons 
                  Where PersonID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", Id);

            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw new Exception("Error while deleting people" + ex.Message); }

            finally { connection.Close(); }


            return (AffectedRows > 0);
        }

        
    }
}
