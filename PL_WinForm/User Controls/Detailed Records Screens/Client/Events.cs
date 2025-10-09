using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter
{
    public partial class ctrlDetailedClient
    {

        protected virtual void Cancel(EventArgs e)
        {
            OnCancel?.Invoke(this, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_view == enView.Update)
                UpdateService.SaveUpdates();

            else
            {
                SelectedRecord = AddService.ReturnFilledObject();
                AddService.SaveUpdates();
            }
            Cancel(e);
        }




    }
}
