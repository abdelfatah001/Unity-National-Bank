using DAL.Repository;
using Models;
using PL_WinForm.User_Controls.Details_Presenter.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Models.clsAccount;

namespace PL_WinForm.User_Controls.Details_Presenter.User
{
    public partial class ctrlDetailedUsers : UserControl, IDetailedUser
    {
        private enView _view;

        public clsUser SelectedRecord { get; set; }

        public event EventHandler OnCancel;

        private IEntity<clsEmployee> _employeeEntity;

        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEnity;

        private clsAccessManager _accessManager;

        public IUpdate UpdateService { get; set; }
        public IAdd<clsUser> AddService { get; set; }


        private List<CheckBox> _AccessibilityList = new List<CheckBox>();

        public ctrlDetailedUsers()
        {
            InitializeComponent();
        }

        public void Reintialize (enView view, clsUser user, IEntity<clsUser> userEntity, IEntity<clsEmployee> employeeEntity, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEnity)
        {
            _view = view;
            SelectedRecord = user;
            _employeeEntity = employeeEntity;

            if (_view == enView.Show)
            {
                _personEntity = personEntity;
                _countryEnity = countryEnity;
            }

            FillAccessibilityList();
            ShowViewOf();


            if (_view == enView.Update)
                UpdateService = new clsUpdateUserervice(userEntity, user, txtUsername, txtPassword, lblAccessCode);

            else if (_view == enView.Add)
                AddService = new clsAddUserService(userEntity, ref user, employeeEntity, txtUsername, txtPassword, cbEmployees, lblAccessCode);

            ((ILoad)this).FillForm();
        }

        private void ShowViewOf()
        {

            if (_view != enView.Add)
            {
                IntializeCtrl();
                ((IDetailedUser)this).ReintializeSubCtrl();
                _accessManager = new clsAccessManager(_AccessibilityList, cbxAdmin, lblAccessCode, SelectedRecord.AccessCode);

            }
            switch (_view)
            {
                case enView.Show:
                    ShowReducedView();
                    break;


                case enView.Add:

                    IntializecbEmployees();
                    AddView();
                    _accessManager = new clsAccessManager(_AccessibilityList, cbxAdmin, lblAccessCode, 0);
                    break;
            }
        } 
        void IReLoadCtrl.ReintializeSubCtrl()
        {
            ctrlDetailedEmployee1.Reintailze(enView.Show, SelectedRecord.Employee, _employeeEntity, _personEntity, _countryEnity);
        }

        void ILoad.FillForm()
        {
            FillData();

            if (_view == enView.Add)
                FillcbEmployees();
        }

       

        private void FillData()
        {
            if (_view == enView.Add)
            {
                lblAccessCode.Text = "0";
                return;
            }

            if (SelectedRecord == null)
            {
                MessageBox.Show("User object is not assigned to fill its data");
                return;
            }

            lblId.Text = SelectedRecord.Id.ToString();
            txtUsername.Text = SelectedRecord.UserName;
            txtPassword.Text = SelectedRecord.Password;
            lblEmployeeId.Text = SelectedRecord.Employee.Id.ToString();
            _accessManager.FillAccessibilityCbx();
        }

        private void FillAccessibilityList()
        {
            _AccessibilityList.Add(cbxClientsRO);
            _AccessibilityList.Add(cbxClientsAdmin);

            _AccessibilityList.Add(cbxAccountsRO);
            _AccessibilityList.Add(cbxAccountsAdmin);

            _AccessibilityList.Add(cbxEmployeesRO);
            _AccessibilityList.Add(cbxEmployeesAdmin);

            _AccessibilityList.Add(cbxUsersRO);
            _AccessibilityList.Add(cbxUsersAdmin);

            _AccessibilityList.Add(cbxTransaction);
            _AccessibilityList.Add(cbxRegisterations);
            _AccessibilityList.Add(cbxCurrencies);
        }

        private void FillcbEmployees ()
        {
            List<clsEmployee> employees = _employeeEntity.LoadData();

            foreach (clsEmployee employee in employees)
                cbEmployees.Items.Add(employee.strEmployee());

        }




    }
}
