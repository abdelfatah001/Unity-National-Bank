using BLL_BankManagment;
using BLL_BankManagment.Person_Manager;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Tempelete;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Screens.Employees
{
    public partial class frmAddEmployee : Form, IAddEmployeeScreen
    {

        public event DataBackEventHandler<clsEmployee> DataBack;

        public static bool IsOpened = false;

        public clsUIEntityScreenManager<clsAccount> screenManager { get; set; }


        public frmAddEmployee()
        {
            InitializeComponent();

            IsOpened = true;

            ((IAddEmployeeScreen)this).ReintializeCtrl(null);
        }

        void IAddRecordScreen<clsEmployee>.ReintializeCtrl (clsEmployee emp)
        {
            ctrlDetailedEmployee1.Reintailze(User_Controls.Details_Presenter.enView.Add,
                emp, new clsEmployeeEntity(new clsEmployeeManager(new clsEmployeeCache(), new clsEmployeeRepo(new clsEmployeesRepository(new clsPersonRepository())))),
                 new clsPersonEntity(new clsPersonManager(new clsPersonCache(), new clsPersonRepo(new clsPersonRepository()))),
                 new clsPersonDataValidation(),
                new clsCountryEntity(new clsCountriesManager(new clsCountriesCache(), new clsCountriesRepo(new clsCountriesRepository()))));

            ctrlDetailedEmployee1.OnCancel += CtrlDetailedEmployee1_OnCancel;
        }

       

        void IAddRecordScreen<clsEmployee>.SendObjToShowMenu ()
        {
            if (!ctrlDetailedEmployee1.AddService.IsCanceled())
                DataBack?.Invoke(this, -1, ctrlDetailedEmployee1.SelectedRecord);
        } 
        

        private void Cancel ()
        {
            IsOpened = false;
            this.Close();
        }

        private void CtrlDetailedEmployee1_OnCancel(object sender, EventArgs e)
        {
            ((IAddEmployeeScreen)this).SendObjToShowMenu();
            Cancel();
        }

        private void frmAddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsOpened = false;
        }
    }
}
