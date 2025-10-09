using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PL_WinForm.User_Controls.Details_Presenter
{
    public partial class ctrlDetailedEmployee
    {

        private Stack<clsEmployee> _employees = new Stack<clsEmployee>();

        private void AssignManager()
        {
            if (SelectedRecord.Manager == null && SelectedRecord.ManagerId != -1)
            {
                SelectedRecord.Manager = _employeeEntity.Get(SelectedRecord.ManagerId);
                // MessageBox.Show("gotcha");
            } 
        }

        private void StorePreviousEmployee ()
        {
            _employees.Push(SelectedRecord);
        }

        private void ChangeStoredEmployee ()
        {
            SelectedRecord = SelectedRecord.Manager;
        }

        private void GoToManager ()
        {
            ShowBackIcon();
            DisableShowManager(); // if it has no manager

            AssignManager();

            StorePreviousEmployee();
            ChangeStoredEmployee();

            AssignManager(); // to assign manager of new wmployee will be shown cuz we will need its manager o show it in cbManager


            ((IReLoadCtrl)this).ReintializeSubCtrl();

            FillData();

            DisableSaveBtn();
            LockUpdate();
            ConvertConboBoxToReadOnly();
        }

        private void DeleteManager ()

        {
            _employees.Pop();
        }

        private void AssignEmployee()
        {
            SelectedRecord = _employees.Peek();
        }

        private void GoBackToEmployee()
        {
            AssignEmployee();
            DeleteManager();
            ((IReLoadCtrl)this).ReintializeSubCtrl();
            FillData();

            EnableShowManager();

            if (_employees.Count == 0)
            {
                DisappearBackIcon();
                DelockUpdate();
                EnableSaveBtn();
            }
        }



    }

}