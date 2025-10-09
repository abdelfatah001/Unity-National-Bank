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
            DisappearEmployeeId();
            DisapppearCloseButtons();
        }

        public bool IsVisible ()
        {
            return lblClientId.Visible;
        }

        private void DisappearJoinDate ()
        {
            lblJoinDate.Visible = false;
            lbl_JoinDate.Visible = false;
        }

        private void AddMode()
        {
            DisappearJoinDate();
        }

    }
}
