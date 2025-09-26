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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.Account
{
    public partial class ctrlDetailedAccounts : UserControl, IDetailedAccount
    {
        private enView _View;

        public clsAccount SelectedRecord { get; set; }

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

     
        void IReLoadCtrl.ReintializeCtrl()
        {
            ctrlDetailedClient1.Reintialize(SelectedRecord.client, _clientEntity, _personEntity, _countryEnity, true);
            ctrlDetailedClient1.Location = new Point(0, 250);

        }
        public void Reintialize (enView view, clsAccount account, IEntity<clsAccount> accountEntity, IEntity<clsClient> clienteEntity, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEnity, IReadOnlyEntity<clsCurrency> currencyEntity)
        {

            SelectedRecord = account;
            _clientEntity = clienteEntity;
            _personEntity = personEntity;
            _countryEnity = countryEnity;
            _currencyEntity = currencyEntity;


            ShowViewOf(view);
            ((IDetailedAccount)this).FillForm();

            switch (_View)
            {
                case enView.Show:
                    UpdateService = new clsAccountUpdateService(account, accountEntity, cbAccountStatus);
                    ((IDetailedAccount)this).ReintializeCtrl();
                    break;

                case enView.Add:
                    AddService = new clsAccountAddService(accountEntity,  clienteEntity, _currencyEntity, ref account, cbAccountStatus, cbClients, cbCurrency);
                    break;
            }
            
            


        }

        private void ShowViewOf (enView view)
        {
            _View = view;

            switch (_View)
            {
                case enView.Show:

                    IntializeCtrl();
                    ShowReducedView();
                    break;


                case enView.Add:

                    IntializecbClients();
                    AddView();
                    break;
            }
        }


        void ILoad.FillForm()
        {
            if (_View == enView.Add)
            { 
                FillClientsComboBox();
                FillCurrencyComboBox();
            }

            FillStatusComboBox();
            FillData();
        }

        private void FillStatusComboBox ()
        {
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
            if (SelectedRecord == null)
                return;

            lblId.Text = SelectedRecord.Id.ToString();
            lblAccountName.Text = SelectedRecord.AccountName.ToString();
            lblCreatedDate.Text = SelectedRecord.CreatedDate.ToString();
            lblClientId.Text = SelectedRecord.client.Id.ToString();
            lblBalance.Text = SelectedRecord.Balance.ToString();

            cbCurrency.Items.Add(SelectedRecord.currency.strCurrnecy());
            cbCurrency.SelectedIndex = 0;

            cbAccountStatus.SelectedIndex = ((int)SelectedRecord.Status) - 1;
        }

}
}
