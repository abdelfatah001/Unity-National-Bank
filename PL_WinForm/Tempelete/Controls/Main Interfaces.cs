using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_WinForm
{
    /// <summary>
    /// to show entity name stored in a variable in show menu form
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IShowEntity<T> { string _menuName { get; } }

    /// <summary>
    /// interface for Load data method 
    /// used only for Country method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadOnlyEntity<T> // to laod all records 
    {

        /// <summary>
        /// Load data From cache if existed or load it to cache from repo 
        /// </summary>
        /// <returns>List of records of the entity</returns>
        List<T> LoadData(); 

    }

    /// <summary>
    /// interface for create, update, delete methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICUDEntity<T>
    {

        /// <summary>
        /// Update record 
        /// </summary>
        /// <param name="t">This the object you want to update data to it</param>
        /// <returns>Is record updated</returns>
        bool Update(T t);

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="Id">The Id of oject to delete</param>
        /// <returns>Is record deleted</returns>
        bool Delete(short Id);

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="t">object to add</param>
        /// <returns>Is record added</returns>
        bool Add(ref T t);

    }

    /// <summary>
    /// interface to get an object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGet<T> 
    {
        /// <summary>
        /// Get an object from cache
        /// </summary>
        /// <param name="Id">The Id</param>
        /// <returns>the object with this Id</returns>
        T Get(short Id); 
    }

    /// <summary>
    /// interface for CUD methods for invisible person entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInvisibleEntity<T> : ICUDEntity<T>, IGet<T> { }

    /// <summary>
    /// interface for CRUD, Get and Show entity records listed methods for entities 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T> : IInvisibleEntity<T>, IReadOnlyEntity<T>, IShowEntity<T> { }

    
}
