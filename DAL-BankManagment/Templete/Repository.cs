using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IGetAll<T> { List<T> GetAll(); }

    public interface IInsert<T> { short Insert(T ob); }

    public interface IUpdate<T> { bool Update(T ob); }

    public interface IDelete<T> { bool Delete(short Id); }

    public interface IFillObjectWithData<T> { T FillObject(SqlDataReader reader); }

    public interface IReadOnlyRepository<T> : IGetAll<T>, IFillObjectWithData<T> { }
    public interface IRepository<T> : IReadOnlyRepository<T>, IInsert<T>, IUpdate<T>, IDelete<T>{ }


    public interface IAccountsRepository : IRepository<clsAccount> { }
    public interface IClientsRepository : IRepository<clsClient> { }
    public interface IEmployeesRepository : IRepository<clsEmployee> { }
    public interface IUsersRepository : IRepository<clsUser> { }
    public interface IPersonsRepository : IRepository<clsPerson> { }



    public interface ICurrencyRepository : IReadOnlyRepository<clsCurrency> { }

    public interface ICountriesRepository : IReadOnlyRepository<clsCountry> { }

}
