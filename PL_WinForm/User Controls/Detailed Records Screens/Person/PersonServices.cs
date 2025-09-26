using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.Person
{
    public class clsPersonpdateService : clsUpdateService<clsPerson>
    {

        private TextBox _txtFirstName;
        private TextBox _txtLastName;
        private TextBox _txtEmail;
        private TextBox _txtPhone;
        private ComboBox _cbCountries;

        public clsPersonpdateService (IInvisibleEntity<clsPerson> personEntity, clsPerson person, TextBox txtFirstName, TextBox txtLastName, TextBox txtEmail, TextBox txtPhone, ComboBox cbCountries)
            : base (personEntity, person) 
        {
            _txtFirstName = txtFirstName;
            _txtLastName = txtLastName;
            _txtEmail = txtEmail;
            _txtPhone = txtPhone;

            _cbCountries = cbCountries;
        }


        public override bool IsDataChanged()
        {
            DataChanged = _txtFirstName.Text != _record.FirstName ||
                _txtLastName.Text != _record.LastName ||
                _txtEmail.Text != _record.Email ||
                _txtPhone.Text != _record.Phone ||
                _cbCountries.Text != _record.Country.Name;

            return DataChanged;
        }

        protected override void UpdateObject()
        {
            _record.FirstName = _txtFirstName.Text;
            _record.LastName = _txtLastName.Text;
            _record.Email = _txtEmail.Text;
            _record.Phone = _txtPhone.Text;

            if (_cbCountries.SelectedIndex != -1) // if country changed cuz if it doen't the selected index will be -1
                _record.Country.Id = (short)(_cbCountries.SelectedIndex + 1);

            _record.Country.Name = _cbCountries.Text;
        }

        public enDataUpdated Save()
        {
            if (!DataChanged)
                return enDataUpdated.NotChanged;

            UpdateObject();

            bool IsUpdated = _Entity.Update(_record);


            return (IsUpdated) ? enDataUpdated.Saved : enDataUpdated.NotChanged;

        }



        public override void SaveUpdates()
        {
        }

    }
}
