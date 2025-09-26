using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PL_WinForm.User_Controls.Details_Presenter.Account
{
    public partial class ctrlDetailedAccounts
    {
        private void btnShowEmployee_Click(object sender, EventArgs e)
        {
            ShowClientData();
            btnShowEmployee.Enabled = false;
        }

        private void Cancel (object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (_View)
            { 
                case enView.Show : UpdateService.SaveUpdates(); break;

                case enView.Add :
                    {
                        AddService.Add();
                        SelectedRecord = AddService.ReturnFilledObject();
                        break;
                    }
            }
            
            Cancel(this, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel(this, e);    
        }
    }
}
