using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PL_WinForm_BankManagment.Main_Screen
{
    internal class clsListItemTag
    {

        public bool IsClicked;

        public clsListItemTag(bool IsClicked = false) 
        { 
            this.IsClicked = IsClicked; 
        }
    }

}
