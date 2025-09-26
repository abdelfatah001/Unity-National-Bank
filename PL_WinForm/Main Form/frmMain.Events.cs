using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PL_WinForm;

namespace PL.MainForm
{  
    class clsSideBarLabelTag
    {
        public bool IsClicked;
        public IScreen screen;


        public clsSideBarLabelTag(bool isClicked, IScreen screen)
        {
            IsClicked = isClicked;
            this.screen = screen;
        }

        public void Declick()
        {
            IsClicked = false;
        }
    }

    partial class frmMain
    {


        // sidebar 
        private void SideBarDrawer(object sender, EventArgs e)
        {
            // switch th sidebar drawer 

            if (pnlSideBar.Size == pnlSideBar.MaximumSize) 
            { // if the sidebar panel maximized minimize it and maximize main panel
                pnlSideBar.Size = pnlSideBar.MinimumSize;
                pnlMainScreen.Size = pnlMainScreen.MaximumSize;
                MinimizeSidebar();
            }
            else
            { // vice versa
                pnlSideBar.Size = pnlSideBar.MaximumSize;
                pnlMainScreen.Size = pnlMainScreen.MinimumSize;
                MaximizeSidebar();

            }
        }

        private void pbSideBarDrawer_MouseEnter(object sender, EventArgs e)
        {
            pbSideBarDrawer.BackColor = Color.DarkGray;
        }

        private void pbSideBarDrawer_MouseLeave(object sender, EventArgs e)
        {
            pbSideBarDrawer.BackColor = Color.CadetBlue;
        }

        // sidebar components
        private void DeclickClickedPanel()
        {
            _clickedPanel.BackColor = Color.CadetBlue;
            ((clsSideBarLabelTag)(_clickedPanel.Tag)).Declick();
        }

        private void CLickPanel(Panel pnl)
        {
            // Assign _screen with pnl and show it

            _clickedPanel = pnl;
            clsSideBarLabelTag panelTag = (clsSideBarLabelTag)pnl.Tag;
            panelTag.IsClicked = true;
            _OpenedScreen = panelTag.screen;
            ShowScreen();
        }

        private void OnSideBarLabelClick(object sender, EventArgs e)
        { 
            // to change between screens

            DeclickClickedPanel();

            Panel pnl = (Panel)((Label)sender).Parent;

            CLickPanel(pnl);
            pnl.BackColor = Color.DeepSkyBlue;
        }

        private void OnSideBarPictureBoxClick(object sender, EventArgs e)
        {
            // to change between screens

            DeclickClickedPanel();

            Panel pnl = (Panel)((PictureBox)sender).Parent;
            CLickPanel(pnl);
            pnl.BackColor = Color.DeepSkyBlue;
        }

        private void OnSideBarLabel_MouseEnter(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((Label)sender).Parent;

            pnl.BackColor = Color.DeepSkyBlue;
        }

        private void OnSideBarLabel_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((Label)sender).Parent;

            if (((clsSideBarLabelTag)(pnl.Tag)).IsClicked)
                return;

            pnl.BackColor = Color.CadetBlue;
        }

        private void OnSideBarPictureBox_MouseEnter(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((PictureBox)sender).Parent;

            pnl.BackColor = Color.DeepSkyBlue;
        }

        private void OnSideBarPictureBox_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((PictureBox)sender).Parent;

            if (((clsSideBarLabelTag)(pnl.Tag)).IsClicked)
                return;

            pnl.BackColor = Color.CadetBlue;
        }


        // logout 

        private void Logout()
        {
            this.Close();
        }

        private void OnLogOutClick(object sender, EventArgs e)
        {
            Logout();
        }

        private void OnLogoutPanel_MouseEnter(object sender, EventArgs e)
        {
            pnlLogout.BackColor = Color.FromArgb(192, 0, 0);
        }
        private void OnLogoutPanel_MouseLeave(object sender, EventArgs e)
        {
            pnlLogout.BackColor = Color.CadetBlue;
        }

        // Time and date

        private void MinimizeSidebar()
        {
            // show the time in compacted labels cuz the side bar is minimized and the main panel is maximized

            lblTime.Visible = false;
            lblDate.Visible = false;

            lblMinute.Visible = true;
            lblHour.Visible = true;
        }

        private void MaximizeSidebar()
        {
            // show the time in detailed labels cuz the side bar is maximized and the main panel is minimized

            lblMinute.Visible = false;
            lblHour.Visible = false;

            lblTime.Visible = true;
            lblDate.Visible = true;
        }

        

    }
    
}
