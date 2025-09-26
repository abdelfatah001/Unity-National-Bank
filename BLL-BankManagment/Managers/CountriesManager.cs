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
    public class clsCountriesCache : clsReadOnlyCache<clsCountry>
    {

        public override clsCountry Get(short id)
        {
            return new clsCountry();
        }


        public override List<clsCountry> Get(string Name)
        {
            return new List<clsCountry>();
        }

    }

    public class clsCountriesManager : clsReadOnlyManager<clsCountry>
    {
        public clsCountriesManager(IReadOnlyCache<clsCountry> cache, IReadOnlyRepo<clsCountry> repo) : base(cache, repo) { }

    }

    public class clsCountriesRepo : clsReadaOnlyRepo<clsCountry>
    {

        public clsCountriesRepo(IReadOnlyRepository<clsCountry> repository) : base(repository) { }

    }

}
