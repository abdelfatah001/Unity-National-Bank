using BLL.Manager;
using BLL_BankManagment;
using DAL.Repository;
using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Person;
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
        private enView _view;

        public clsPerson SelectedRecord {  get; set; }

        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEntity;

        public clUpdatesPersonService _UpdateService;

        public clsAddPersonService _AddService;

        public ctrlDetailedPerson()
        {
            InitializeComponent();
        }

        public void Reintialize (enView view, clsPerson person, IInvisibleEntity<clsPerson> personEntity, IPersonValidation personValidation, IReadOnlyEntity<clsCountry> countryEnity)
        {
            SelectedRecord = person;
            _personEntity = personEntity;
            _countryEntity = countryEnity;
            _view = view;


            ShowViewOf();
            switch (_view)
            {
                case enView.Update:
                    _UpdateService = new clUpdatesPersonService(personEntity, SelectedRecord, personValidation, txtFirstName, txtLastName, txtEmail, txtPhone, cbCountries);
                    break;

                case enView.Add:
                    _AddService = new clsAddPersonService(personEntity, SelectedRecord, personValidation, txtFirstName, txtLastName, txtEmail, txtPhone, cbCountries, dateTimePicker1);
                    break;

                case enView.Show: break;

            }

            ((ILoad)this).FillForm();


        }

        private void ShowViewOf()
        {
            if (_view != enView.Add)
                IntializeAgeLabel();

            switch (_view)
            {
                case enView.Add:
                    IntializeDataPicker();
                    ChangeAgeLabelToDate();
                    break;

                case enView.Show:
                    LockUpdate();
                    break;
            }
        }


        private void FillCountriesComboBox()
        {
            if (_view == enView.Show)
            {
                cbCountries.Items.Add(SelectedRecord.Country.Name);
                cbCountries.SelectedIndex = 0;
                return;
            }

            List<clsCountry> countries = _countryEntity.LoadData();

            foreach (clsCountry c in countries)
            {
                cbCountries.Items.Add(c.Name);
            }

        }

        private void FillData()
        {
            if (_view == enView.Add)
                return;

            txtFirstName.Text = SelectedRecord.FirstName;   
            txtLastName.Text = SelectedRecord.LastName; 
            txtEmail.Text = SelectedRecord.Email;
            lblAge.Text = SelectedRecord.Age.ToString();
            txtPhone.Text = SelectedRecord.Phone;   

            if (_view != enView.Show)
                cbCountries.Text = SelectedRecord.Country.Name; //
            
        }

        void ILoad.FillForm ()
        {
            FillCountriesComboBox ();
            FillData();
        }


    }
}
