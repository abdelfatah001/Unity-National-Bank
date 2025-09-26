using Models;
using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using PL_WinForm.User_Controls.Details_Presenter.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Models.clsEmployee;

namespace PL_WinForm.User_Controls.Details_Presenter.Employee
{
    public class clsEmployeeUpdateService : clsUpdateService<clsEmployee>
    {

        private ComboBox _cbDepartments;
        private ComboBox _cbManager;

        private TextBox _txtSalary;

        private ctrlDetailedPerson _ctrlDetailedPerson1;



        public clsEmployeeUpdateService(clsEmployee employee, IEntity<clsEmployee> employeeEntity, ctrlDetailedPerson ctrlDetailedPerson, ComboBox cbManager, ComboBox cbDepartments, TextBox txtSalry) 
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
            _record.Salary = Convert.ToDouble(_txtSalary.Text);
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
            enDataUpdated PersonUpdating = enDataUpdated.NotChanged;

            enDataUpdated EmployeeUpdating = enDataUpdated.NotChanged;

            if (_ctrlDetailedPerson1._personService.IsDataChanged())
            {
                PersonUpdating = _ctrlDetailedPerson1._personService.Save();
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
}
