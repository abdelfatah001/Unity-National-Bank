using BLL_BankManagment;
using BLL_BankManagment.Person_Manager;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Tempelete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Screens.Accounts
{
    public partial class frmAddAccount : Form, IAddAccountScreen
    {

        public event DataBackEventHandler<clsAccount> DataBack;


        public static bool IsOpened = false;


        public frmAddAccount()
        {
            InitializeComponent();

            IsOpened = true;

            ((IAddAccountScreen)this).ReintializeCtrl(null);
        }

        void IAddRecordScreen<clsAccount>.ReintializeCtrl(clsAccount acc)
        {
            ctrlDetailedAccounts1.Reintialize(User_Controls.Details_Presenter.enView.Add, acc,
                new clsAccountEntity(new clsAccountManager(new clsAccountCache(), new clsAccountRepo(new clsAccountsRepository(new clsClientsRepository(new clsPersonRepository()))))),
                new clsClientEntity(new clsClientManager(new clsClientCache(), new clsClientRepo(new clsClientsRepository(new clsPersonRepository())))),
                new clsPersonEntity(new clsPersonManager(new clsPersonCache(), new clsPersonRepo(new clsPersonRepository()))),
                new clsCountryEntity(new clsCountriesManager(new clsCountriesCache(), new clsCountriesRepo(new clsCountriesRepository()))),
                new clsCurrencyEntity(new clsCurrencyManager(new clsCurrencyCache(), new clsCurrencyRepo(new clsCurrencyRepository(new clsCountriesRepository())))));


            ctrlDetailedAccounts1.OnCancel += CtrlDetailedAccounts1_OnCancel;
        }

        void IAddRecordScreen<clsAccount>.SendObjToShowMenu()
        {
            if (!ctrlDetailedAccounts1.AddService.IsCanceled())
                DataBack?.Invoke(this, -1, ctrlDetailedAccounts1.SelectedRecord);
        }

        private void Cancel ()
        {
            IsOpened = false;
            this.Close();
        }

        private void CtrlDetailedAccounts1_OnCancel(object sender, EventArgs e)
        {
            ((IAddAccountScreen)this).SendObjToShowMenu();
            Cancel();
        }

        private void frmAddAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsOpened = false;
        }
    }
}
