using DAL.Repository;
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
using PL_WinForm.User_Controls;
using PL_WinForm.Screens.Clients;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Screens.Employees;
using System.Windows.Forms.VisualStyles;
using PL_WinForm.User_Controls.Details_Presenter;
using BLL_BankManagment;

namespace PL_WinForm.Employees
{
    public partial class frmEmployees : Form, IEmployeeScreen
    {


        public frmEmployees ()
        {

        }

        
        bool IScreen.IsLoaded { get; set; } = false;

        public void LoadScreen()
        {
            InitializeComponent();

            ((IEmployeeScreen)this).ReintializeCtrl();

            ShowScreen();

        }
        void IRecordsScreen<clsEmployee>.ReintializeCtrl()
        {
            ctrlEmployeeManager1 = new ctrlEmployeeManager(new clsEmployeeEntity(new clsEmployeeManager
                (new clsEmployeeCache(), new clsEmployeeRepo(new clsEmployeesRepository(new clsPersonRepository())))));

            this.Controls.Clear();
            this.Controls.Add(ctrlEmployeeManager1);
            ctrlEmployeeManager1.Dock = DockStyle.Fill;

            ctrlEmployeeManager1.OnDataRowClick += ctrlEmployeeManager1_OnDataRowClick;
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
            frm.DataBack += frmDetailedEmployee_DataBack;
            frm.Show();

        }
        
        public void ReflectUpdateOnUI(short index, clsEmployee emp)
        {
            List<string> row = new List<string>
            {       emp.Id.ToString(), emp.Person.FirstName, emp.Person.LastName, emp.Salary.ToString(),
                    emp.Department.ToString(), emp.ManagerId.ToString(), emp.Person.Age.ToString(),
                    emp.Person.Country.Name, emp.Person.Phone, emp.Person.Email
            };

            ctrlEmployeeManager1.UpdateRow(index, row, emp);
        }

        private void frmDetailedEmployee_DataBack (object sender, short index, clsEmployee emp)
        {
            ReflectUpdateOnUI (index, emp);
        }
    }
}
