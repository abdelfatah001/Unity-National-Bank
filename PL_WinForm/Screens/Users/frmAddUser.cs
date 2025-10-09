using BLL_BankManagment;
using BLL_BankManagment.Person_Manager;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Tempelete;
using PL_WinForm.User_Controls.Details_Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Screens.Users
{
    public partial class frmAddUser : Form, IAddUserScreen
    {
        public frmAddUser()
        {
            InitializeComponent();

            IsOpened = true;

            ((IAddUserScreen)this).ReintializeCtrl(null);
        }

        public static bool IsOpened = false;

        public event DataBackEventHandler<clsUser> DataBack;

        void IAddRecordScreen<clsUser>.ReintializeCtrl(clsUser user)
        {
            ctrlDetailedUsers1.Reintialize(enView.Add, user,
                    new clsUserEntity(new clsUserManager(new clsUserCache(), new clsUserRepo(new clsUsersRepository(new clsEmployeesRepository(new clsPersonRepository()))))),
                 new clsEmployeeEntity(new clsEmployeeManager(new clsEmployeeCache(), new clsEmployeeRepo(new clsEmployeesRepository(new clsPersonRepository())))),
                new clsPersonEntity(new clsPersonManager(new clsPersonCache(), new clsPersonRepo(new clsPersonRepository()))),
                new clsCountryEntity(new clsCountriesManager(new clsCountriesCache(), new clsCountriesRepo(new clsCountriesRepository()))));

            ctrlDetailedUsers1.OnCancel += CtrlDetailedUsers1_OnCancel;
        }



        void IAddRecordScreen<clsUser>.SendObjToShowMenu ()
        {
            if (!ctrlDetailedUsers1.AddService.IsCanceled())
                DataBack?.Invoke(this, -1, ctrlDetailedUsers1.SelectedRecord);
        }

        private void Cancel ()
        {
            IsOpened = false;
            this.Close();
        }
        private void CtrlDetailedUsers1_OnCancel(object sender, EventArgs e)
        {
            ((IAddUserScreen)this).SendObjToShowMenu();
            Cancel();
        }

        private void frmAddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsOpened = false;
        }
    }
}
