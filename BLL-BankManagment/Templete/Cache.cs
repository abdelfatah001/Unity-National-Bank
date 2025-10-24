using BLL.Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BankManagment
{


    public abstract class clsCache<T> : ICache<T>
    {
        protected static List<T> _cacheList = new List<T>();

        protected static Dictionary<int, T> _cachDict = new Dictionary<int, T>();

        public clsCache() { }

        public List<T> GetAll()
        {
            return _cacheList.ToList();
        }

        public abstract T Get(short AccId);

        public abstract List<T> Get(string AccName);

        public void AddNew(T t)
        {
            _cacheList.Add(t);
        }

        public void Fill(T t)
        {
            _cacheList.Add(t);
        }

        public abstract bool Delete(short Id);

        public abstract bool Update(T t);


    }

    public abstract class clsReadOnlyCache<T> : IReadOnlyCache<T>
    {
        public List<T> _cacheList = new List<T>();

        public clsReadOnlyCache() { }

        public void Fill(T t)
        {
            _cacheList.Add(t);
        }

        public List<T> GetAll()
        {
            return _cacheList.ToList();
        }

        public abstract T Get(short id);


        public abstract List<T> Get(string Name);

    }
}
    