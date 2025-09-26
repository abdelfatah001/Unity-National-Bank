using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls
{
    public abstract partial class ctrlEntityManager<T> : UserControl
    {
        public ctrlEntityManager()
        {
            InitializeComponent();
        }

        IEntity<T> _entity;


        /// <summary>
        /// constructor to show list of records control
        /// </summary>
        /// <param name="entity">The entity to show its record</param>
        public ctrlEntityManager(IEntity<T> entity)
        {
            InitializeComponent();
            this._entity = entity;
            this.lblMenu.Text = entity._menuName;
        }

        /// <summary>
        /// Load entity data 
        /// </summary>
        /// <returns></returns>
        public List<T> LoadEntityData()
        {
            try
            {
                List<T> t = _entity.LoadData();
                //   if (t.Any()) { MessageBox.Show("Loaded"); }
                return t;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return null;
        }

        /// <summary>
        /// Create the columns of the data grid view
        /// </summary>
        /// <param name="columns">List of string by columns name</param>
        public void CreateTableHeader(List<string> columns)
        {
            foreach (var column in columns)
            {
                this.dgvData.Columns.Add(column, column);
            }
        }

        /// <summary>
        /// Add row in the data grid view
        /// </summary>
        /// <param name="row">List of string of the data of the record</param>
        /// <param name="obj">the object itself to stored in the row's tag </param>
        public void AddRow(List<string> row, T obj)
        {
            int index = dgvData.Rows.Add(row.ToArray()); // returns index of new row
            dgvData.Rows[index].Tag = obj;
        }

        /// <summary>
        /// Resize the data grid view according to number of columns
        /// </summary>
        /// <param name="width">The width of the data grid view</param>
        public void ResizeDGV(int width)
        {
            dgvData.Size = new Size(width, dgvData.Size.Height);
            ReLoacate();
        }

        /// <summary>
        /// To relocate the data grid view in the x axis according to the new width
        /// </summary>
        private void ReLoacate()
        {
            int totalWidth = this.Width;
            int DGVWidth = this.dgvData.Width;

            int StartPoint = (totalWidth - DGVWidth) / 2;
            dgvData.Location = new Point(StartPoint, this.dgvData.Location.Y);
        }

        /// <summary>
        /// Reflect update of a record in the UI after updating it
        /// </summary>
        /// <param name="RowIndex">the index of the row to update in the data grid view</param>
        /// <param name="lstRow">list of string of the new data of the record></param>
        /// <param name="obj">the new object to add the row's tag</param>
        public void UpdateRow(short RowIndex, List<string> lstRow, T obj)
        {
            DataGridViewRow row = dgvData.Rows[RowIndex];
            for (short i = 0; i < row.Cells.Count; i++)
            {
                row.Cells[i].Value = lstRow[i];
            }
            dgvData.Rows[RowIndex].Tag = obj;
        }


    }


    /// <summary>
    /// The control to show clients list
    /// </summary>
    public class ctrlClientManager : ctrlEntityManager<clsClient>
    {
        public ctrlClientManager() : base() { }
        public ctrlClientManager(IEntity<clsClient> entity) : base(entity) { }


    }

    /// <summary>
    /// The control to show employees list
    /// </summary>
    public class ctrlEmployeeManager : ctrlEntityManager<clsEmployee>
    {
        public ctrlEmployeeManager() : base() { }
        public ctrlEmployeeManager(IEntity<clsEmployee> entity) : base(entity) { }
    }

    /// <summary>
    /// The control to show users list
    /// </summary>
    public class ctrlUsersManager : ctrlEntityManager<clsUser>
    {
        public ctrlUsersManager() : base() { }
        public ctrlUsersManager(IEntity<clsUser> entity) : base(entity) { }
    }

    /// <summary>
    /// The control to show accounts list
    /// </summary>
    public class ctrlAccountManager : ctrlEntityManager<clsAccount>
    {
        public ctrlAccountManager() : base() { }
        public ctrlAccountManager(IEntity<clsAccount> entity) : base(entity) { }
    }


}
