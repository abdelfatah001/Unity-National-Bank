using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.User
{
    public partial class ctrlDetailedUsers : UserControl, IDetailedUser
    {
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

        public ctrlDetailedUsers(enView view)
        {
            InitializeComponent();

            if (view == enView.Show)
                IntializeCtrl();
        }

        public void Reintialize (clsUser user, IEntity<clsUser> userEntity, IEntity<clsEmployee> employeeEntity, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEnity)
        {

            SelectedRecord = user;
            _employeeEntity = employeeEntity;
            _personEntity = personEntity;
            _countryEnity = countryEnity;

            FillAccessibilityList();

            _accessManager = new clsAccessManager(_AccessibilityList, cbxAdmin, lblAccessCode, SelectedRecord.AccessCode);
            UpdateService = new clsUserUpdateService(SelectedRecord, userEntity, txtUsername, txtPassword, lblAccessCode);

            ((ILoad)this).FillForm();
            ((IDetailedUser)this).ReintializeCtrl();
            ShowReducedView();
        }

        void ILoad.FillForm()
        {
            FillData();
        }

        void IReLoadCtrl.ReintializeCtrl()
        {
            ctrlDetailedEmployee1.Reintailze (SelectedRecord.Employee, _employeeEntity, _personEntity, _countryEnity, true);
        }

        private void FillData()
        {
            if (SelectedRecord == null)
                return;

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



    }
}
