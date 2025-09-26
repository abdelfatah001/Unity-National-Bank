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
    public class clsCurrencyCache : clsReadOnlyCache<clsCurrency>
    {
        public override clsCurrency Get(short id)
        {
            return new clsCurrency();
        }


        public override List<clsCurrency> Get(string Name)
        {
            return new List<clsCurrency>();
        }

    }

    public class clsCurrencyManager : clsReadOnlyManager<clsCurrency>
    {
        public clsCurrencyManager(IReadOnlyCache<clsCurrency> cache, IReadOnlyRepo<clsCurrency> repo) : base(cache, repo) { }


        public static double ConvertCurrency(clsCurrency ConvertFrom, clsCurrency ConvertTo, double ValueToConvert)
        {
            double Result = 0;

            if (ConvertFrom.Code == "USD")
            {
                Result = ConvertTo.ExchangeRate * ValueToConvert;
            }

            else if (ConvertTo.Code == "USD")
            {
                Result = ValueToConvert / ConvertFrom.ExchangeRate;
            }

            else
            {
                Result = ConvertTo.ExchangeRate / (ConvertFrom.ExchangeRate / ValueToConvert);
            }

            return Result;
        }

    }

    public class clsCurrencyRepo : clsReadaOnlyRepo<clsCurrency>
    {
        public clsCurrencyRepo(IReadOnlyRepository<clsCurrency> repository) : base(repository) { }



    }

}
