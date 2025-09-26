using BLL.Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BankManagment
{
    public abstract class clsReadOnlyManager<T> : IReadOnlyManager<T>
    {

        private readonly IReadOnlyCache<T> _cache;

        private readonly IReadOnlyRepo<T> _repo;

        public clsReadOnlyManager(IReadOnlyCache<T> cache, IReadOnlyRepo<T> repo)
        {
            _cache = cache;
            _repo = repo;
        }

        public List<T> LoadAll()
        {
            var Records = _cache.GetAll();
            if (Records.Any())
                return Records;
            try
            {
                Records = _repo.GetAll();
            }
            catch (Exception ex) { throw ex; }

            if (Records.Any())
            {
                foreach (var account in Records)
                    _cache.Fill(account);
            }

            return Records;
        }

        public T Get(short Id)
        {
            return _cache.Get(Id);
        }

        public List<T> Get(string code)
        {
            return _cache.Get(code);
        }

    }

    public abstract class clsManager<T> : IManager<T>
    {
        private  ICache<T> _cache;

        private IRepo<T> _repo;


        public clsManager(ICache<T> cache, IRepo<T> repo)
        {
            _repo = repo;
            _cache = cache;
        }



        public List<T> LoadAll()
        {
            var Records = _cache.GetAll();
            if (Records.Any())
                return Records;
            try
            {
                Records = _repo.GetAll();
            }
            catch (Exception ex) { throw ex; }

            if (Records.Any())
            {
                foreach (var account in Records)
                    _cache.Fill(account);
            }

            return Records;
        }

        public bool Add(ref T t)
        {
            bool IsAdded;
            try
            {
                IsAdded = (_repo.Add(ref t));
            }
            catch (Exception ex) { throw ex; }

            if (IsAdded)
            {
                _cache.AddNew(t);
                return true;
            }
            return false;
        }

        public bool Update(T t)
        {
            bool IsUpdated;

            try
            {
                IsUpdated = _repo.Update(t);
            }

            catch (Exception ex) { throw ex; }

            if (IsUpdated)
            {
                _cache.Update(t);
                return true;
            }
            return false;
        }

        public bool Delete(short Id)
        {
            bool IsDeleted;

            try
            {
                IsDeleted = (_repo.Delete(Id));
            }
            catch (Exception ex) { throw ex; }

            if (IsDeleted)
            {
                _cache.Delete(Id);
                return true;
            }
            return false;
        }

        public List<T> Get(string Name)
        {
            return _cache.Get(Name);
        }

        public T Get(short Id)
        {
            return _cache.Get(Id);
        }
    }

  
}
