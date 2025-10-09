using Models;
using PL_WinForm.User_Controls;
using PL_WinForm.User_Controls.Details_Presenter.Client;
using PL_WinForm.User_Controls.Details_Presenter.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Models.clsEmployee;

namespace PL_WinForm.User_Controls.Details_Presenter
{
    public partial class ctrlDetailedClient : UserControl, IDetailedClient
    {
        private enView _view;

        public clsClient SelectedRecord { get; set; }

        public event EventHandler OnCancel;


        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEntity;

        public IUpdate UpdateService { get; set; }
        
        public IAdd<clsClient> AddService { get; set; }


        public ctrlDetailedClient()
        {
            InitializeComponent();
        }

        public void Reintialize (enView view, clsClient client, IEntity<clsClient> clientEntity, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEntity)
        {
            _view = view;

            SelectedRecord = client;
            _personEntity = personEntity;
            _countryEntity = countryEntity;

            ((IReLoadCtrl)this).ReintializeSubCtrl();

            ((ILoad)this).FillForm();

            if (_view == enView.Update)
                UpdateService = new clsUpdateClientService(clientEntity, client, cbStatus, ctrlDetailedPerson1);

            else if (_view == enView.Add)
                AddService = new clsAddClientService(clientEntity, client, cbStatus, ctrlDetailedPerson1);


            ShowViewOf();

        }

        private void ShowViewOf ()
        {
            switch (_view)
            {
                case enView.Show:
                    ReadOnlyMode();
                    break;

                case enView.Add:
                    AddMode();
                    break;
            }
        }


        void IReLoadCtrl.ReintializeSubCtrl()
        {
            if (_view != enView.Add)
                ctrlDetailedPerson1.Reintialize(_view, SelectedRecord.Person, _personEntity, _countryEntity);

            else ctrlDetailedPerson1.Reintialize(_view, null, _personEntity, _countryEntity);

            ctrlDetailedPerson1.Location = new Point(0, 51);

        }

        private void FillData ()
        {
            if (_view == enView.Add)
                return;

            if (SelectedRecord == null)
            {
                MessageBox.Show("Client object is not assigned to fill its data");
                return;
            }

            lblId.Text = SelectedRecord.Id.ToString();  
            lblJoinDate.Text = SelectedRecord.JoinData.ToString();

            if (_view != enView.Show)
                cbStatus.Text = SelectedRecord.Status.ToString();
        }

        private void FillStatusComboBox ()
        {
            if (_view == enView.Show)
            {
                cbStatus.Items.Add(SelectedRecord.Status.ToString());
                cbStatus.SelectedIndex = 0;
                return;
            }

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
            return ctrlDetailedPerson1._UpdateService.DataChanged;
        }

    }
}
