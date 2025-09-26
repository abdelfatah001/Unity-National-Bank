using PL_WinForm;
using PL_WinForm.Accounts;
using PL_WinForm.Clients;
using PL_WinForm.Employees;
using PL_WinForm.Home;
using PL_WinForm.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PL_WinForm.Screens;


namespace PL.MainForm
{
    public partial class frmMain : Form
    {
        IScreen _OpenedScreen;

        Panel _clickedPanel;

       
        public frmMain()
        {
            InitializeComponent();
            IntializeSideBarPanelsTag(); 
            CLickPanel(pnlHome); // pnl Home is default to clicked by program running
            StartTimer(); 
            MaximizeSidebar(); 
            
        }
        private void IntializeSideBarPanelsTag()
        {
            // Assign the tags of side bar panels with clsSideBarLabelTag object
            // to store in it which panel is opened and which form (screen) belong to it

            pnlAccounts.Tag = new clsSideBarLabelTag(false, new frmAccounts());

            pnlClients.Tag = new clsSideBarLabelTag(false, new frmClients());

            pnlCurrencies.Tag = new clsSideBarLabelTag(false, new frmCurrencies());

            pnlEmployees.Tag = new clsSideBarLabelTag(false, new frmEmployees());

            pnlHome.Tag = new clsSideBarLabelTag(false, new frmHome());

            pnlRegisterations.Tag = new clsSideBarLabelTag(false, new frmRegisterations());

            pnlTransactions.Tag = new clsSideBarLabelTag(false, new frmTransactions());

            pnlUsers.Tag = new clsSideBarLabelTag(false, new frmUsers());
        }



        private void StartTimer ()
        {
            // Time Show Responsible

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args) =>
            {
                lblDate.Text = DateTime.Now.ToString("ddd, MMM dd");
                lblTime.Text = DateTime.Now.ToString("HH : mm : ss");
                lblHour.Text = DateTime.Now.ToString("HH");
                lblMinute.Text = DateTime.Now.ToString(": mm");
            };
            timer.Start();
        }

        private void ShowScreen ()
        { 
            // Show selected panel is form in a panel of MainScreen besde sidebar
            if (!_OpenedScreen.IsLoaded)
            {
                _OpenedScreen.LoadScreen();
                _OpenedScreen.IsLoaded = true;
            }
            
            Form frm = _OpenedScreen as Form;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlMainScreen.Controls.Clear();
            pnlMainScreen.Controls.Add(frm);
            frm.Show();
        }


        
    }


}
