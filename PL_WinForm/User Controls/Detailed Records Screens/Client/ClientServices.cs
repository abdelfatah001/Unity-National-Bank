using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using PL_WinForm.User_Controls.Details_Presenter.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.Client
{
    public class clsUpdateClientService : clsUpdateService<clsClient>
    {


        private ComboBox _cbStatus;

        private ctrlDetailedPerson _ctrlDetailedPerson1;


        public clsUpdateClientService(IEntity<clsClient> entity, clsClient client, ComboBox cbStatus, ctrlDetailedPerson ctrlDetailedPerson1) : base (entity, client)
        {
            _cbStatus = cbStatus;
            _ctrlDetailedPerson1 = ctrlDetailedPerson1;
        }



        public override bool IsDataChanged()
        {
            DataChanged = (_cbStatus.Text != _record.Status.ToString());
            return DataChanged;
        }


        protected override void UpdateObject()
        {
            _record.Status = (clsClient.enClientStatus)_cbStatus.SelectedIndex + 1;
        }


        public override void SaveUpdates()
        {
            enDataUpdated PersonUpdating = enDataUpdated.NotChanged;

            enDataUpdated ClientUpdating = enDataUpdated.NotChanged;

            if (_ctrlDetailedPerson1._UpdateService.IsDataChanged())
            {
                 PersonUpdating = _ctrlDetailedPerson1._UpdateService.Save();
            }
            if (IsDataChanged())
            {
                ClientUpdating = ((IUpdate)this).Save();
            }


            if (PersonUpdating == enDataUpdated.NotChanged && ClientUpdating == enDataUpdated.NotChanged)
                return;

            else
            {
                if (PersonUpdating == enDataUpdated.NotSaved)
                    MessageBox.Show("Person update failed");

                if (ClientUpdating == enDataUpdated.NotSaved)
                    MessageBox.Show("Client update failed");

                if (PersonUpdating == enDataUpdated.Saved || ClientUpdating == enDataUpdated.Saved)
                    MessageBox.Show("client updated successfully");
            }

        }



    }

    public class clsAddClientService : clsAddService<clsClient>
    {

        private ComboBox _cbStatus;
        
        ctrlDetailedPerson _ctrlDetailedPerson1;

        public clsAddClientService(IEntity<clsClient> entity, clsClient client ,ComboBox cbStatus, ctrlDetailedPerson ctrlDetailedPerson1) : base(entity, ref client)
        {
            _cbStatus = cbStatus;
            _ctrlDetailedPerson1 = ctrlDetailedPerson1;
        }


        protected override void FillObject ()
        {
            if (_cbStatus.Text == "")
            {
                MessageBox.Show("Nothing to add");
                operation = enAddingOprtn.Canceled;
                return;
            }

            _recordToAdd = new clsClient();

            operation = enAddingOprtn.Add;

            _recordToAdd.Status = (clsClient.enClientStatus)(_cbStatus.SelectedIndex + 1);
            _recordToAdd.JoinData = DateTime.Now;

        }


        public override void SaveUpdates()
        {

            if (operation == enAddingOprtn.Canceled)
                return;

            clsPerson person = _ctrlDetailedPerson1._AddService.AddPerson();

            if (person == null)
            {
                MessageBox.Show("failed to add person");
                return;
            }
    
            _recordToAdd.Person = person;


            enAddingOprtn processStatus = ((ISave<enAddingOprtn>)this).Save();

            if (processStatus == enAddingOprtn.Canceled)
                return;

            else if (processStatus == enAddingOprtn.Add)
                MessageBox.Show("client added successfully");

            else
                MessageBox.Show("client adding failed");

        }

    }

}
