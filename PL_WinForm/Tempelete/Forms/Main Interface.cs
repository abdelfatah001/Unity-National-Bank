using Models;
using PL_WinForm;
using PL_WinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        List<string> GetRecordInList (T t);

        clsUIEntityScreenManager<T> screenManager { get; set; }
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

    public class clsUIEntityScreenManager<T>
    {
        public clsUIEntityScreenManager() { }   

        /// <summary>
        /// Reflect any records update in the UI (data grid view)
        /// </summary>
        /// <param name="index">index of row on data grid view</param>
        /// <param name="client">the object of the record to add on row's tag</param>
        public void ReflectUpdateOnUI(ctrlEntityManager<T> control, short index, List<string> row, T obj)
        {

            if (index != -1)
                control.UpdateRow(index, row, obj);

            else
                control.AddRow(row, obj);
        }

        /// <summary>
        /// to set child mdi for a parent form
        /// </summary>
        /// <param name="parent">parent form</param>
        /// <param name="child">child form</param>
        public void SetMDIParent(Form parent, Form child)
        {
            if (!parent.IsMdiContainer)
                return;

            child.MdiParent = parent;
            child.StartPosition = FormStartPosition.CenterParent;
            child.BringToFront();

        }

    }

};
