using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class clsAccount
    {
        public enum enAccountStatus
        {
            Active = 1, Inactive = 2, Closed = 3, Suspended = 4, Overdrawn = 5,
            Frozen = 6, Pending = 7, Restricted = 8, Dormant = 9, AwaitingApprovel = 10
        };

        public short Id { get; set; }
        public string AccountName {  get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public enAccountStatus Status { get; set; }
        public clsClient client { get; set; }
        public clsCurrency currency { get; set; }


        public  clsAccount() 
        {
            currency = new clsCurrency();
        }

        public void Update(double Balance, DateTime CreatedDate, clsClient Client, clsCurrency Currency, enAccountStatus status)
        {
            this.Balance = Balance;
            this.CreatedDate = CreatedDate;
            this.client = Client;
            this.currency = Currency;
            this.Status = status;
        }

     



    }
}
