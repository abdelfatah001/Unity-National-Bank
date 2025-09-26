using BLL.Manager;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Data_Gathering
{

    /// <summary>
    /// This class to do CUD operations in person entity
    /// </summary>
    public class clsPersonEntity : clsInvisibleEntity<clsPerson>
    {
        public clsPersonEntity (IManager<clsPerson> manager) : base(manager) { }

        public override clsPerson Get(short Id)
        {
            return _manager.Get(Id);
        }

    }

    /// <summary>
    /// This class to do CRUD operations in Employee entity
    /// </summary>
    public class clsEmployeeEntity : clsEntity<clsEmployee>
    {
        public clsEmployeeEntity(IManager<clsEmployee> manager) : base (manager, "Employees") { }

    }

    /// <summary>
    /// This class to do CRUD operations in Client entity
    /// </summary>
    public class clsClientEntity : clsEntity<clsClient> 
    {
        public clsClientEntity(IManager<clsClient> manager) : base(manager, "Clients") { }


    }


    /// <summary>
    /// This class to do CRUD operations in User entity
    /// </summary>
    public class clsUserEntity : clsEntity<clsUser>
    {

        public clsUserEntity(IManager<clsUser> manager) : base(manager, "Users") { }

    }


    /// <summary>
    /// This class to do CRUD operations in Account entity
    /// </summary>
    public class clsAccountEntity : clsEntity<clsAccount>
    {
        public clsAccountEntity(IManager<clsAccount> manager) : base(manager, "Accounts") { }

    }


    /// <summary>
    /// This class to Read data from Country entity
    /// </summary>
    public class clsReadOnlyEntity<T> : IReadOnlyEntity<T>
    {
        IReadOnlyManager<T> _manager;


        public clsReadOnlyEntity(IReadOnlyManager<T> manager)
        {

            _manager = manager;
        }


        public List<T> LoadData()
        {
            try
            {
                return _manager.LoadAll();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
                return new List<T>();
            }
        }


    }

    public class clsCountryEntity : clsReadOnlyEntity<clsCountry>
    { 
        public clsCountryEntity (IReadOnlyManager<clsCountry> entity) : base(entity) { }
    }



    public class clsCurrencyEntity : clsReadOnlyEntity<clsCurrency>
    {
        public clsCurrencyEntity(IReadOnlyManager<clsCurrency> entity) : base(entity) { }
    }

}

