using BLL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Data_Gathering
{
    /// <summary>
    /// This class for invvisible operations done on records
    /// </summary>
    public abstract class clsInvisibleEntity<T> : IInvisibleEntity<T>
    {
        protected IManager<T> _manager;

        public clsInvisibleEntity(IManager<T> manager)
        {
            _manager = manager;
        }

        public bool Update(T t)
        {
            try
            {
                return _manager.Update(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }


        public bool Delete(short Id)
        {
            try
            {
                return _manager.Delete(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Add(ref T t)
        {
            try
            {
                return _manager.Add(ref t);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public abstract T Get(short Id);
    }

    /// <summary>
    /// This class for all operations done on visible record
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class clsEntity<T> : clsInvisibleEntity<T>, IEntity<T>
    {

        public string _menuName { get; private set; }

        public clsEntity(IManager<T> manager, string MenuName) : base(manager)
        {
            _manager = manager;
            _menuName = MenuName;
        }


        public List<T> LoadData()
        {
            try
            {
                return _manager.LoadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<T>();
            }

        }

        public override T Get(short Id)
        {
            return _manager.Get(Id);
        }

    }


}
