using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using PL_WinForm.User_Controls.Details_Presenter.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.Client
{
    public class clsClientUpdateService : clsUpdateService<clsClient>
    {


        private ComboBox _cbStatus;

        private ctrlDetailedPerson _ctrlDetailedPerson1;


        public clsClientUpdateService(clsClient client, IEntity<clsClient> entity, ComboBox cbStatus, ctrlDetailedPerson ctrlDetailedPerson1) : base (entity, client)
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

            if (_ctrlDetailedPerson1._personService.IsDataChanged())
            {
                 PersonUpdating = _ctrlDetailedPerson1._personService.Save();
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
}
