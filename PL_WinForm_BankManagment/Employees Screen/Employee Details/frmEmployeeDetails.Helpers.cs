using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment.Employees_Screen
{
    partial class frmEmployeeDetails
    {

        private void ShowBackPictureBox ()
        {
            pcBack.Visible = true;
        }

        private void DisappearBackPictureBox()
        {
            pcBack.Visible = false;
        }


        private void EnableSaveButton()
        {
            btnSave.Enabled = true;
        }


        private void DisableSaveButton()
        {
            btnSave.Enabled = false;
        }

        private void DisableEmployeeUpdate ()
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtSalary.ReadOnly = true;

            cbxCountry.DropDownStyle = ComboBoxStyle.Simple;
            cbxDepartment.DropDownStyle = ComboBoxStyle.Simple;
            cbxManager.DropDownStyle = ComboBoxStyle.Simple;
        }

        private void EnableEmployeeUpdate()
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtSalary.ReadOnly = false;

            cbxCountry.DropDownStyle = ComboBoxStyle.DropDown;
            cbxDepartment.DropDownStyle = ComboBoxStyle.DropDown;
            cbxManager.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void DisableShowManagerButton()
        {
            btnShowManager.Enabled = false;
        }

        private void EnableShowManagerButton()
        {
            btnShowManager.Enabled = true;
        }

        private void OpenShowManagerMode ()
        {
            DisableEmployeeUpdate();
            DisableSaveButton();
            ShowBackPictureBox();
        }
        

        private void CloseShowManagerMode ()
        {
            EnableSaveButton();
            EnableEmployeeUpdate();
            DisappearBackPictureBox();
        }


        private void ReadOnlyMode ()
        {
            DisableEmployeeUpdate();
            DisableSaveButton();
            DisableShowManagerButton();
            
            ShowBackPictureBox();
        }

        private void UpdateMode ()
        {
            DisappearBackPictureBox();

            if (_SelectedEmployee.ManagerId == -1)
                DisableShowManagerButton();
        }

    }
}
