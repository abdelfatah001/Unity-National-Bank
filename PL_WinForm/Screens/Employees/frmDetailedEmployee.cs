using BLL_BankManagment;
using BLL_BankManagment.Person_Manager;
using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL_WinForm.Tempelete;
using PL_WinForm.Data_Gathering;
using System.Windows.Forms;
using PL_WinForm.User_Controls.Details_Presenter;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Person;

namespace PL_WinForm.Screens.Employees
{
    public partial class frmDetailedEmployee : Form, IDetailedEmployeeScreen
    {

        public frmDetailedEmployee (clsEmployee employee, short index)
        {
            IsOpened = true;
            InitializeComponent();
            ((IDetailedEmployeeScreen)this).ReintializeCtrl(employee);
            _indexInMenu = index;
        }

        public short _indexInMenu { get; set; } = -1;

        public event DataBackEventHandler<clsEmployee> DataBack;

        public static bool IsOpened { get; set; } = false;

        void IAddRecordScreen<clsEmployee>.ReintializeCtrl (clsEmployee employee)
        {
            ctrlDetailedEmployee1.Reintailze(enView.Update, employee,
                new clsEmployeeEntity(new clsEmployeeManager(new clsEmployeeCache(), new clsEmployeeRepo(new clsEmployeesRepository(new clsPersonRepository())))),
                new clsPersonEntity(new clsPersonManager(new clsPersonCache(), new clsPersonRepo(new clsPersonRepository()))),
                new clsPersonDataValidation(),
                new clsCountryEntity(new clsCountriesManager(new clsCountriesCache(), new clsCountriesRepo(new clsCountriesRepository()))));

            ctrlDetailedEmployee1.Dock = DockStyle.Fill;
            ctrlDetailedEmployee1.OnCancel += CtrlDetailedEmployee1_OnCancel;
        }



        void IAddRecordScreen<clsEmployee>.SendObjToShowMenu()
        {
            if (ctrlDetailedEmployee1.UpdateService.DataChanged || ctrlDetailedEmployee1.IsPersonDataChanged()) 
                DataBack?.Invoke(this, _indexInMenu, ctrlDetailedEmployee1.SelectedRecord);
        }
        private void Cancel()
        {
            IsOpened = false;
            this.Close();
        }


        private void CtrlDetailedEmployee1_OnCancel(object sender, EventArgs e)
        {
            ((IDetailedEmployeeScreen)this).SendObjToShowMenu();
            Cancel();
        }

        private void frmDetailedEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsOpened = false;
        }


    }
}
