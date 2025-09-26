using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.Account
{
    internal class clsAccountUpdateService : clsUpdateService<clsAccount>
    {
        private ComboBox _cbAccountStatus;


        public clsAccountUpdateService(clsAccount account, IEntity<clsAccount> accountEntity, ComboBox cbAccountStatus)
           :  base (accountEntity, account)
        {
            _cbAccountStatus = cbAccountStatus;
        }


        public override bool IsDataChanged()
        {
            DataChanged = ( (_cbAccountStatus.SelectedIndex + 1) != (int) _record.Status );

            return DataChanged;
        }


        protected override void UpdateObject()
        {
            _record.Status = (clsAccount.enAccountStatus) _cbAccountStatus.SelectedIndex + 1;
        }


        public enDataUpdated Save()
        {
            if (!DataChanged)
                return enDataUpdated.NotChanged;

            UpdateObject();

            return (_Entity.Update(_record)) ? enDataUpdated.Saved : enDataUpdated.NotSaved;
        }

        public override void SaveUpdates()
        {
            enDataUpdated AccountUpdating = enDataUpdated.NotChanged;

            if (IsDataChanged())
            {
                AccountUpdating = Save();
            }

            if (AccountUpdating == enDataUpdated.NotChanged)
                return;

            if (AccountUpdating == enDataUpdated.Saved)
                MessageBox.Show("account updated successfully");

            else
                MessageBox.Show("account update failed");

        }
    }

    internal class clsAccountAddService : clsAddService<clsAccount>
    {

        ComboBox cbAcctStatus;

        ComboBox cbClients;

        ComboBox cbCurrencies;

        private IEntity<clsAccount> _accEntity;

        private IReadOnlyEntity<clsCurrency> _currencyEntity;

        private IEntity<clsClient> _clientEntity;

        public clsAccountAddService(IEntity<clsAccount> accEntity, IEntity<clsClient> clientEntity, IReadOnlyEntity<clsCurrency> currencyEntity, ref clsAccount recordToAdd, ComboBox cbAccountStatus, ComboBox cbClientsList, ComboBox cbCurrenciesList)
                : base (accEntity, ref recordToAdd)
        {
            cbAcctStatus = cbAccountStatus;
            cbClients = cbClientsList;
            cbCurrencies = cbCurrenciesList;

            _accEntity = accEntity;
            _clientEntity = clientEntity;
            _currencyEntity = currencyEntity;
        }

        protected override void FillObjectData()
        {
            if (cbAcctStatus.Text == "" || cbClients.Text == "" || cbCurrencies.Text == "")
            {
                MessageBox.Show("Nothing to add");
                operation = enAddingOprtn.Canceled;
                return;
            }

            operation = enAddingOprtn.Adding;

            _recordToAdd = new clsAccount();

            _recordToAdd.Balance = 0;
            _recordToAdd.CreatedDate = DateTime.Now;

            _recordToAdd.Status = (clsAccount.enAccountStatus)(cbAcctStatus.SelectedIndex + 1);


            string currencyCode = (cbCurrencies.Text.Split('-')[0].Trim());

            List<clsCurrency> currencies = _currencyEntity.LoadData();

            foreach (clsCurrency currency in currencies)
                if (currency.Code == currencyCode)  _recordToAdd.currency = currency;



            short ownerClientId = Convert.ToInt16(cbClients.Text.Split('-')[0].Trim());

            List<clsClient> clients = _clientEntity.LoadData();

            foreach (clsClient client in clients)
                if (client.Id == ownerClientId)  _recordToAdd.client = client;

            GenerateAccountName();


        }

        private void GenerateAccountName ()
        {
            if (_recordToAdd == null)
                return;

            List<clsAccount> accounts = _accEntity.LoadData();

            short LastAccId = accounts[accounts.Count - 1].Id;


            _recordToAdd.AccountName = "ACC" + ( LastAccId + 1).ToString().PadLeft(4, '0'); // to make the id in 4 digitals fill the remaining with zeros

        }


        public override void Add()
        {
            FillObjectData();
            InsertInternal();
        }



    }

}
