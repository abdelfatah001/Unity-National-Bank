using BLL.Manager;
using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BankManagment
{
 
    public class clsUserCache : clsCache<clsUser>
    {

        public clsUserCache()
        {
        }

        public override clsUser Get(short Id)
        {
            return _cacheList.FirstOrDefault(u => u.Id == Id);
        }

        public override List<clsUser> Get(string Name)
        {
            List<clsUser> users = _cacheList.FindAll(u => u.Employee.Person.FullName() == Name);
            if (users == null)
            {
                users = _cacheList.FindAll(u => u.Employee.Person.LastName == Name);
            }

            return users;
        }


        public override bool Update(clsUser user)
        {
            int index = _cacheList.FindIndex(u => u.Id == user.Id);
            _cacheList[index] = user;
            return true;
        }
        public override bool Delete(short Id)
        {
            _cacheList.RemoveAll(u => u.Id == Id);
            return true;
        }
    }

    public class clsUserRepo : clsRepo<clsUser>
    {

        public clsUserRepo(IRepository<clsUser> repo) : base(repo) { }

        public override bool Add(ref clsUser user)
        {
            short Id;
            try
            {
                Id = _repo.Insert(user);
                user.Id = Id;
            }
            catch (Exception ex) { throw ex; }

            return (Id != -1);
        }

        public override bool Delete(short Id)
        {
            bool IsDeleted;
            try
            {
                IsDeleted = _repo.Delete(Id);
            }
            catch (Exception ex) { throw ex; }

            return IsDeleted;

        }

    }

    public class clsUserManager : clsManager<clsUser>
    {
        public clsUserManager(ICache<clsUser> cache, IRepo<clsUser> repo) : base(cache, repo) { }

    }
}
