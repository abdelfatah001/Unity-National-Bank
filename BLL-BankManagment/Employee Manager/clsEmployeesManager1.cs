using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DAL_BankManagment;
using Models;
using DAL_BankManagment.Employees;


namespace Manager
{
    public partial class clsEmployeesManager
    {

        public static List<clsEmployee> Employees = new List<clsEmployee>();


        private static void AddEmployeeToList(clsEmployee employee)
        {
            Employees.Add(employee);
        }

        private static int GetEmployeeIndexFromList (short Id)
        {
            int index = Employees.FindIndex(emp => emp.Id == Id);

            return index;
        }

        private static bool DeleteEmployeeFromList(short Id)
        {
            int index = GetEmployeeIndexFromList(Id);

            if (index != -1)
            {
                Employees.RemoveAt(index);
                return true;
            }

            return false;

        }

        private static bool UpdateEmployeeFromList(clsEmployee employee)
        {
            int index = GetEmployeeIndexFromList(employee.Id);

            if (index != -1)
            {
                Employees[index] = employee;
                return true;
            }

            return false;
        }

        private static List<clsEmployee> GetEmployeeFromList (string Name)
        {
            List<clsEmployee> employees = new List<clsEmployee>();

            foreach (clsEmployee employee in Employees)
            {
                if (employee.Person.FirstName == Name
                    || employee.Person.LastName == Name
                    || employee.Person.FullName() == Name)
                {
                    employees.Add(employee);
                }
            }

            return employees;
        }


  


    }
}
