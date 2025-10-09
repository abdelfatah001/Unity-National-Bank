using BLL.Manager;
using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BankManagment.Person_Manager
{
    public class clsPersonCache : clsCache<clsPerson>
    {
        public clsPersonCache() { }


        public override clsPerson Get(short AccId)
        {
            return _cacheList.FirstOrDefault(acc => acc.Id == AccId);
        }

        public override List<clsPerson> Get(string Name)
        {
            return _cacheList.FindAll(p => p.LastName == Name);
        }


        public override bool Delete(short AccId)
        {
            _cacheList.RemoveAll(acc => acc.Id == AccId);
            return true;
        }

        public override bool Update(clsPerson Updatedacc)
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

    public class clsPersonRepo : clsRepo<clsPerson>
    {
        public clsPersonRepo(IRepository<clsPerson> repo) : base(repo) { }

        public override bool Add(ref clsPerson p)
        {
            short Id;
            try
            {
                Id = _repo.Insert(p);
                p.Id = Id;
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

    public class clsPersonManager : clsManager<clsPerson>
    {
     
        public clsPersonManager (ICache<clsPerson> cache, IRepo<clsPerson> repo) : base(cache, repo) { }

    }
}
