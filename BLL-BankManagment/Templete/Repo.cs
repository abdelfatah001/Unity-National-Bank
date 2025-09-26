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
    public abstract class clsRepo<T> : IRepo<T>
    {
        public IRepository<T> _repo;

        public clsRepo(IRepository<T> repo)
        {
            _repo = repo;
        }

        public List<T> GetAll()
        {
            List<T> accounts;
            try
            {
                accounts = _repo.GetAll();
            }
            catch (Exception ex) { throw ex; }

            return accounts;
        }

        public abstract bool Add(ref T t);


        public bool Update(T acc)
        {
            bool IsUpdated;
            try
            {
                IsUpdated = _repo.Update(acc);
            }
            catch (Exception ex) { throw ex; }

            return IsUpdated;
        }

        public abstract bool Delete(short Id);


    }

    public abstract class clsReadaOnlyRepo<T> : IReadOnlyRepo<T>
    {
        public IReadOnlyRepository<T> _repository;

        public clsReadaOnlyRepo(IReadOnlyRepository<T> repo)
        {
            _repository = repo;
        }

        public List<T> GetAll()
        {
            List<T> list;
            try
            {
                list = _repository.GetAll();
            }
            catch (Exception ex) { throw ex; }
            return list;
        }
    }
}

