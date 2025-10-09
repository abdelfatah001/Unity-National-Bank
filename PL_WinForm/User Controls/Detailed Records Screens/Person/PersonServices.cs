using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PL_WinForm.User_Controls.Details_Presenter.Person
{
    public class clUpdatesPersonService : clsUpdateService<clsPerson>
    {

        private TextBox _txtFirstName;
        private TextBox _txtLastName;
        private TextBox _txtEmail;
        private TextBox _txtPhone;
        private ComboBox _cbCountries;

        public clUpdatesPersonService (IInvisibleEntity<clsPerson> personEntity, clsPerson person, TextBox txtFirstName, TextBox txtLastName, TextBox txtEmail, TextBox txtPhone, ComboBox cbCountries)
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
            clsCountry country = new clsCountry((short)(_cbCountries.SelectedIndex + 1), _cbCountries.Text);

            _record.Update(_txtFirstName.Text, _txtLastName.Text, country, _txtEmail.Text, _txtPhone.Text);
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

    public class clsAddPersonService
    {

        IInvisibleEntity<clsPerson> _PersonEntity;

        private TextBox _txtFirstName;
        private TextBox _txtLastName;
        private TextBox _txtEmail;
        private TextBox _txtPhone;
        private ComboBox _cbCountries;
        private DateTimePicker _dtpDateOfBirth;

        private clsPerson _person;

        private bool DataChanged { get; set; } = false;

        protected enAddingOprtn operation = enAddingOprtn.Canceled;


        public clsAddPersonService(IInvisibleEntity<clsPerson> personEntity, clsPerson person, TextBox txtFirstName, TextBox txtLastName, TextBox txtEmail, TextBox txtPhone, ComboBox cbCountries, DateTimePicker dtpDateOfBirth)
        {
            _PersonEntity = personEntity;
            _txtFirstName = txtFirstName;
            _txtLastName = txtLastName;
            _txtEmail = txtEmail;
            _txtPhone = txtPhone;
            _cbCountries = cbCountries; 
            _dtpDateOfBirth = dtpDateOfBirth;   

            _person = person;
        }

        private void FillPersonObject ()
        {
            if (_txtFirstName.Text == "" || _txtLastName.Text == "" || _txtEmail.Text == "" || _txtPhone.Text == "" || _cbCountries .Text == "")
            {
                MessageBox.Show("Nothing to add");
                operation = enAddingOprtn.Canceled;
                return;
            }

            operation = enAddingOprtn.Add;

            clsCountry country = new clsCountry((short)(_cbCountries.SelectedIndex + 1), _cbCountries.Text);

            _person = new clsPerson(_txtFirstName.Text, _txtLastName.Text, _dtpDateOfBirth.Value, country, _txtEmail.Text, _txtPhone.Text);
        }

        public clsPerson AddPerson ()
        {

            FillPersonObject();

            if (operation == enAddingOprtn.Canceled) return null;

            if (_PersonEntity.Add(ref _person)) return _person;

            else return null;
        }
    }

}
