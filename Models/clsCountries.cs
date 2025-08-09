using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class clsCountry
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public clsCountry() { }
        public clsCountry(short Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }


    }
}
