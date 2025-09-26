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
    public enum enAddingOprtn { Adding, Canceled };


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

        void IAdd<T>.Insert()
        {
            InsertInternal();
        }

        protected void InsertInternal()
        {
            if (operation == enAddingOprtn.Canceled)
                return;
                

            bool isAdded = _entity.Add(ref _recordToAdd);

            if (isAdded)
            {
                MessageBox.Show("Record saved successfully");
                operation = enAddingOprtn.Adding;
            }
            else
                MessageBox.Show("Record adding failed");


        }

        public bool IsCanceled ()
        {
            return operation == enAddingOprtn.Canceled;
        }

         protected abstract void FillObjectData();
         public abstract void Add();

        public T ReturnFilledObject()
        {
            return _recordToAdd;
        }




    }
}
