using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_WinForm.User_Controls.Details_Presenter.User
{
    public partial class ctrlDetailedUsers
    {
        protected virtual void Cancel(EventArgs e)
        {
            OnCancel?.Invoke(this, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (_view)
            {
                case enView.Update: UpdateService.SaveUpdates(); break;

                case enView.Add:
                {
                    SelectedRecord = AddService.ReturnFilledObject();
                    AddService.SaveUpdates();
                    break;
                }
            }

            Cancel(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel(e);
        }

        private void btnShowEmployee_Click(object sender, EventArgs e)
        {
            ShowEmployeeData();
          
        }



        private void cbx_CheckChanged(object sender, EventArgs e)
        {
            _accessManager.cbx_CheckChanged(sender, e);
        }

        private void cbxAdmin_CheckChanged(object sender, EventArgs e)
        {
            _accessManager.cbxAdmin_CheckChanged(sender, e);
        }
    }
}
