using BLL.Manager;
using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL_BankManagment
{
    public class clsEmployeeCache : clsCache<clsEmployee>
    {
        public clsEmployeeCache() { }

        public override clsEmployee Get(short Id)
        {
            return _cacheList.FirstOrDefault(e => e.Id == Id);
        }

        public override List<clsEmployee> Get(string Name)
        {
            List<clsEmployee> employees = _cacheList.FindAll(e => e.Person.FullName() == Name);
            if (employees != null)
            {
                employees = _cacheList.FindAll(e => e.Person.LastName == Name);
            }
            return employees;
        }

        public override bool Update(clsEmployee employee)
        {
            int index = _cacheList.FindIndex(e => e.Id == employee.Id);
            if (index != -1)
            {
                _cacheList[index] = employee;
                return true;
            }
            return false;
        }

        public override bool Delete(short Id)
        {
            _cacheList.RemoveAll(e => e.Id == Id);
            return true;
        }

    }

    public class clsEmployeeRepo : clsRepo<clsEmployee>
    {

        public clsEmployeeRepo(IRepository<clsEmployee> repo) : base(repo) { }

        public override bool Add(ref clsEmployee emp)
        {
            short Id;
            try
            {
                Id = _repo.Insert(emp);
                emp.Id = Id;
            }
            catch (Exception ex) { throw ex; }

            emp.Id = Id;
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

    public class clsEmployeeManager : clsManager<clsEmployee>
    {
        public clsEmployeeManager(ICache<clsEmployee> cache, IRepo<clsEmployee> repo) : base(cache, repo) { }

   

    }
}
