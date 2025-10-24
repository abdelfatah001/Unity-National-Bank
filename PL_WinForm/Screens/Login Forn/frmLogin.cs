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

namespace PL_WinForm.Screens.Login_Forn
{
    public partial class frmLogin : Form
    {
        IEntity<clsUser> _entity;

        public frmLogin(IEntity<clsUser> entity)
        {
            InitializeComponent();
            _entity = entity;
        }




    }
}
