using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class clsClient
    {
        public enum enClientStatus
        {
            Active = 1, Inactive = 2, Suspended = 3, Banned = 4, New = 5,
            VIP = 6, Delinquent = 7, Closed = 8, Pending_Approval = 9, BlackListed = 10
        };

        public short Id { get; set; }
        public clsPerson Person { get; set; }
        public DateTime JoinData { get; set; }
        public enClientStatus Status { get; set; }


        public clsClient() { }
        public clsClient(short Id, clsPerson Person, DateTime JoinDate, enClientStatus Status)
        {
            this.Id = Id;
            this.Person = Person;
            this.JoinData = JoinDate;
            this.Status = Status;

        }

     

    }
}