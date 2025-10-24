using BLL_BankManagment;
using BLL_BankManagment.Person_Manager;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Tempelete;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Person;
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
    public partial class frmAddClients : Form, IAddClientScreen
    {

        public event DataBackEventHandler<clsClient> DataBack;

        public static bool IsOpened = false;


        public frmAddClients()
        {
            InitializeComponent();

            IsOpened = true;

            ((IAddClientScreen)this).ReintializeCtrl(null);
        }


        void IAddRecordScreen<clsClient>.ReintializeCtrl(clsClient client)
        {
            ctrlDetailedClient1.Reintialize(User_Controls.Details_Presenter.enView.Add,
                null, new clsClientEntity(new clsClientManager(new clsClientCache(), new clsClientRepo(new clsClientsRepository(new clsPersonRepository())))),
                 new clsPersonEntity(new clsPersonManager(new clsPersonCache(), new clsPersonRepo(new clsPersonRepository()))),
                 new clsPersonDataValidation(),
                new clsCountryEntity(new clsCountriesManager(new clsCountriesCache(), new clsCountriesRepo(new clsCountriesRepository()))));

            ctrlDetailedClient1.OnCancel += CtrlDetailedClient1_OnCancel;
        }

      

        void IAddRecordScreen<clsClient>.SendObjToShowMenu()
        {
            if (!ctrlDetailedClient1.AddService.IsCanceled())
                DataBack?.Invoke(this, -1, ctrlDetailedClient1.SelectedRecord);
        }  
        
        private void Cancel ()
        {
            IsOpened = false;
            this.Close();
        }
        
        private void CtrlDetailedClient1_OnCancel(object sender, EventArgs e)
        {
            ((IAddClientScreen)this).SendObjToShowMenu();
            Cancel();
        }
    }
}
