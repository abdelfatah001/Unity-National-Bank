using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.User
{
    public class clsUpdateUserervice : clsUpdateService<clsUser>
    {

        private TextBox _txtUsername;

        private TextBox _txtPassword;

        private Label _lblAccessCode;

        public clsUpdateUserervice (IEntity<clsUser> entity, clsUser user, TextBox txtUsername, TextBox txtPassword, Label AccessCode)
            : base (entity, user)
        {
            _txtUsername = txtUsername;
            _txtPassword = txtPassword;
            _lblAccessCode = AccessCode;
        }


        public override bool IsDataChanged()
        {
            DataChanged = (_txtUsername.Text != _record.UserName ||
                _txtPassword.Text != _record.Password || Convert.ToInt32(_lblAccessCode.Text) != _record.AccessCode);

            return DataChanged;
        }

        protected override void UpdateObject()
        {
            _record.Update(_txtUsername.Text, _txtPassword.Text, Convert.ToInt32(_lblAccessCode.Text), _record.Employee);
        }

   
        public override void SaveUpdates()
        {
            enDataUpdated UserUpdating = enDataUpdated.NotChanged;

            if (IsDataChanged())
                UserUpdating = ((IUpdate)this).Save();

            if (UserUpdating == enDataUpdated.NotChanged)
                return;

            if (UserUpdating == enDataUpdated.Saved)
                MessageBox.Show("user updated successfully");

            else
                MessageBox.Show("user update failed");

        }
    }

    public class clsAddUserService : clsAddService<clsUser>
    {

        private IEntity<clsUser> _accEntity;

        private IEntity<clsEmployee> _employeeEntity;

        private TextBox _txtUserName;

        private TextBox _txtPassword;

        private ComboBox _cbEmployee;

        private Label _lblAccessibility;

        public clsAddUserService(IEntity<clsUser> userEntity, ref clsUser recordToAdd, IEntity<clsEmployee> employeeEntity, TextBox txtuserName, TextBox txtPassword, ComboBox cbEmployee, Label lblAccessibility)
                : base(userEntity, ref recordToAdd)
        {
            _txtUserName = txtuserName;
            _txtPassword = txtPassword;
            _lblAccessibility = lblAccessibility;
            _cbEmployee = cbEmployee;

            _accEntity = userEntity;
            _employeeEntity = employeeEntity;
        }

        protected override void FillObject()
        {
            if (_cbEmployee.Text == "" || _txtUserName.Text == "" || _txtPassword.Text == "" || _lblAccessibility.Text == "")
            {
                MessageBox.Show("Nothing to add");
                operation = enAddingOprtn.Canceled;
                return;
            }

            operation = enAddingOprtn.Add;

            _recordToAdd = new clsUser();

            clsEmployee employee;
            short Id = Convert.ToInt16(_cbEmployee.Text.Split('-')[0].Trim());
            employee = _employeeEntity.Get(Id);

            _recordToAdd.Update(_txtUserName.Text, _txtPassword.Text, Convert.ToInt16(_lblAccessibility.Text), employee);
        }

      public override void SaveUpdates()
        {

            enAddingOprtn processStatus = ((ISave<enAddingOprtn>)this).Save();

            if (processStatus == enAddingOprtn.Canceled)
                return;

            if (processStatus == enAddingOprtn.Add)
                MessageBox.Show("user added successfully");

            else
                MessageBox.Show("user adding failed");

        }
    }

}

    

  