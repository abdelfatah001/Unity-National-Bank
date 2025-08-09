using DAL_BankManagment.Clients;
using DAL_BankManagment.Employees;
using DAL_BankManagment.Persons;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

            try
            {
                result = clsUpdateEmployee.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (result)
            {
                UpdateEmployeeFromList(employee);
            }
            return result;
        }

        public static bool UpdatePerson (clsPerson person)
        {
            try
            {
               return clsUpdatePerson.UpdatePerson(person);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public static List<clsEmployee> GetEmployee(string Name)
        {
            return GetEmployeeFromList(Name);
        }

        public static clsEmployee GetManager(short Id)
        {
            int index = GetEmployeeIndexFromList(Id);

            return clsEmployeesManager.Employees[index];
        }



    }
}
