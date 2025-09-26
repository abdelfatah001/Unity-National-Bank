using BLL_BankManagment;
using BLL_BankManagment.Person_Manager;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Tempelete;
using PL_WinForm.User_Controls.Details_Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Screens.Clients
{
    public partial class frmDetailedClient : Form, IDetailedClientScreen
    { 
        public frmDetailedClient(clsClient client, short Index)
        {
            IsOpened = true;
            InitializeComponent();
            ((IDetailedScreen<clsClient>)this).ReintializeCtrl(client);
            _indexInMenu = Index;
        }


        public short _indexInMenu { get; set; } = -1;

        public static bool IsOpened = false;
        
        public event DataBackEventHandler<clsClient> DataBack;

       

        void IAddRecordScreen<clsClient>.ReintializeCtrl(clsClient client)
        {
            ctrlDetailedClient1.Reintialize(client
                , new clsClientEntity
                    (new clsClientManager(new clsClientCache(), new clsClientRepo(new clsClientsRepository(new clsPersonRepository()))))
                , new clsPersonEntity(new clsPersonManager(new clsPersonCache(), new clsPersonRepo(new clsPersonRepository()))),
                new clsCountryEntity(new clsCountriesManager(new clsCountriesCache(), new clsCountriesRepo(new clsCountriesRepository()))));

            ctrlDetailedClient1.Dock = DockStyle.Fill;
            ctrlDetailedClient1.OnCancel += ctrlDetailedClient1_OnCancel;

        }

        void IAddRecordScreen<clsClient>.SendObjToShowMenu ()
        {
            if (ctrlDetailedClient1.UpdateService.DataChanged || ctrlDetailedClient1.IsPersonDataChanged())
                DataBack?.Invoke(this, _indexInMenu, ctrlDetailedClient1.SelectedRecord);
        }

        private void ctrlDetailedClient1_OnCancel(object sender, EventArgs e)
        {
            IsOpened = false;
            ((IDetailedScreen<clsClient>)this).SendObjToShowMenu();
            this.Close();
        }

        private void frmDetailedClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsOpened = false;
        }

        
    }
}
