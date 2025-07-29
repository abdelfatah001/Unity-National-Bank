using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL_BankManagment;
using Models;
using DAL_BankManagment.Users;


namespace Manager
{
    public partial class clsUsersManager
    {


        public static List<clsUser> Users = new List<clsUser>();



        private static int GetUserIndexFromList(short Id)
        {
            int index = Users.FindIndex(emp => emp.Id == Id);

            return index;
        }
        private static void AddUserToList(clsUser user)
        {
            Users.Add(user);
        }

        private static bool DeleteUserFromList(short Id)
        {
            int index = GetUserIndexFromList(Id);

            if (index != -1)
            {
                Users.RemoveAt(index);
                return true;
            }

            return false;

        }

        private static bool UpdateUserFromList(clsUser user)
        {
            int index = GetUserIndexFromList(user.Id);

            if (index != -1)
            {
                Users[index] = user;
                return true;
            }

            return false;
        }

        private static List<clsUser> GetUserFromList(string Name)
        {
            List<clsUser> users = new List<clsUser>();

            foreach (clsUser user in Users)
            {
                if (user.Employee.Person.FirstName == Name
                    || user.Employee.Person.LastName == Name
                    || user.Employee.Person.FullName() == Name)
                {
                    users.Add(user);
                }
            }

            return users;
        }

    }
}
