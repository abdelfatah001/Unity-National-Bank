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
    public class clsClientCache : clsCache<clsClient>
    {


        public clsClientCache() { }



        public override clsClient Get(short AccId)
        {
            return _cacheList.FirstOrDefault(acc => acc.Id == AccId);
        }

        public override List<clsClient> Get(string AccName)
        {
            return _cacheList.FindAll(acc => acc.Person.LastName == AccName);
        }



        public override bool Delete(short AccId)
        {
            _cacheList.RemoveAll(acc => acc.Id == AccId);
            return true;
        }

        public override bool Update(clsClient Updatedclient)
        {
            int index = _cacheList.FindIndex(acc => acc.Id == Updatedclient.Id);
            if (index != -1)
            {
                _cacheList[index] = Updatedclient;
                return true;
            }

            return false;

        }

    }

    public class clsClientRepo : clsRepo<clsClient>
    {
        public clsClientRepo(IRepository<clsClient> repo) : base(repo) { }

        public override bool Add(ref clsClient client)
        {
            short Id;
            try
            {
                Id = _repo.Insert(client);
                client.Id = Id;
            }
            catch (Exception ex) { throw ex; }

            client.Id = Id;
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

    public class clsClientManager : clsManager<clsClient>
    {
        public clsClientManager(ICache<clsClient> cache, IRepo<clsClient> repo) : base(cache, repo) { }


    }

}
