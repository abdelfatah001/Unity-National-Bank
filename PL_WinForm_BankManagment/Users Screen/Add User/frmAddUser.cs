using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Users_Screen
{
    public partial class frmAddUser : Form
    {

        frmUsers frmUser = null;

        public frmAddUser(frmUsers frmUser)
        {
            InitializeComponent();
            this.frmUser = frmUser;
        }

   
    }
}
