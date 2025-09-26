using BLL.Manager;
using BLL_BankManagment;
using DAL.Repository;
using Models;
using PL_WinForm.User_Controls.Details_Presenter.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter
{
    public partial class ctrlDetailedPerson : UserControl, IDetailedPerson
    {
        public clsPerson SelectedRecord {  get; set; }

        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEntity;

        public clsPersonpdateService _personService;

        public ctrlDetailedPerson()
        {
            InitializeComponent();
        }

        public void Reintialize (clsPerson person, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEnity, bool readOnly = false)
        {
            SelectedRecord = person;
            _personEntity = personEntity;
            _countryEntity = countryEnity;

            _personService = new clsPersonpdateService(personEntity, SelectedRecord, txtFirstName, txtLastName, txtEmail, txtPhone, cbCountries);

            ((ILoad)this).FillForm();

            if (readOnly)
                LockUpdate();

        }

        private void FillCountriesComboBox()
        {

            List<clsCountry> countries = _countryEntity.LoadData();

            foreach (clsCountry c in countries)
            {
                cbCountries.Items.Add(c.Name);
            }

        }

        private void FillData()
        {
            if (SelectedRecord != null)
            {
                txtFirstName.Text = SelectedRecord.FirstName;   
                txtLastName.Text = SelectedRecord.LastName; 
                txtEmail.Text = SelectedRecord.Email;
                lblAge.Text = SelectedRecord.Age.ToString();
                txtPhone.Text = SelectedRecord.Phone;   
                cbCountries.Text = SelectedRecord.Country.Name;
            }
        }

        void ILoad.FillForm ()
        {
            FillCountriesComboBox ();
            FillData();
        }


    }
}
