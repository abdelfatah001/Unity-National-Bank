using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public partial class clsAccountsManager
    {

        private static List<clsAccount> Accounts;

        private static int GetAccountIdexFromList(short Id)
        {
            int index = Accounts.FindIndex(acc => acc.Id == Id);

            return index;
        }

        private static bool DeleteAccountFromList(short Id)
        {

            int index = GetAccountIdexFromList(Id);

            if (index != -1)
            {
                Accounts.RemoveAt(index);
                return true;
            }

            return false;
        }

        private static bool UpdateAccountFromList(clsAccount account)
        {

            int index = GetAccountIdexFromList(account.Id);

            if (index != -1)
            {
                Accounts[index] = account;
                return true;
            }

            return false;

        }

        private static void AddAccountToList(clsAccount account)
        {
            Accounts.Add(account);
        }

        
        private static List<clsAccount> GetAccountFromListByAccountName (string AccountName)
        {
            List<clsAccount> accounts = new List<clsAccount>();

            foreach (clsAccount acc in Accounts)
            {
                if (acc.AccountName == AccountName)
                    accounts.Add(acc);
            }
            return accounts;
        }

        private static List<clsAccount> GetAccountFromListByClientName(string ClientName)
        {
            List<clsAccount> accounts = new List<clsAccount>();

            foreach (clsAccount acc in Accounts)
            {
                if (acc.client.Person.FirstName == ClientName
                    || acc.client.Person.LastName == ClientName
                    || acc.client.Person.FullName() == ClientName)
                { 
                    accounts.Add(acc);
                }
            }
            return accounts;

        }




    }
}
