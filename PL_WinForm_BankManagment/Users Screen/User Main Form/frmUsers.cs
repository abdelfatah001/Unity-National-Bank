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

namespace PL_WinForm_BankManagment.Users_Screen
{
    public partial class frmUsers : Form
    {
        public int IndexOfClickedUser = 0;

        public frmUsers()
        {
            LoadUsers();
            InitializeComponent();
            FillUsersDGV();
        }

       
    }
}
