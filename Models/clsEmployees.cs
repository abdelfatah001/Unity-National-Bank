using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        public clsPerson Person { get; set; }
        public double Salary { get; set; }
        public enDepartments Department { get; set; }
        public clsEmployee Manager { get; set; }

        public short ManagerId { get; set; }


        public clsEmployee() 
        { 
            Person = new clsPerson();
        }

        public void Update (double Salary, enDepartments department, clsPerson person, clsEmployee manager)
        {
            this.Salary = Salary;
            this.Department = department;
            this.Manager = manager;

            if (manager != null)
                this.ManagerId = manager.Id;

            else
                this.ManagerId = -1;

            this.Person = person;
        }

        public string strEmployee()
        {
            return (this.Id + " - " + this.Person.FirstName + this.Person.LastName);
        }



    }
}