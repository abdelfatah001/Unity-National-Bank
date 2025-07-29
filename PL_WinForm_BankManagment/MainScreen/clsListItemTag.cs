using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PL_WinForm_BankManagment.MainForm
{
    internal class clsListItemTag
    {
        public bool IsClicked = false;


        public clsListItemTag(bool IsClicked = false)
        {
            this.IsClicked = IsClicked;
        }
    }
}
