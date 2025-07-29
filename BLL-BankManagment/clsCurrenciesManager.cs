using DAL_BankManagment;
using DAL_BankManagment.Currencies;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class clsCurrenciesManager
    {

        public static List<clsCurrency> Currencies;

        public static void LoadCurrencies()
        {
            Currencies = clsReadCurrencys.GetAllCurrencies();
        }

        public static double ConvertCurrency (clsCurrency ConvertFrom, clsCurrency ConvertTo, double ValueToConvert)
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
}
