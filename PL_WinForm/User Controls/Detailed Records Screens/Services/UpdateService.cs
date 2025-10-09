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
    public abstract class clsUpdateService<T> : IUpdate
    {

        protected T _record;

        protected IInvisibleEntity<T> _Entity;

        protected clsUpdateService(IInvisibleEntity<T> entity, T record) 
        {
            _Entity = entity;
            _record = record;
        }

        public bool DataChanged { get; set; } = false;


        public abstract bool IsDataChanged();



        protected abstract void UpdateObject();
       

        enDataUpdated ISave<enDataUpdated>.Save()
        {

            if (!DataChanged)
                return enDataUpdated.NotChanged;

            UpdateObject();

            return (_Entity.Update(_record)) ? enDataUpdated.Saved : enDataUpdated.NotChanged;
        }


        abstract public void SaveUpdates();

        

    }
}
