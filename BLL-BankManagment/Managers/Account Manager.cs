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
    public class clsAccountCache : clsCache<clsAccount>
    {
        public clsAccountCache() { }


        public override clsAccount Get(short AccId)
        {
            return _cacheList.FirstOrDefault(acc => acc.Id == AccId);
        }

        public override List<clsAccount> Get(string AccName)
        {
            return _cacheList.FindAll(acc => acc.AccountName == AccName);
        }


        public override bool Delete(short AccId)
        {
            _cacheList.RemoveAll(acc => acc.Id == AccId);
            return true;
        }

        public override bool Update(clsAccount Updatedacc)
        {
            int index = _cacheList.FindIndex(acc => acc.Id == Updatedacc.Id);
            if (index != -1)
            {
                _cacheList[index] = Updatedacc;
                return true;
            }

            return false;

        }

    }

    public class clsAccountRepo : clsRepo<clsAccount>
    {
        public clsAccountRepo(IRepository<clsAccount> repo) : base(repo) { }

        public override bool Add(ref clsAccount acc)
        {
            short Id;
            try
            {
                Id = _repo.Insert(acc);
                acc.Id = Id;
            }
            catch (Exception ex) { throw ex; }

            acc.Id = Id;
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

    public class clsAccountManager : clsManager<clsAccount>
    {
        public clsAccountManager(ICache<clsAccount> cache, IRepo<clsAccount> repo) : base(cache, repo) { }


    }

}
