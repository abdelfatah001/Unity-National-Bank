using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.Home
{
    public partial class frmHome : Form, IScreen
    {

        public bool IsLoaded { get; set; } = true;

        public frmHome()
        {
            InitializeComponent();
        }

        public void LoadScreen()
        {

        }
        public void ShowScreen ()
        {

        }

    }
}
