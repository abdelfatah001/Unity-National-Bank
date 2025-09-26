using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{

    public class clsEmployeesRepository  : IEmployeesRepository
    {
        IPersonsRepository _personsRepository;

        public clsEmployeesRepository (IPersonsRepository personsRepository)
        {
            this._personsRepository = personsRepository;
        }

        public clsEmployee FillObject (SqlDataReader reader)
        {
            clsEmployee employee = new clsEmployee ();

            try
            {
                employee.Person = _personsRepository.FillObject(reader);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }   
            

            // employee data 
            employee.Id = short.Parse(reader["EmployeeID"].ToString());
            employee.Salary = Convert.ToDouble(reader["Salary"]);
            byte DepartmentID = Convert.ToByte(reader["DepartmentID"]);
            employee.Department = (clsEmployee.enDepartments)DepartmentID;

           if (reader["ManagerId"] != DBNull.Value)
                employee.ManagerId = Convert.ToInt16(reader["ManagerID"]);

            else
                employee.ManagerId = -1;

            employee.Manager = null;

            return employee;
        }

        public List<clsEmployee> GetAll()
        { // this function fill List with all employees data except each employee manager set it null
            List<clsEmployee> employees = new List<clsEmployee>();

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = "Select * From DetailedEmployees\r\n";


            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clsEmployee employee = FillObject(reader);

                    employees.Add(employee);
                }

                reader.Close();
            }
            catch (Exception exec)
            {
                throw new Exception("Error while fetching employees " + exec.Message);
            }
            finally { connection.Close(); }

            return employees;
        }

        public short Insert (clsEmployee employee)
        {
            short EmployeeID = -1;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Insert into Employees (Salary, PersonID, DepartmentID, ManagerID)
                Values (@Salary, @PersonID, @DepartmentID, @ManagerID)
                Select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@PersonID", employee.Person.Id);
            cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt16(employee.Department));
            cmd.Parameters.AddWithValue("@ManagerID", employee.Manager.Id);


            try
            {
                connection.Open();

                object ob = cmd.ExecuteScalar();

                if (ob != null && short.TryParse(ob.ToString(), out short result))
                    EmployeeID = result;



            }
            catch (Exception ex) { throw new Exception("Error while inserting employee" + ex.Message); }
            finally { connection.Close(); }

            return EmployeeID;
        }

        public bool Update (clsEmployee employee)
        {
            int AffectedRows = 9;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Update Employees 
                Set
                    DepartmentID = @DepartmentID,
                    Salary = @Salary,
                    ManagerID = @ManagerID

                Where 
                    EmployeeID = @EmployeeID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@EmployeeID", employee.Id);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@DepartmentID", (int)employee.Department);

            if (employee.ManagerId != -1)
                cmd.Parameters.AddWithValue("@ManagerID", (int)employee.Manager.Id);

            else
                cmd.Parameters.AddWithValue("@ManagerID", DBNull.Value);


            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update employee : " + ex.Message);
            }
            finally
            { connection.Close(); }

            return AffectedRows > 0;
        }

        public bool Delete (short Id)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query = @"Delete From Employees 
                            Where EmployeeID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", Id);


            try
            {
                connection.Open();
                AffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception("Error while deleting employee" + ex.Message); }

            finally { connection.Close(); }

            return (AffectedRows > 0);
        }

    }
}
