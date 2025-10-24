using BLL.Manager;
using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Person;
using PL_WinForm.User_Controls.Details_Presenter.Employee;
using PL_WinForm.User_Controls.Details_Presenter.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter
{
    public partial class ctrlDetailedEmployee : UserControl, IDetailedEmployee
    {
        private enView _view;

        public clsEmployee SelectedRecord { get; set; }

        public event EventHandler OnCancel;

        private IEntity<clsEmployee> _employeeEntity;

        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEntity;

        public IUpdate UpdateService { get; set; }

        public IAdd<clsEmployee> AddService { get; set; }

        private IPersonValidation _personValidation;


        public ctrlDetailedEmployee()
        {
            InitializeComponent();
        }

        public void Reintailze(enView view, clsEmployee employee, IEntity<clsEmployee> employeeEntity, IInvisibleEntity<clsPerson> personEntity, IPersonValidation personValidation, IReadOnlyEntity<clsCountry> countryEnity)
        {
            _view = view;

            _employeeEntity = employeeEntity;
            _personEntity = personEntity;
            _countryEntity = countryEnity;
            _personValidation = personValidation;

            if (employee != null)
                FillEmployeeManager(employee);


            ((IReLoadCtrl)this).ReintializeSubCtrl(personValidation);

            ((ILoad)this).FillForm();

            if (_view == enView.Update)
                UpdateService = new clsUpdateEmployeeService(employeeEntity, employee, ctrlDetailedPerson1, cbManager, cbDepartments, txtSalary);

            else if (_view == enView.Add)
                AddService = new clsAddEmployeeService(employeeEntity, employee, ctrlDetailedPerson1, cbManager, cbDepartments, txtSalary);

            ShowViewOf();
        }

        private void ShowViewOf()
        {
            DisappearBackIcon();

            switch (_view)
            {
                case enView.Show:
                    ReadOnlyMode();
                    break;

                case enView.Add:
                    AddMode();
                    break;
            }
        }

        /// <summary>
        /// to assign employee managers
        /// </summary>
        /// <param name="emp" the employee to get its manager></param>
        private void FillEmployeeManager(clsEmployee emp)
        {
            SelectedRecord = emp;


            if (emp.Manager == null && emp.ManagerId != -1)
            {
                emp.Manager = _employeeEntity.Get(emp.ManagerId);
                //MessageBox.Show("gotcha 1 : " + _employee.Manager.strEmployee());
            }
        }

        void IReLoadCtrl.ReintializeSubCtrl(IPersonValidation personValidation)
        {
            switch (_view)
            {
                case enView.Add:
                    ctrlDetailedPerson1.Reintialize(_view, null, _personEntity, personValidation, _countryEntity);
                    break;

                case enView.Show:
                    ctrlDetailedPerson1.Reintialize(_view, SelectedRecord.Person, _personEntity, null, _countryEntity);
                    break;

                case enView.Update:
                    ctrlDetailedPerson1.Reintialize(_view, SelectedRecord.Person, _personEntity, personValidation, _countryEntity);
                    break;
            }

            ctrlDetailedPerson1.Location = new Point(0, 59);
        }

        void ILoad.FillForm()
        {
            FillManagersComboBox();
            FillDepartmentsComboBox();
            FillData();
        }

        private void FillData()
        {
            if (_view == enView.Add)
                return;

            if (SelectedRecord == null)
            {
                MessageBox.Show("Employee object is not assigned to fill its data");
                return;
            }

            lblId.Text = SelectedRecord.Id.ToString();
            txtSalary.Text = SelectedRecord.Salary.ToString();

            if (_view != enView.Show)
            {
                cbDepartments.Text = SelectedRecord.Department.ToString();

                if (SelectedRecord.ManagerId == -1)
                {
                    cbManager.SelectedIndex = 0;
                    DisableShowManager();
                    return;
                }

                if (SelectedRecord.Manager != null)
                    cbManager.Text = SelectedRecord.Manager.strEmployee();
            }
        }

        private void FillManagersComboBox()
        {
            if (_view == enView.Show)
            {
                if (SelectedRecord.ManagerId == -1)
                    cbManager.Items.Add(" - no manager - ");

                else
                    cbManager.Items.Add(SelectedRecord.strEmployee());

                cbManager.SelectedIndex = 0;
                return;
            }

            List<clsEmployee> managers = _employeeEntity.LoadData();

            cbManager.Items.Add(" - no manager - ");
            foreach (clsEmployee manager in managers)
            {
                cbManager.Items.Add(manager.strEmployee());
            }
        }

        private void FillDepartmentsComboBox()
        {
            if (_view == enView.Show)
            {
                cbDepartments.Items.Add(SelectedRecord.Department.ToString());
                cbDepartments.SelectedIndex = 0;
                return;
            }

            for (short i = 1; i <= 8; i++)
            {
                cbDepartments.Items.Add((clsEmployee.enDepartments)(i)).ToString();
            }
        }


        public bool IsPersonDataChanged()
        {
            return ctrlDetailedPerson1._UpdateService.DataChanged;
        }
    }
}
