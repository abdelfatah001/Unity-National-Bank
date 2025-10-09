using BLL_BankManagment;
using DAL.Repository;
using Models;
using PL_WinForm.Data_Gathering;
using PL_WinForm.Screens.Clients;
using PL_WinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Clients
{
    public partial class frmClients : Form, IClientScreen
    { 
      
         bool IScreen.IsLoaded { get; set; } = false;
        public clsUIEntityScreenManager<clsClient> screenManager { get; set; }


        public frmClients()
        { // used to just intialize the form in sidebar panels tags of different sreens

        }

        public void LoadScreen() 
        { 
            InitializeComponent();

            ((IClientScreen)this).ReintializeCtrl();

            ShowScreen();
        }

        void IRecordsScreen<clsClient>.ReintializeCtrl ()
        {
            screenManager = new clsUIEntityScreenManager<clsClient> ();

            ctrlClientManager1  = new ctrlClientManager(new clsClientEntity(new clsClientManager(new clsClientCache(), new clsClientRepo(new clsClientsRepository(new clsPersonRepository())))));

            this.Controls.Clear();
            this.Controls.Add(ctrlClientManager1);
            ctrlClientManager1.Dock = DockStyle.Fill;

            ctrlClientManager1.OnDataRowClick += CtrlClientManager1_OnDataRowClick;
            ctrlClientManager1.OnAddClick += CtrlClientManager1_OnAddClick;

        }

        public void ShowScreen()
        {
            List<clsClient> Clients = ctrlClientManager1.LoadEntityData();
            if (!Clients.Any())
                MessageBox.Show("No Clients");

            List<string> cloumns = new List<string>
            {"Id", "Status", "First Name", "Last Name", "Join Date", "Phone", "Email", "Country", "Age"};

            ctrlClientManager1.CreateTableHeader(cloumns);

            foreach (clsClient c in Clients)
            {
                List<string> row = new List<string>
                {c.Id.ToString(), c.Status.ToString(), c.Person.FirstName, c.Person.LastName, c.JoinData.ToString(),
                c.Person.Phone, c.Person.Email, c.Person.Country.Name, c.Person.Age.ToString() };

                ctrlClientManager1.AddRow(row, c);
            }

        }

        private void CtrlClientManager1_OnDataRowClick (object sender, RecordEvevtsArgs<clsClient> e)
        {
            if (frmDetailedClient.IsOpened)
                return;


            frmDetailedClient frm = new frmDetailedClient(e.obj, (short) e.RowIndex);
            frm.DataBack += frmDetailedClient_DataBack;
            screenManager.SetMDIParent(this, frm);

            frm.Show();
        }

        private void CtrlClientManager1_OnAddClick(object sender, EventArgs e)
        {
            if (frmAddClients.IsOpened)
                return;

            frmAddClients frm = new frmAddClients();
            frm.DataBack += frmDetailedClient_DataBack;
            screenManager.SetMDIParent(this, frm);

            frm.Show();
        }

        List<string> IRecordsScreen<clsClient>.GetRecordInList(clsClient client)
        {
            return new List<string>
            { client.Id .ToString(), client.Status.ToString(), client.Person.FirstName, client.Person.LastName, client.JoinData.ToString(),
            client.Person.Phone, client.Person.Email, client.Person.Country.Name, client.Person.Age.ToString() };

        }

        private void frmDetailedClient_DataBack (object sender, short Index, clsClient client)
        {
            List<string> row = ((IClientScreen)this).GetRecordInList(client);

            screenManager.ReflectUpdateOnUI(ctrlClientManager1, Index, row, client);
        }

    }
}


