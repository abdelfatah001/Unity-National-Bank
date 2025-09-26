
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Controls
{
    public class DeleteEventArgs : EventArgs
    {
        public short Id;

        public DeleteEventArgs(short id) { this.Id = id; }
    }

    public class RecordEvevtsArgs<T> : EventArgs
    {
        public T obj;

        public RecordEvevtsArgs(T obj) { this.obj = obj; }

    }

    partial class ctrlEntityManager<T>
    {
        public event EventHandler OnAddClick;

        public event EventHandler OnSearchClick;

        public event EventHandler<DeleteEventArgs> OnDeleteCLick;

        public event EventHandler<RecordEvevtsArgs<T>> OnDataRowClick; // to open record detailed


        protected virtual void AddClick(EventArgs args) { OnAddClick?.Invoke(this, args);  }

        protected virtual void SearchClick(EventArgs args) { OnSearchClick?.Invoke(this, args); }

        protected virtual void DeleteClick(DeleteEventArgs args) { OnDeleteCLick?.Invoke(this, args); }

        protected virtual void DataRowClick(RecordEvevtsArgs<T> args) { OnDataRowClick?.Invoke(this, args); } 


        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchClick(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClick(e);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                short Id = Convert.ToInt16(dgvData.CurrentRow.Cells["Id"].Value);

                DeleteClick(new DeleteEventArgs(Id));
            }
            
        }

        private void EditOnRecord ()
        {
            // pass the object to EntityDetailed to open it detailed in a form
            if (dgvData.CurrentRow != null)
            {
                T obj = (T)(dgvData.CurrentRow.Cells["Id"].Tag);

                DataRowClick(new RecordEvevtsArgs<T>(obj));
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // when click on a row record open the form to update the record by passing the object
            EditOnRecord();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditOnRecord();
        }
    }
}
