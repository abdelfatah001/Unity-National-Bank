using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using PL_WinForm.User_Controls.Details_Presenter.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.Account
{
    public partial class ctrlDetailedAccounts : UserControl, IDetailedAccount
    {
        private enView _view;

        public clsAccount SelectedRecord { get; set; }


        private IEntity<clsAccount> _accountEntity;

        private IEntity<clsClient> _clientEntity;

        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEnity;

        private IReadOnlyEntity<clsCurrency> _currencyEntity;

        public event EventHandler OnCancel;


        public IUpdate UpdateService { get; set; }

        public IAdd<clsAccount> AddService { get; set; }

        public ctrlDetailedAccounts()
        {
            InitializeComponent();
        }

     
        void IReLoadCtrl.ReintializeSubCtrl()
        {
            ctrlDetailedClient1.Reintialize(enView.Show, SelectedRecord.client, _clientEntity, _personEntity, _countryEnity);
            ctrlDetailedClient1.Location = new Point(0, 250);

        }
        public void Reintialize (enView view, clsAccount account, IEntity<clsAccount> accountEntity, IEntity<clsClient> clienteEntity, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEnity, IReadOnlyEntity<clsCurrency> currencyEntity)
        {
            _view = view;
            SelectedRecord = account;
            _accountEntity = accountEntity;
            _clientEntity = clienteEntity;
            _currencyEntity = currencyEntity;

            if (_view == enView.Show)
            {
                _personEntity = personEntity;
                _countryEnity = countryEnity;
            }

            ShowViewOf();
            ((IDetailedAccount)this).FillForm();

            if (_view == enView.Update)
                UpdateService = new clsUpdateAccountService(accountEntity, account, cbAccountStatus);

            else if (_view ==  enView.Add)
                AddService = new clsAddAccountService(accountEntity, ref account,  clienteEntity, _currencyEntity, cbAccountStatus, cbClients, cbCurrency);

        }

        private void ShowViewOf()
        {
            if (_view != enView.Add)
            {
                IntializeCtrl();
                ((IDetailedAccount)this).ReintializeSubCtrl();
                ShowReducedView();
            }

            else
            {
                IntializecbClients();
                AddView();
            }
        }


        void ILoad.FillForm()
        {
            if (_view == enView.Add)
            { 
                FillClientsComboBox();
                FillCurrencyComboBox();
            }

            FillStatusComboBox();
            FillData();
        }

        private void FillStatusComboBox ()
        {
            if (_view == enView.Show)
            {
                cbAccountStatus.Items.Add(SelectedRecord.Status.ToString());
                cbAccountStatus.SelectedIndex = 0;
                return;
            }

            for (int i = 1; i <= 10; i++)
                cbAccountStatus.Items.Add( ((clsAccount.enAccountStatus)i).ToString() );

        }

        private void FillClientsComboBox ()
        {
            List<clsClient> accounts = _clientEntity.LoadData();

            foreach (clsClient client in accounts)
                cbClients.Items.Add(client.strClient());
        }

        private void FillCurrencyComboBox()
        { 
            List<clsCurrency> currencies = _currencyEntity.LoadData();

            foreach (clsCurrency currency in currencies)
                cbCurrency.Items.Add(currency.Code + $"  - {currency.country.Name} -");
        }

        private void FillData ()
        {
            if (_view == enView.Add)
                return;

            if (SelectedRecord == null)
            {
                MessageBox.Show("Account object is not assigned to fill its data");
                return;
            }

            lblId.Text = SelectedRecord.Id.ToString();
            lblAccountName.Text = SelectedRecord.AccountName.ToString();
            lblCreatedDate.Text = SelectedRecord.CreatedDate.ToString();
            lblClientId.Text = SelectedRecord.client.Id.ToString();
            lblBalance.Text = SelectedRecord.Balance.ToString();

            cbCurrency.Items.Add(SelectedRecord.currency.strCurrnecy());
            cbCurrency.SelectedIndex = 0;

            if (_view != enView.Show)
                cbAccountStatus.SelectedIndex = ((int)SelectedRecord.Status) - 1;
        }

}
}
