using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manager;
using Models;
using PL_WinForm_BankManagment.Employees_Screen;

namespace PL_WinForm_BankManagment.Employees_Screen
{

    

    public partial class frmEmployees : Form
    {
           
        public int IndexOfClickedEmployee = 0;

   
        public frmEmployees()
        {
            LoadEmployees();
            InitializeComponent();
            FillEmployeesDGV();

        }

  
    }
}
