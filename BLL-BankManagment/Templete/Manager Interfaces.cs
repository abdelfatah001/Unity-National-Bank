using Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Manager
{
    public interface IFillCache<T> { void Fill(T t); }

    public interface IAddNew<T> : IFillCache<T> { void AddNew(T t); }

    public interface IAddToRepo<T> { bool Add(ref T t); }

    public interface IGet<T> { T Get(short Id); List<T> Get(string name); }

    public interface ILoadAll<T> { List<T> LoadAll(); }



    public interface ICache<T> : IReadOnlyCache<T>, IAddNew<T>, IDelete<T>, IUpdate<T>  { }

    public interface IRepo<T> : IReadOnlyRepo<T>, IAddToRepo<T>, IDelete<T>, IUpdate<T> { }

    public interface IManager<T> : IDelete<T>, IUpdate<T>, IAddToRepo<T>, IGet<T>, ILoadAll<T> { }



    public interface IReadOnlyCache<T> : IGetAll<T>, IGet<T>, IFillCache<T> { }

    public interface IReadOnlyRepo<T> : IGetAll<T> { }

    public interface IReadOnlyManager<T> : ILoadAll<T>, IGet<T> { }



}
