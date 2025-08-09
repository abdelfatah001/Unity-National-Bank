using PL_WinForm_BankManagment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PL_WinForm_BankManagment.Employees_Screen;
using PL_WinForm_BankManagment.Users_Screen;

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
            {
                if (FormHome == null)
                {
                    FormHome = new frmHome();
                }
                ShowScreen(FormHome);


            }
            else if (pnl == pnlAccounts)
            {
                if (FormAccounts == null)
                {
                    FormAccounts = new frmAccounts();
                }
                ShowScreen(FormAccounts);
            }

            else if (pnl == pnlUsers)
            {
                if (FormUsers == null)
                {
                    FormUsers = new frmUsers();
                }
                ShowScreen(FormUsers);
            }

            else if (pnl == pnlClients)
            {
                if (FormClients == null)
                {
                    FormClients = new frmClients();
                }
                ShowScreen(FormClients);

            }

            else if (pnl == pnlTransactions)
            {
                if (FormTransactions == null)
                {
                    FormTransactions = new frmTransactions();
                }
                ShowScreen(FormTransactions);

            }

            else if (pnl == pnlRegisterations)
            {
                if (FormRegisterations == null)
                {
                    FormRegisterations = new frmRegisterations();
                }
                ShowScreen(FormRegisterations);
            }

            else if (pnl == pnlCurrencies)
            {
                if (FormCurrencies == null)
                {
                    FormCurrencies = new frmAccounts();
                }
                ShowScreen(FormCurrencies);

            }

            else if (pnl == pnlEmployees)
            {
                if (FormEmployees == null)
                {
                    FormEmployees = new frmEmployees();
                    ShowScreen(FormEmployees);
                }
                ShowScreen(FormEmployees);
            }

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
