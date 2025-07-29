using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{ 
    public class clsCurrency
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double ExchangeRate { get; set; }

        public clsCurrency() { }

        public clsCurrency(short Id, string Code, string Name, double ExchangeRate)
        {
            this.Id = Id;
            this.Code = Code;
            this.Name = Name;
            this.ExchangeRate = ExchangeRate;
        }


    }
}
