using Models;
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
        public clsEmployee SelectedRecord { get;set; }
        
        public event EventHandler OnCancel;

        private IEntity<clsEmployee> _employeeEntity;

        private IInvisibleEntity<clsPerson> _personEntity;

        private IReadOnlyEntity<clsCountry> _countryEnity;

        public IUpdate UpdateService { get; set; }


        public ctrlDetailedEmployee()
        {
            InitializeComponent();
        }

        public void Reintailze (clsEmployee employee, IEntity<clsEmployee> employeeEntity, IInvisibleEntity<clsPerson> personEntity, IReadOnlyEntity<clsCountry> countryEnity, bool readOnly = false)
        {
            
            _employeeEntity = employeeEntity;

            FillEmployee(employee);

            _personEntity = personEntity;
            _countryEnity = countryEnity;

            ((IReloadPersonCtrl)this).ReintializeCtrl(readOnly);
            ((ILoad)this).FillForm();


            UpdateService = new clsEmployeeUpdateService(SelectedRecord, _employeeEntity, ctrlDetailedPerson1, cbManager, cbDepartments, txtSalary);

             DisappearBackIcon();

            if (readOnly)
                ReadOnlyMode();
        }

        private void FillEmployee (clsEmployee emp) // to assign employee managers
        {
            SelectedRecord = emp;


            if (emp.Manager == null && emp.ManagerId != -1)
            {
                emp.Manager = _employeeEntity.Get(emp.ManagerId);
                 //MessageBox.Show("gotcha 1 : " + _employee.Manager.strEmployee());
            }
        }

        void IReloadPersonCtrl.ReintializeCtrl(bool readOnly)
        {
            ctrlDetailedPerson1.Reintialize(SelectedRecord.Person, _personEntity, _countryEnity, readOnly);

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
            if (SelectedRecord == null)
                return;

            lblId.Text = SelectedRecord.Id.ToString();
            txtSalary.Text = SelectedRecord.Salary.ToString();
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

        private void FillManagersComboBox()
        {
            List<clsEmployee> managers = _employeeEntity.LoadData();

            cbManager.Items.Add(" - no manager - ");
            foreach (clsEmployee manager in managers)
            {
                cbManager.Items.Add(manager.strEmployee());
            }
        }

        private void FillDepartmentsComboBox()
        {
            for (short i = 1; i <= 8; i++)
            {
                cbDepartments.Items.Add((clsEmployee.enDepartments) (i)).ToString();
            }
        }


        public bool IsPersonDataChanged()
        {
            return ctrlDetailedPerson1._personService.DataChanged;
        }

    }
}
