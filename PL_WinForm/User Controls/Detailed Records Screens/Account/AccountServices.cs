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
    internal class clsUpdateAccountService : clsUpdateService<clsAccount>
    {
        private ComboBox _cbAccountStatus;


        public clsUpdateAccountService(IEntity<clsAccount> accountEntity, clsAccount account, ComboBox cbAccountStatus)
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

    internal class clsAddAccountService : clsAddService<clsAccount>
    {

        ComboBox cbAcctStatus;

        ComboBox cbClients;

        ComboBox cbCurrencies;

        private IEntity<clsAccount> _accEntity;

        private IReadOnlyEntity<clsCurrency> _currencyEntity;

        private IEntity<clsClient> _clientEntity;

        public clsAddAccountService(IEntity<clsAccount> accEntity, ref clsAccount recordToAdd, IEntity<clsClient> clientEntity, IReadOnlyEntity<clsCurrency> currencyEntity, ComboBox cbAccountStatus, ComboBox cbClientsList, ComboBox cbCurrenciesList)
                : base (accEntity, ref recordToAdd)
        {
            cbAcctStatus = cbAccountStatus;
            cbClients = cbClientsList;
            cbCurrencies = cbCurrenciesList;

            _accEntity = accEntity;
            _clientEntity = clientEntity;
            _currencyEntity = currencyEntity;
        }

        protected override void FillObject()
        {
            if (cbAcctStatus.Text == "" || cbClients.Text == "" || cbCurrencies.Text == "")
            {
                MessageBox.Show("Nothing to add");
                operation = enAddingOprtn.Canceled;
                return;
            }

            operation = enAddingOprtn.Add;

            _recordToAdd = new clsAccount();

            clsAccount.enAccountStatus status = (clsAccount.enAccountStatus)(cbAcctStatus.SelectedIndex + 1);

            List<clsCurrency> currencies = _currencyEntity.LoadData();

            string currencyCode = (cbCurrencies.Text.Split('-')[0].Trim());

            clsCurrency currency = new clsCurrency();

            foreach (clsCurrency cur in currencies)
                if (cur.Code == currencyCode)  currency = cur;


            short ownerClientId = Convert.ToInt16(cbClients.Text.Split('-')[0].Trim());

            clsClient client = _clientEntity.Get(ownerClientId);


            _recordToAdd.Update(0, DateTime.Now, client, currency, status);  

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

        public override void SaveUpdates()
        {

            enAddingOprtn processStatus  = ((ISave<enAddingOprtn>)this).Save();

            if (processStatus == enAddingOprtn.Canceled)
                return;

            if (processStatus == enAddingOprtn.Add)
                MessageBox.Show("account updated successfully");

            else
                MessageBox.Show("account update failed");

        }
    }

}
