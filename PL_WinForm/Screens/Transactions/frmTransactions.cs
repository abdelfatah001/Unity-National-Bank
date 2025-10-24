using PL_WinForm.Screens.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Transactions

{
    public partial class frmTransactions : Form, IScreen
    {
        public frmTransactions()
        {
            InitializeComponent();
            rbDeposit.Checked = true;
        }

        Form OpenedScreen = null;

        public void LoadScreen() { }
        public bool IsLoaded { get; set; } = false;

        public void ShowScreen() { }

        private void OpenScreen()
        {
            OpenedScreen.TopLevel = false;
            OpenedScreen.FormBorderStyle = FormBorderStyle.None;
            OpenedScreen.Dock = DockStyle.Fill;

            pnlSubScreen.Controls.Clear();
            pnlSubScreen.Controls.Add(OpenedScreen);

            OpenedScreen.Show();
        }

        private void OpenDepositScreen () 
        {
            OpenedScreen = new frmDeposit();
            OpenScreen();
        }
        private void OpenWithdrawScreen()
        {
            OpenedScreen = new frmWithdraw();
            OpenScreen();
        }
        private void OpenTransfereScreen()
        {
            OpenedScreen = new frmTransfere();
            OpenScreen();
        }

        private void CloseOpenedScreen()
        {
            if (OpenedScreen != null) 
                OpenedScreen.Close();
        }

        private void ChangeScreen (object sender, EventArgs e)
        {
            RadioButton rbSender = sender as RadioButton;

            if (rbSender.Checked == false)
            {
                CloseOpenedScreen();
                return;
            }

            short tag = Convert.ToInt16(rbSender.Tag);

            if (tag < 0 || tag > 2)
                return;

            switch (tag)
            {
                case 0: OpenDepositScreen(); break;
                case 1: OpenWithdrawScreen(); break;
                case 2: OpenTransfereScreen(); break;
                default: break;

            }
        }
    }
}
