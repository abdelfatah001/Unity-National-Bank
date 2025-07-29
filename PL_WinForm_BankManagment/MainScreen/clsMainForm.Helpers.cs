using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.MainForm
{
    partial class frmMainForm
    {

      /*  private void IntializeDateTimeTimer()
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

        private void IntializeListItemsPanelsTag()
        {
            pnlHome.Tag = new clsListItemTag(true);

            pnlAccounts.Tag = new clsListItemTag();
            pnlClient.Tag = new clsListItemTag();
            pnlEmployee.Tag = new clsListItemTag();
            pnlLogin.Tag = new clsListItemTag();
            pnlTransaction.Tag = new clsListItemTag();
            pnlUser.Tag = new clsListItemTag();
            pnlCurrency.Tag = new clsListItemTag();

        }

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
                pbListResize.Location = new Point(6, 10);
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
                pbListResize.Location = new Point(4, 10);

            }

        }


        private void CloseTheOpenedPanel(Panel OpenedPanel)
        {
            clsListItemTag PanelTag = (clsListItemTag)OpenedPanel.Tag;
            PanelTag.IsClicked = false;

            OpenedPanel.BackColor = Color.Transparent;

            pnlMainScreen.Controls.Clear();
        }

        private void OpenThisPanel(Panel pnl)
        {
            if (pnl == pnlHome)
                ShowHomeScreen();

//            else if (pnl == pnlAccounts)
               

            clsListItemTag pnlTag = (clsListItemTag)pnl.Tag;
            pnlTag.IsClicked = true;

            pnl.BackColor = Color.DeepSkyBlue;

        }

        private void ShowLoginScreen ()
        { 

        }

        private void ShowHomeScreen ()
        {
            frmHome frm = new frmHome();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlMainScreen.Controls.Clear();
            pnlMainScreen.Controls.Add(frm);

            OpenedPanel = pnlHome;
            frm.Show();
        }
           


    }*/
}
