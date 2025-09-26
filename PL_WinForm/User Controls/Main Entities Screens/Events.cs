
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls
{
    public class DeleteEventArgs : EventArgs
    {
        public short Id;

        public DeleteEventArgs(short id) { this.Id = id; }
    }

    public class RecordEvevtsArgs<T> : EventArgs
    {
        public T obj;

        public int RowIndex;

        public RecordEvevtsArgs(T obj, int rowIndex)
        {
            this.obj = obj;
            RowIndex = rowIndex;
        }

    }

    partial class ctrlEntityManager<T>
    {
        /// <summary>
        /// Add button click to add new button
        /// </summary>
        public event EventHandler OnAddClick;

        /// <summary>
        /// Search button click to search a record
        /// </summary>
        public event EventHandler OnSearchClick;


        /// <summary>
        /// Click on row of the data grid view to show the record in details
        /// </summary>
        public event EventHandler<RecordEvevtsArgs<T>> OnDataRowClick; 


        protected virtual void AddClick(EventArgs args) { OnAddClick?.Invoke(this, args); }

        protected virtual void SearchClick(EventArgs args) { OnSearchClick?.Invoke(this, args); }


        protected virtual void DataRowClick(RecordEvevtsArgs<T> args) { OnDataRowClick?.Invoke(this, args); }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchClick(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClick(e);
        }


        private void EditOnRecord(int RowIndex)
        {
            // pass the object to EntityDetailed to open it detailed in a form
            if (dgvData.CurrentRow != null)
            {
                T obj = (T)(dgvData.CurrentRow.Tag);
                DataRowClick(new RecordEvevtsArgs<T>(obj, RowIndex));
            }
        }

        
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                EditOnRecord(e.RowIndex);
        }

        
    }
}
