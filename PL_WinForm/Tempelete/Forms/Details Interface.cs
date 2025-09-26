using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_WinForm.Tempelete
{

    /// <summary>
    /// delegation of detailed record forms to return updated data to Entities records show forms to reflect updtes in data grid view
    /// </summary>
    /// <typeparam name="T">entity type</typeparam>
    /// <param name="sender">the sender form</param>
    /// <param name="index">the index of row in data grid view of the updated record</param>
    /// <param name="data">the updated object itself to stored in row's tag</param>
    public delegate void DataBackEventHandler<T>(object sender, short index, T data);

    /// <summary>
    /// Add record screen
    /// </summary>
    /// <typeparam name="T">type of record</typeparam>
    public interface IAddRecordScreen<T>
    {
        /// <summary>
        /// Data returned of updated object from detailed record forms to entities records show forms
        /// </summary>
        event DataBackEventHandler<T> DataBack;        
        
        /// <summary>
        /// to reintialize detailed record user control by the constructor that show object data instead of designer constructor
        /// </summary>
        /// <param name="obj">the object that form show its data</param>
        void ReintializeCtrl(T obj);

        /// <summary>
        /// this fuction to fire databack event if the datachanged to reflect update in data grid view of entities records show forms
        /// fired by closing the form by saave button
        /// </summary>
        void SendObjToShowMenu();
    }

    /// <summary>
    /// Detailed record Forms
    /// </summary>
    /// <typeparam name="T">record type</typeparam>
    public interface IDetailedScreen<T> : IAddRecordScreen<T>
    {

        /// <summary>
        /// the index of opened object in data grid view of entities records show forms
        /// </summary>
        short _indexInMenu { get; set; }

    }

    /// <summary>
    /// interface for detailed client record form
    /// </summary>
    public interface IDetailedClientScreen : IDetailedScreen<clsClient> { }

    /// <summary>
    /// interface for detailed employee record form
    /// </summary>
    public interface IDetailedEmployeeScreen : IDetailedScreen<clsEmployee> { }

    /// <summary>
    /// interface for detailed user record form
    /// </summary>
    public interface IDetailedUserScreen : IDetailedScreen<clsUser> { }

    /// <summary>
    /// interface for detailed account record form
    /// </summary>
    public interface IDetailedAccountScreen : IDetailedScreen<clsAccount> { }


    /// <summary>
    /// interface for add client record form
    /// </summary>
    public interface IAddlientScreen : IAddRecordScreen<clsClient> { }

    /// <summary>
    /// interface for add employee record form
    /// </summary>
    public interface IAddEmployeeScreen : IAddRecordScreen<clsEmployee> { }

    /// <summary>
    /// interface for add user record form
    /// </summary>
    public interface IAddUserScreen : IAddRecordScreen<clsUser> { }

    /// <summary>
    /// interface for add account record form
    /// </summary>
    public interface IAddAccountScreen : IAddRecordScreen<clsAccount> { }
}
