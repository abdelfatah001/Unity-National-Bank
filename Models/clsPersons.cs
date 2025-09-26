using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class clsPerson
    {

        public short Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public clsCountry Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public clsPerson()
        {
            Country = new clsCountry();
        }

        public clsPerson(short Id, string FName, string LName, DateTime DateOfBirth, clsCountry Country, string Email, string Phone)
        {
            this.Id = Id;
            this.FirstName = FName;
            this.LastName = LName;
            this.DateOfBirth = DateOfBirth;
            this.Age =
                (byte)((DateTime.Now.Year) - (DateOfBirth.Year));

            this.Country = Country;
            this.Email = Email;
            this.Phone = Phone;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

    }
}
