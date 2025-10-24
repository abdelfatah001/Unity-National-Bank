using BLL_BankManagment;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Screens.Clients;
using PL_WinForm.Screens.Employees;
using PL_WinForm.User_Controls;
using PL_WinForm.User_Controls.Details_Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PL_WinForm.Employees
{
    public partial class frmEmployees : Form, IEmployeeScreen
    {

        bool IScreen.IsLoaded { get; set; } = false;
        public clsUIEntityScreenManager<clsEmployee> screenManager { get; set; }

        public frmEmployees ()
        {

        }

        
        public void LoadScreen()
        {
            InitializeComponent();

            ((IEmployeeScreen)this).ReintializeCtrl();

            ShowScreen();

        }
        void IRecordsScreen<clsEmployee>.ReintializeCtrl()
        {
            screenManager = new clsUIEntityScreenManager<clsEmployee>();

            ctrlEmployeeManager1 = new ctrlEmployeeManager(new clsEmployeeEntity(new clsEmployeeManager
                (new clsEmployeeCache(), new clsEmployeeRepo(new clsEmployeesRepository(new clsPersonRepository())))));

            this.Controls.Clear();
            this.Controls.Add(ctrlEmployeeManager1);
            ctrlEmployeeManager1.Dock = DockStyle.Fill;

            ctrlEmployeeManager1.OnDataRowClick += ctrlEmployeeManager1_OnDataRowClick;
            ctrlEmployeeManager1.OnAddClick += CtrlEmployeeManager1_OnAddClick;
        }

        public void ShowScreen ()
        {
            List<clsEmployee> employees = ctrlEmployeeManager1.LoadEntityData();
            List<string> columns = new List<string>()
            { "Id", "First Name", "Last Name", "Salary", "Department", "Manager Id", "Age", "Country", "Phone", "Email" };

            ctrlEmployeeManager1.CreateTableHeader(columns);
            foreach (clsEmployee emp in employees)
            {
                List<string> row = new List<string>()
                {
                    emp.Id.ToString(), emp.Person.FirstName, emp.Person.LastName, emp.Salary.ToString(),
                    emp.Department.ToString(), emp.ManagerId.ToString(), emp.Person.Age.ToString(),
                    emp.Person.Country.Name, emp.Person.Phone, emp.Person.Email
                };

                ctrlEmployeeManager1.AddRow(row, emp);
            }
        }

        private void ctrlEmployeeManager1_OnDataRowClick (object sender, RecordEvevtsArgs<clsEmployee> e)
        {
             if (frmDetailedEmployee.IsOpened)
                return;


            frmDetailedEmployee frm = new frmDetailedEmployee(e.obj, (short) e.RowIndex);
            frm.DataBack += frm_DataBack;
            screenManager.SetMDIParent(this, frm);

            frm.Show();

        }

        List<string> IRecordsScreen<clsEmployee>.GetRecordInList(clsEmployee emp)
        {
            if (emp.Person == null)
                return new List<string>();

           return new List<string>
           {
                emp.Id.ToString(), emp.Person.FirstName, emp.Person.LastName, emp.Salary.ToString(),
                emp.Department.ToString(), emp.ManagerId.ToString(), emp.Person.Age.ToString(),
                emp.Person.Country.Name, emp.Person.Phone, emp.Person.Email
           };

        }

        private void frm_DataBack (object sender, short index, clsEmployee emp)
        {
            List<string> row = ((IEmployeeScreen)this).GetRecordInList(emp);

            screenManager.ReflectUpdateOnUI(ctrlEmployeeManager1, index, row, emp);
        }

        private void CtrlEmployeeManager1_OnAddClick(object sender, EventArgs e)
        {
            if (frmAddEmployee.IsOpened)
                return;

            frmAddEmployee frm = new frmAddEmployee();
            frm.DataBack += frm_DataBack;
            screenManager.SetMDIParent(this, frm);

            frm.Show();
        }

    }
}
