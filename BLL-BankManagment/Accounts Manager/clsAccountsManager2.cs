using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BankManagment;
using Models;
using DAL_BankManagment.Accounts;
using System.Net.Http.Headers;

namespace Manager
{
    public partial class clsAccountsManager
    {

        public static void LoadAccounts()
        {
            Accounts = clsReadAccounts.GetAllAccounts();
        }

        public static bool DeleteAccount (short AccountID)
        {
            bool result = false;

            result = clsDeleteAccount.DeleteAccount(AccountID);

            if (result)
                DeleteAccountFromList(AccountID);

            return result;
        }

        public static bool UpdateAccount (clsAccount Account)
        {
            bool result = false;

            result = clsUpdateAccount.UpdateAccount(Account);

            if (result)
                UpdateAccountFromList(Account);

            return result;
        }

        public static short InsertAccount(clsAccount Account)
        {
            short AccountID = -1;

            AccountID = clsInsertAccount.InsertAccount(Account);

            if (AccountID != -1)
                AddAccountToList(Account);

            return AccountID;
        }

        public enum enSearchFilter { AccountName = 1, ClientName = 2 };

        
        public static List<clsAccount> GetAccount (string Name, enSearchFilter Search )
        {
            List<clsAccount> accounts = new List<clsAccount>();

            switch (Search)
            {
                case enSearchFilter.AccountName:
                    accounts = GetAccountFromListByAccountName(Name);
                    break;

                case enSearchFilter.ClientName:
                    accounts = GetAccountFromListByClientName(Name);
                    break;
            }

            return accounts;
        }


    }
}
