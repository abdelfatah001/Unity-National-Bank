using PL_WinForm_BankManagment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Main_Screen
{
    partial class frmMain
    {
        // intailize tags of main panels of forms
         private void IntializeListItemsPanelsTag()
        {
            pnlHome.Tag = new clsListItemTag(true);

            pnlAccounts.Tag = new clsListItemTag();
            pnlUsers.Tag = new clsListItemTag();
            pnlClients.Tag = new clsListItemTag();
            pnlEmployees.Tag = new clsListItemTag();
            pnlRegisterations.Tag = new clsListItemTag();
            pnlTransactions.Tag = new clsListItemTag();
            pnlCurrencies.Tag = new clsListItemTag();

        }
        // intialize Date and Time Label
        private void IntializeDateTimeTimer()
        {
            lblDate.Visible = true;
            lblTime.Visible = true;

            Timer timer = new Timer();

            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                lblDate.Text = DateTime.Now.ToString("ddd, MMM dd yyyy");
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                lblHour.Text = DateTime.Now.ToString("HH:");
                lblMinute.Text = DateTime.Now.ToString("mm");
            };

            timer.Start();

        }

        private void HideControls()
        {
            lblHour.Visible = false;
            lblMinute.Visible = false;
        }

       
        // Minimize and Maximize the Sidebar 
        private void ChangeScreen()
        {
            if (pnlList.Size == pnlList.MaximumSize) // Minimize Screen
            {
                pnlList.Size = pnlList.MinimumSize;
                pnlMainScreen.Size = pnlMainScreen.MaximumSize;

                lblDate.Visible = false;
                lblTime.Visible = false;

                lblHour.Visible = true;
                lblMinute.Visible = true;

                lblUsername.Visible = false;
            }
            else // Maximize Screen
            {
                pnlList.Size = pnlList.MaximumSize;
                pnlMainScreen.Size = pnlMainScreen.MinimumSize;

                lblHour.Visible = false;
                lblMinute.Visible = false;

                lblDate.Visible = true;
                lblTime.Visible = true;
                lblUsername.Visible = true;

            }

        }

        // Change between Main Forms of the list

        private void CloseForm(Panel OpenedPanel)
        {
            pnlMainScreen.Controls.Clear();

            clsListItemTag PanelTag = (clsListItemTag)OpenedPanel.Tag;
            PanelTag.IsClicked = false;
            
            OpenedPanel.BackColor = Color.Transparent;
        }

        private void ShowScreen(Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlMainScreen.Controls.Clear();
            pnlMainScreen.Controls.Add(frm);

            OpenedPanel = pnlHome;
            frm.Show();
        }

        private void OpenScreen (Panel pnl)
        {
            if (pnl == pnlHome)
                ShowScreen(new frmHome());

            else if (pnl == pnlAccounts)
                ShowScreen(new frmAccounts());

            else if (pnl == pnlUsers)
                ShowScreen(new frmUsers());

            else if (pnl == pnlClients)
                ShowScreen(new frmClients());

            else if (pnl == pnlTransactions)
                ShowScreen(new frmTransactions());

            else if (pnl == pnlRegisterations)
                ShowScreen(new frmRegisterations());

            else if (pnl == pnlCurrencies)
                ShowScreen(new frmCurrencies());

            else
                ShowScreen(new frmEmployees());
        }

        private void OpenForm(Panel pnl)
        {
            OpenScreen(pnl);

            clsListItemTag pnlTag = (clsListItemTag)pnl.Tag;
            pnlTag.IsClicked = true;

            pnl.BackColor = Color.DeepSkyBlue;

        }


    }
}
