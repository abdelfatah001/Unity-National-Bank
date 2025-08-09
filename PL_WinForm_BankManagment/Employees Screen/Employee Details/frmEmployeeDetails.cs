using Manager;
using Models;
using PL_WinForm_BankManagment.Users_Screen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Employees_Screen
{
    public partial class frmEmployeeDetails : Form
    {

        public enum enMode
        { Updatable = 0, ReadOnly = 1};

        enMode Mode;

        clsEmployee _SelectedEmployee;

        frmEmployees _EmployeeForm;

        Stack<clsEmployee> _history;



        public frmEmployeeDetails(clsEmployee employee, frmEmployees employeesForm = null)
        {
            LoadCountries();
            InitializeComponent();

            _EmployeeForm = employeesForm;
            _SelectedEmployee = employee;
            Mode = enMode.Updatable;
            
            FillForm();

            UpdateMode();

            _history = new Stack<clsEmployee>();


        }

        public frmEmployeeDetails (clsEmployee employee) // this for read only mode
        {
            InitializeComponent();

            _SelectedEmployee = employee;

            Mode = enMode.ReadOnly;
            FillForm();

            ReadOnlyMode();


        }

    }
}
