using DAL_BankManagment.Employees;
using DAL_BankManagment.Users;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public partial class clsUsersManager
    {

        public static void LoadUsers()
        {
            Users = clsReadUsers.GetAllUsers();
        }

        public static short AddUser(clsUser user)
        {

            short UserId = -1;

            UserId = clsInsertUser.InsertUser(user);

            if (UserId != -1)
                AddUserToList(user);

            return UserId;

        }

        public static bool DeleteUser(short Id)
        {

            bool result = false;

            result = clsDeleteUser.DeleteUser(Id);

            if (result)
            {
                DeleteUserFromList(Id);
            }
            return result;
        }

        public static bool UpdateUser(clsUser user)
        {
            bool result = false;

            result = clsUpdateUser.UpdateUser(user);

            if (result)
            {
                UpdateUserFromList(user);
            }
            return result;
        }


        public static List<clsUser> GetEmployee(string Name)
        {
            return GetUserFromList(Name);
        }

        public static bool IsUserExisted(string username, string password)
        {
            foreach (clsUser user in Users)
            {
                if (user.UserName == username && user.Password == password)
                    return true;
            }

            return false;
        }

    }
}
