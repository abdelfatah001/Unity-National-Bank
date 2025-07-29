using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Main_Screen
{
    partial class frmMain
    {

        // Minimize and Maximize Main Form side bar

        private void pbListResize_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeScreen();
        }

        // ListResize picture box events //

        // Mouse Enter event
        private void pbListResize_MouseEnter(object sender, EventArgs e)
        {
            pbList.BackColor = Color.FromArgb(181, 221, 225);
        }

        // Mouse Leave event
        private void pbListResize_MouseLeave(object sender, EventArgs e)
        {
            pbList.BackColor = Color.Transparent;
        }

        // List items events (Labels) (Picture box) //

        // Mouse Enter event
        private void ListItems_MouseEnter_Labels(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((Label)sender).Parent;
            pnl.BackColor = Color.DeepSkyBlue;
        }
        private void ListItems_MouseEnter_PictureBox(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((PictureBox)sender).Parent;
            pnl.BackColor = Color.DeepSkyBlue;
        }

        // Mouse Leave event
        private void MouseLeaveListPanel(Panel pnl)
        {
            clsListItemTag pnlTag = (clsListItemTag)pnl.Tag;

            if (!pnlTag.IsClicked) // If doesn't clicked return it
            {
                pnl.BackColor = Color.Transparent;
            }

        }

        private void ListItems_MouseLeave_Labels(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((Label)sender).Parent;
            MouseLeaveListPanel(pnl);
        }
        private void ListItems_MouseLeave_PictureBox(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((PictureBox)sender).Parent;
            MouseLeaveListPanel(pnl);
        }

        // Click event 
        private void ClickListPanel(Panel pnl)
        {
            CloseForm(OpenedPanel);
            OpenForm(pnl);
            OpenedPanel = pnl; // change the openedpanel to the opened one
        }

        private void ListItems_Click_Label(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((Label)sender).Parent;

            ClickListPanel(pnl);
        }

        private void ListItems_Click_PictureBox(object sender, EventArgs e)
        {
            Panel pnl = (Panel)((PictureBox)sender).Parent;

            ClickListPanel(pnl);
        }

        // LogOut Panel events //

        private void Logout_MouseEnter(object sender, EventArgs e)
        {
            pnlLogout.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void Logout_MouseLeave(object sender, EventArgs e)
        {
            pnlLogout.BackColor = Color.Transparent;
        }

        private void Logout(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
