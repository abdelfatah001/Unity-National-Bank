using DAL_BankManagment;
using DAL_BankManagment.Countries;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class clsCountriesManager
    {

        public static List<clsCountry> Countries = new List<clsCountry>();

        public static void LoadCountries()
        {
            Countries = clsReadCountry.GetAllCountries();
        }

        public static clsCountry GetCountry (string name)
        {
            foreach (var country in Countries)
            {
                if (country.Name == name) 
                return country;
            }
            return null;
        }

    }
}
