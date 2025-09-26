using Models;
using PL_WinForm.User_Controls;
using PL_WinForm.User_Controls.Details_Presenter.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter
{
    public partial class ctrlDetailedClient : UserControl, IDetailedClient
    {

        public clsClient SelectedRecord { get; set; }

        public event EventHandler OnCancel;


        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEntity;

        public IUpdate UpdateService { get; set; }


        public ctrlDetailedClient()
        {
            InitializeComponent();
        }

        public void Reintialize (clsClient client, IEntity<clsClient> clientEntity, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEntity, bool readOnly = false)
        {

            SelectedRecord = client;
            _personEntity = personEntity;
            _countryEntity = countryEntity;

            ((IReloadPersonCtrl)this).ReintializeCtrl(readOnly);
            ((ILoad)this).FillForm();

            UpdateService = new clsClientUpdateService(client, clientEntity, cbStatus, ctrlDetailedPerson1);
            

            if (readOnly)
                ReadOnlyMode();
        }

        void IReloadPersonCtrl.ReintializeCtrl(bool readOnly)
        {
            ctrlDetailedPerson1.Reintialize(SelectedRecord.Person, _personEntity, _countryEntity, readOnly);

            ctrlDetailedPerson1.Location = new Point(0, 51);

        }

        private void FillData ()
        {
            if (SelectedRecord == null)
                return;

            lblId.Text = SelectedRecord.Id.ToString();  
            lblJoinDate.Text = SelectedRecord.JoinData.ToString();
            cbStatus.Text = SelectedRecord.Status.ToString();
        }

        private void FillStatusComboBox ()
        {
            for (short i = 1; i <= 10; i++)
            {
                cbStatus.Items.Add(((clsClient.enClientStatus)i).ToString());
            }
        }

        void ILoad.FillForm ()
        {
            FillStatusComboBox();
            FillData();
        }


        public bool IsPersonDataChanged()
        {
            return ctrlDetailedPerson1._personService.DataChanged;
        }

    }
}
