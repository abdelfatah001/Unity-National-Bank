using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter
{

    public partial class ctrlDetailedEmployee
    {

        protected virtual void Cancel(EventArgs e)
        {
            OnCancel?.Invoke(this, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (_view)
            {
                case enView.Update :

                    UpdateService.SaveUpdates();
                    break;

                case enView.Add :

                    SelectedRecord = AddService.ReturnFilledObject();
                    AddService.SaveUpdates();
                    break;  
            }

            Cancel(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel(e);
        }


        private void btnShowManager_Click(object sender, EventArgs e)
        {
            GoToManager();
        }
        private void pbBack_Click(object sender, EventArgs e)
        {
            GoBackToEmployee();
        }

    }
}
