using Models;
using PL_WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm
{

    /// <summary>
    /// Interface for Screens methods
    /// </summary>
    public interface IScreen 
    {
        /// <summary>
        /// used to intialize and load the form when needed and opened
        /// </summary>
        void LoadScreen(); 

        /// <summary>
        /// // to fill the dgv and controls with data 
        /// called by LoadScreen
        /// </summary>
        void ShowScreen(); 
        bool IsLoaded { get; set; }
    }

    /// <summary>
    /// interface for screens show data of entities
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRecordsScreen<T> : IScreen 
    {
        /// <summary>
        /// Reintialize the control with new object by constructor that fill the form with data instead of designer constructor object
        /// called by LoadScreen
        /// </summary>
        void ReintializeCtrl();


        /// <summary>
        /// Reflect any recors update in the UI (data grid view)
        /// </summary>
        /// <param name="index">index of row on data grid view</param>
        /// <param name="client">the object of the record to add on row's tag</param>
        void ReflectUpdateOnUI(short index, T client);

    }

    /// <summary>
    /// Interface for client form
    /// </summary>
    public interface IClientScreen : IRecordsScreen<clsClient> { }

    /// <summary>
    /// Interface for employee form
    /// </summary>
    public interface IEmployeeScreen : IRecordsScreen<clsEmployee> { }

    /// <summary>
    /// Interface for Account form
    /// </summary>
    public interface IAccountScreen : IRecordsScreen<clsAccount> { }

    /// <summary>
    /// Interface for user form
    /// </summary>
    public interface IUserScreen : IRecordsScreen<clsUser> { }



};
