using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class clsUser
    {
        public short Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AccessCode { get; set; }
        public clsEmployee Employee { get; set; }


        public clsUser() { } 

        public void Update (string UserName, string Password, int AccessCode, clsEmployee Employee)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.AccessCode = AccessCode;
            this.Employee = Employee;
        }


    }
}
