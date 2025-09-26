using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PL_WinForm.User_Controls.Details_Presenter
{
    partial class ctrlDetailedClient
    {
        private void LockUpdate()
        {
            cbStatus.Enabled = false;
        }

        private void DisappearEmployeeId ()
        {
            lblId.Visible = false;
            lblClientId.Visible = false;
        }

        private void DisapppearCloseButtons()
        {
            btnCancel.Visible = false;
            btnSave.Visible = false;
        }

        private void ReadOnlyMode()
        {
            LockUpdate();
            DisappearEmployeeId();
            DisapppearCloseButtons();
        }

        public bool IsVisible ()
        {
            return lblClientId.Visible;
        }

    }
}
