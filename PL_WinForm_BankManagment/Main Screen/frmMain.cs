using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Main_Screen
{
    public partial class frmMain : Form
    {
        Panel OpenedPanel;
        public frmMain()
        {
            InitializeComponent();
            IntializeListItemsPanelsTag();
            HideControls();
            IntializeDateTimeTimer();
            ShowScreen(new frmHome());
        }

  
    }
}
