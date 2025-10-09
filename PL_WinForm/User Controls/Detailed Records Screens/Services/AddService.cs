using Models;
using PL_WinForm.User_Controls.Details_Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record
{
    public enum enAddingOprtn { Add, Canceled, Failed };


    public abstract class clsAddService<T> : IAdd<T>
    {

        protected enAddingOprtn operation = enAddingOprtn.Canceled;

        protected IEntity<T> _entity;

        protected T _recordToAdd;

        public clsAddService (IEntity<T> entity, ref T recordToAdd) 
        { 
            _entity = entity; 
            _recordToAdd =  recordToAdd;
        }

        public bool IsCanceled ()
        {
            return operation == enAddingOprtn.Canceled;
        }

         protected abstract void FillObject();



        public T ReturnFilledObject()
        {
            FillObject();   
            return _recordToAdd;
        }

        enAddingOprtn ISave<enAddingOprtn>.Save()
        {
            if (_recordToAdd == null)
                return enAddingOprtn.Canceled;


            return (_entity.Add(ref _recordToAdd)) ? enAddingOprtn.Add : enAddingOprtn.Failed;
        }

        abstract public void SaveUpdates();




    }
}
