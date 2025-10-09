using BLL_BankManagment;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Screens.Accounts;
using PL_WinForm.User_Controls;
using PL_WinForm.User_Controls.Details_Presenter.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Accounts
{
    public partial class frmAccounts : Form, IAccountScreen
    {

        public bool IsLoaded { get; set; } = false;

        public clsUIEntityScreenManager<clsAccount> screenManager { get; set; }

        public frmAccounts()
        {

        }
        public void LoadScreen ()
        {
            InitializeComponent();

            ((IAccountScreen)this).ReintializeCtrl();

            ShowScreen();

            ctrlAccountManager1.OnDataRowClick += CtrlAccountManager1_OnDataRowClick;
            ctrlAccountManager1.OnAddClick += CtrlAccountManager1_OnAddClick;
        }

       

        void IRecordsScreen<clsAccount>.ReintializeCtrl ()
        {
            screenManager = new clsUIEntityScreenManager<clsAccount>();

            ctrlAccountManager1 = new ctrlAccountManager(new clsAccountEntity(new clsAccountManager(new clsAccountCache(), new clsAccountRepo(new clsAccountsRepository(new clsClientsRepository(new clsPersonRepository()))))));
            
            this.Controls.Clear();
            this.Controls.Add(ctrlAccountManager1);

            ctrlAccountManager1.Dock = DockStyle.Fill;
        }



        public void ShowScreen ()
        {
            List<clsAccount> accounts = ctrlAccountManager1.LoadEntityData();
            List<string> columns = new List<string>
            { "Id", "Account Name", "Status", "Balance", "Created Date", "Currency", "Client Id"};

            ctrlAccountManager1.CreateTableHeader(columns);

            foreach (clsAccount acc in accounts)
            {
                List<string> row = new List<string>
                { acc.Id.ToString(), acc.AccountName, acc.Status.ToString(), acc.Balance.ToString(), acc.CreatedDate.ToString(), acc.currency.Name, acc.client.Id.ToString()};

                ctrlAccountManager1.AddRow(row, acc);
            }

            
        }
        private void CtrlAccountManager1_OnAddClick(object sender, EventArgs e)
        {
            if (frmAddAccount.IsOpened)
                return;

            frmAddAccount frm = new frmAddAccount();

            frm.DataBack += Frm_DataBack;

            screenManager.SetMDIParent(this, frm);

            frm.Show();
        }

        private void CtrlAccountManager1_OnDataRowClick(object sender, RecordEvevtsArgs<clsAccount> e)
        {
            if (frmDetailedAccount.IsOpened)
                return;

            frmDetailedAccount frm = new frmDetailedAccount(e.obj,(short) e.RowIndex);

            frm.DataBack += Frm_DataBack; ;

            screenManager.SetMDIParent(this, frm);

            frm.Show();

        }

        private void Frm_DataBack(object sender, short index, clsAccount account)
        {
            List<string> row = ((IAccountScreen)this).GetRecordInList(account);

            screenManager.ReflectUpdateOnUI(ctrlAccountManager1, index, row, account);
        }

      
        List<string> IRecordsScreen<clsAccount>.GetRecordInList (clsAccount account)
        {
            return new List<string>
            {
                account.Id.ToString(), account.AccountName, account.Status.ToString(), account.Balance.ToString(), account.CreatedDate.ToString(),
                account.currency.Name, account.client.Id.ToString()
            };
        }
    }
}
