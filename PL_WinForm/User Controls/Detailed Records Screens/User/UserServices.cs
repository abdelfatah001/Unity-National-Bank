using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.User
{
    public class clsUserUpdateService : clsUpdateService<clsUser>
    {

        private TextBox _txtUsername;

        private TextBox _txtPassword;

        private Label _lblAccessCode;

        public clsUserUpdateService (clsUser user, IEntity<clsUser> entity, TextBox txtUsername, TextBox txtPassword, Label AccessCode)
            : base (entity, user)
        {
            _txtUsername = txtUsername;
            _txtPassword = txtPassword;
            _lblAccessCode = AccessCode;
        }


        public override bool IsDataChanged()
        {
            DataChanged = (_txtUsername.Text == _record.UserName ||
                _txtPassword.Text == _record.Password);

            return DataChanged;
        }

        protected override void UpdateObject()
        {
            _record.UserName = _txtUsername.Text;
            _record.Password = _txtPassword.Text;
            _record.AccessCode = Convert.ToInt32(_lblAccessCode.Text);
        }

        public enDataUpdated Save()
        {
            if (!DataChanged)
                return enDataUpdated.NotChanged;

            UpdateObject();

            if (_Entity.Update(_record))
                return enDataUpdated.Saved;

            return enDataUpdated.NotSaved;
        }

        public override void SaveUpdates()
        {
            enDataUpdated UserUpdating = enDataUpdated.NotChanged;

            if (IsDataChanged())
            {
                UserUpdating = Save();
            }

            if (UserUpdating == enDataUpdated.NotChanged)
                return;

            if (UserUpdating == enDataUpdated.Saved)
                MessageBox.Show("user updated successfully");

            else
                MessageBox.Show("user update failed");

        }
    }
}
