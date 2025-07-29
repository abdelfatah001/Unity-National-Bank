using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web;

namespace DAL_BankManagment.Employees
{
    public class clsInsertEmployee
    {

        public static short InsertEmoloyee (clsEmployee employee)
        {
            short EmployeeID = -1;

            SqlConnection connection = new SqlConnection(DBConnection._connectionString);

            string query =
                @"Insert into Employees (Salary, PersonID, DepartmentID, ManagerID)
                Values (@Salary, @PersonID, @DepartmentID, @ManagerID)
                Select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@PersonID", employee.PersonId);
            cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt16(employee.Department));
            cmd.Parameters.AddWithValue("@ManagerID", employee.ManagerId);


            try
            {
                connection.Open();
                 
                object ob = cmd.ExecuteScalar();

                if (ob != null && short.TryParse(ob.ToString(), out short result))
                    EmployeeID = result;



            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return EmployeeID;
        }

    }
}
