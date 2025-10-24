using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using PL_WinForm.User_Controls.Details_Presenter.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Models.clsEmployee;

namespace PL_WinForm.User_Controls.Details_Presenter.Employee
{
    public class clsUpdateEmployeeService : clsUpdateService<clsEmployee>
    {

        private ComboBox _cbDepartments;
        private ComboBox _cbManager;

        private TextBox _txtSalary;

        private ctrlDetailedPerson _ctrlDetailedPerson1;

        bool IsValidInput;



        public clsUpdateEmployeeService(IEntity<clsEmployee> employeeEntity, clsEmployee employee, ctrlDetailedPerson ctrlDetailedPerson, ComboBox cbManager, ComboBox cbDepartments, TextBox txtSalry) 
            : base (employeeEntity, employee)
        {
            _cbDepartments = cbDepartments;
            _cbManager = cbManager;
            _txtSalary = txtSalry;
            _ctrlDetailedPerson1 = ctrlDetailedPerson;

        }


        public override bool IsDataChanged()
        {

            bool EmpManagerChanged = false;

            if (_record.ManagerId != -1)
                EmpManagerChanged = (_cbManager.SelectedIndex == 0 && _record.ManagerId != -1 ||
                    _cbManager.Text != _record.Manager.strEmployee());

            else
                EmpManagerChanged = (_cbManager.SelectedIndex != 0);

            DataChanged = (
                Convert.ToDouble(_txtSalary.Text) != _record.Salary ||
                _cbDepartments.Text != _record.Department.ToString() ||
                EmpManagerChanged);

            return DataChanged;
        }

        private void SetNullEmpManager()
        {
            _record.ManagerId = -1;
            _record.Manager = null;
        }

        protected override void UpdateObject()
        {
            double salary;
            if (!double.TryParse(_txtSalary.Text, out salary))
                IsValidInput = false;

            else
            {
                IsValidInput = true;
                _record.Salary = salary;
            }

            _record.Department = (clsEmployee.enDepartments)_cbDepartments.SelectedIndex + 1;

            if (_cbManager.SelectedIndex != 0)
            {

                short ManagerId = Convert.ToInt16((_cbManager.Text.Split('-')[0]).Trim());

                if (ManagerId == _record.Id)
                    SetNullEmpManager();

                else
                {
                    _record.ManagerId = ManagerId;
                    _record.Manager = _Entity.Get(ManagerId);
                }
            }

            else
                SetNullEmpManager();
        }


        public override void SaveUpdates()
        {
            if (!IsValidInput) 
            {
                MessageBox.Show("Operation failed : Invalid salary");
                return;
            }

                

            enDataUpdated PersonUpdating = enDataUpdated.NotChanged;

            enDataUpdated EmployeeUpdating = enDataUpdated.NotChanged;

            if (_ctrlDetailedPerson1._UpdateService.IsDataChanged())
            {
                PersonUpdating = _ctrlDetailedPerson1._UpdateService.Save();
            }
            if (IsDataChanged())
            {
                EmployeeUpdating = ((IUpdate)this).Save();
            }


            if (PersonUpdating == enDataUpdated.NotChanged && EmployeeUpdating == enDataUpdated.NotChanged)
                return;

            else
            {
                if (PersonUpdating == enDataUpdated.NotSaved)
                    MessageBox.Show("Person update failed");

                if (EmployeeUpdating == enDataUpdated.NotSaved)
                    MessageBox.Show("Employee update failed");

                if (PersonUpdating == enDataUpdated.Saved || EmployeeUpdating == enDataUpdated.Saved)
                    MessageBox.Show("Employee updated successfully");
            }
        }


    }

    public class clsAddEmployeeService : clsAddService<clsEmployee>
    {

        private ComboBox _cbDepartments;

        private ComboBox _cbManager;

        private TextBox _txtSalary;

        private ctrlDetailedPerson _ctrlDetailedPerson1;

        public clsAddEmployeeService (IEntity<clsEmployee> employeeEntity, clsEmployee employee, ctrlDetailedPerson ctrlDetailedPerson, ComboBox cbManager, ComboBox cbDepartments, TextBox txtSalry)
            : base(employeeEntity, ref employee)
        {
            _cbDepartments = cbDepartments;
            _cbManager = cbManager; 
            _txtSalary = txtSalry;
            _ctrlDetailedPerson1 = ctrlDetailedPerson;
        }

        protected override void FillObject()
        {
            if (_cbDepartments.Text == "" || _cbManager.Text == "" || _txtSalary.Text == "")
            {
                MessageBox.Show("Nothing to add");
                CancelOperation();
                return;
            }

            operation = enAddingOprtn.Add;

            _recordToAdd = new clsEmployee();

            clsEmployee Manager = new clsEmployee();
            if (_cbManager.SelectedIndex != 0)
            {

                short ManagerId = Convert.ToInt16((_cbManager.Text.Split('-')[0]).Trim());

                if (ManagerId == _recordToAdd.Id)
                    Manager = null;

                else
                {
                    Manager = _entity.Get(ManagerId);
                }
            }

            else
                Manager = null;

            double salary;

            if (!double.TryParse(_txtSalary.Text, out salary))
            {
                MessageBox.Show("Operation failed : Invalid salary input");
                CancelOperation();
                return;
            }

            _recordToAdd.Update(salary,
                (enDepartments)(_cbDepartments.SelectedIndex + 1), null, Manager);
            
        }


        public override void SaveUpdates()
        {
            if (operation == enAddingOprtn.Canceled)
                return;

            clsPerson person = _ctrlDetailedPerson1._AddService.AddPerson();

            if (person == null)
            {
                MessageBox.Show("failed to add person");
                return;
            }

            _recordToAdd.Person = person;

            enAddingOprtn processStatus = ((ISave<enAddingOprtn>)this).Save();

            if (processStatus == enAddingOprtn.Canceled)
                return;

            if (processStatus == enAddingOprtn.Add)
                MessageBox.Show("employee added successfully");

            else
                MessageBox.Show("employee adding failed");

        }

        private void CancelOperation ()
        {
            operation = enAddingOprtn.Canceled;
        }


    }

}
