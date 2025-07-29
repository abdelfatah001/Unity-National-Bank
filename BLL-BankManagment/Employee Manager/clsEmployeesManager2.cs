using DAL_BankManagment.Clients;
using DAL_BankManagment.Employees;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public partial class clsEmployeesManager
    {

        public static void LoadEmployees()
        {
            Employees = clsReadEmployee.GetAllEmployees();
        }


        public static short AddEmployee (clsEmployee employee)
        {

            short EmployeeId = -1;

            EmployeeId = clsInsertEmployee.InsertEmoloyee(employee);

            if (EmployeeId != -1)
                AddEmployeeToList(employee);

            return EmployeeId;

        }

        public static bool DeleteEmployee(short Id)
        {

            bool result = false;

            result = clsDeleteEmployee.DeleteEmployee(Id);

            if (result)
            {
                DeleteEmployeeFromList(Id);
            }
            return result;
        }

        public static bool UpdateEmployee (clsEmployee employee)
        {
            bool result = false;

            result = clsUpdateEmployee.UpdateEmployee(employee);

            if (result)
            {
                UpdateEmployeeFromList(employee);
            }
            return result;
        }


        public static List<clsEmployee> GetEmployee(string Name)
        {
            return GetEmployeeFromList(Name);
        }


    }
}
