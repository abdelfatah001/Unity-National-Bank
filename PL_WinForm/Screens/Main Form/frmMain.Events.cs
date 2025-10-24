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

            if (SidbarSize == enSidebarSize.Expanded) 
            { // if the sidebar panel maximized minimize it and maximize main panel
                pnlSideBar.Size = new Size(53, 658);
                pnlMainScreen.Size = new Size(824, 658);
                pnlMainScreen.Location = new Point(53, 0);
                MinimizeSidebar();
            }
            else
            { // vice versa
                pnlSideBar.Size = new Size(192, 658);
                pnlMainScreen.Size = new Size(689, 658);
                pnlMainScreen.Location = new Point(188, 0);
                MaximizeSidebar();

            }
        }

        private void pbSideBarDrawer_MouseEnter(object sender, EventArgs e)
        {
            pbSideBarDrawer.BackColor = Color.Turquoise;
        }

        private void pbSideBarDrawer_MouseLeave(object sender, EventArgs e)
        {
            pbSideBarDrawer.BackColor = Color.MediumTurquoise;
        }

        // sidebar components
        private void DeclickClickedPanel()
        {
            _clickedPanel.BackColor = Color.DeepSkyBlue;
            ((clsSideBarLabelTag)(_clickedPanel.Tag)).Declick();
        }

        private void CLickPanel(Panel pnl)
        {
            // Assign _screen with pnl and show it

            _clickedPanel = pnl;
            clsSideBarLabelTag panelTag = (clsSideBarLabelTag)pnl.Tag;
            panelTag.IsClicked = true;
            _OpenedScreen = panelTag.screen;

            pnl.BackColor = Color.DarkTurquoise;
            ShowScreen();
        }

        private void OnSideBarLabelClick(object sender, EventArgs e)
        { 
            // to change between screens

            DeclickClickedPanel();

            Panel pnl = (Panel)((Label)sender).Parent;

            CLickPanel(pnl);
        }

        private void OnSideBarPictureBoxClick(object sender, EventArgs e)
        {
            // to change between screens

            DeclickClickedPanel();

            Panel pnl = (Panel)((PictureBox)sender).Parent;
            CLickPanel(pnl);
            pnl.BackColor = Color.DarkTurquoise;
        }

        private void OnSideBarLabel_MouseEnter(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((Label)sender).Parent;

            pnl.BackColor = Color.DarkTurquoise;
        }

        private void OnSideBarLabel_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((Label)sender).Parent;

            if (((clsSideBarLabelTag)(pnl.Tag)).IsClicked)
                return;

            pnl.BackColor = Color.DeepSkyBlue;
        }

        private void OnSideBarPictureBox_MouseEnter(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((PictureBox)sender).Parent;

            pnl.BackColor = Color.DarkTurquoise;
        }

        private void OnSideBarPictureBox_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((PictureBox)sender).Parent;

            if (((clsSideBarLabelTag)(pnl.Tag)).IsClicked)
                return;

            pnl.BackColor = Color.DeepSkyBlue;
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
            pnlLogout.BackColor = Color.DeepSkyBlue;
        }

        // Time and date

        private void MinimizeSidebar()
        {
            // show the time in compacted labels cuz the side bar is minimized and the main panel is maximized

            lblTime.Visible = false;
            lblDate.Visible = false;

            lblMinute.Visible = true;
            lblHour.Visible = true;

            SidbarSize = enSidebarSize.shrinked;
        }

        private void MaximizeSidebar()
        {
            // show the time in detailed labels cuz the side bar is maximized and the main panel is minimized

            lblMinute.Visible = false;
            lblHour.Visible = false;

            lblTime.Visible = true;
            lblDate.Visible = true;

            SidbarSize = enSidebarSize.Expanded;

        }



    }
    
}
