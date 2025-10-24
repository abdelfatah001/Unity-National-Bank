using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Person;
using PL_WinForm.User_Controls.Details_Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_WinForm.User_Controls.Details_Presenter
{
    /// <summary>
    /// Control view for adding record or uodating an existing one
    /// </summary>
    public enum enView { Add, Show, Update };

    /// <summary>
    /// enum to express the the save status is saved or not or not changed at all
    /// </summary>
    public enum enDataUpdated { NotChanged, Saved, NotSaved };


    /// <summary>
    /// interface for save methods used after CRUD operations to save them
    /// </summary>
    public interface ISave<TResult> where TResult : Enum
    {
        TResult Save();
        void SaveUpdates ();
    }

    /// <summary>
    /// interface for update methods in datailed record control
    /// </summary>
    public interface IUpdate : ISave<enDataUpdated>
    {
        bool DataChanged { get; set; }
    }

    /// <summary>
    /// interface for add methods in add record control
    /// </summary>
    public interface IAdd<T> : ISave<enAddingOprtn>
    { 
        bool IsCanceled();
        T ReturnFilledObject();
    }

    /// <summary>
    /// interface for load form method in datailed record control
    /// </summary>
    public interface ILoad {
        void FillForm(); 
    }


    /// <summary>
    /// interface to reintailize control of client or employee by constructor to show themom read only mode data instead of designer constructor
    /// used by account and user controls
    /// </summary>
    public interface IReLoadCtrl { void ReintializeSubCtrl(IPersonValidation personValidation); } 

    /// <summary>
    /// store the varable of record object
    /// </summary>
    /// <typeparam name="T">record type</typeparam>
    public interface ICtrlVariables<T>  
    { 
        T SelectedRecord { get; set; }

    }
    /// <summary>
    /// the event that fired by control when cancel button clicked to close the detailed record form
    /// </summary>
    public interface ICloseCtrl
    {
        event EventHandler OnCancel;
    }


    /// <summary>
    /// interface of detailed person control
    /// </summary>
    public interface IDetailedPerson : ILoad, ICtrlVariables<clsPerson> { }

    /// <summary>
    /// interface for detailed record methods of client and employee
    /// </summary>
    /// <typeparam name="T">record type</typeparam>
    public interface IDetailedRecord<T> : ILoad, IReLoadCtrl, ICtrlVariables<T>, ICloseCtrl
    {
        /// <summary>
        /// method of check is person data chenged to reflect updates in data grid view
        /// </summary>
        /// <returns>boolean value of Is person data chcnged</returns>
        bool IsPersonDataChanged();

        IUpdate UpdateService { get; set; }

        // IAdd AddService { get; set; }

    }

    /// <summary>
    /// interface of detailed client control
    /// </summary>
    public interface IDetailedClient : IDetailedRecord<clsClient> { }

    /// <summary>
    /// interface of detailed employee control
    /// </summary>
    public interface IDetailedEmployee : IDetailedRecord<clsEmployee> { }


    /// <summary>
    /// interface of methods of derived records like account and user
    /// </summary>
    /// <typeparam name="T">record type</typeparam>
    public interface IDerivedDetailedRecord<T> : ILoad, IReLoadCtrl, ICtrlVariables<T>, ICloseCtrl 
    {
        IUpdate UpdateService { get; set; }

        IAdd<T> AddService { get; set; }


    }

    /// <summary>
    /// interface of detailed iser control
    /// </summary>
    public interface IDetailedUser : IDerivedDetailedRecord <clsUser> { }

    /// <summary>
    /// interface of detailed person control
    /// </summary>
    public interface IDetailedAccount : IDerivedDetailedRecord <clsAccount> { } 
    

}
