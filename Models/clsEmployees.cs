using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class clsEmployee
    {
        public enum enDepartments
        {
            Account = 1, Compliance = 2, CustomerService = 3, IT = 4,
            Loans = 5, Managment = 6, OtherWorkers = 7, Tellers = 8
        };

        public short Id { get; set; }
        public short PersonId { get; set; }
        public clsPerson Person { get; set; }
        public double Salary { get; set; }
        public enDepartments Department { get; set; }
        public short ManagerId { get; set; }

        public clsEmployee Manager { get; set; }

        public clsEmployee() { }
        public clsEmployee(short ID, clsPerson Person, double Salary, enDepartments Department, clsEmployee Maneger = null)
        {
            this.Id = ID;
            this.Person = Person;
            this.Salary = Salary;
            this.Department = Department;
            this.Manager = Maneger;
        }



    }
}