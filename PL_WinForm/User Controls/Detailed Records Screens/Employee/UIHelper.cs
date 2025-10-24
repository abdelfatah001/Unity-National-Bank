using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PL_WinForm.User_Controls.Details_Presenter
{
    public partial class ctrlDetailedEmployee
    {
        private void LockUpdate()
        {
            ctrlDetailedPerson1.LockUpdate();
            txtSalary.ReadOnly = true;
        }


        private void ConvertConboBoxToReadOnly ()
        {
            cbDepartments.Enabled = false;
            cbManager.Enabled = false;
            ctrlDetailedPerson1.ConvertComboBoxToReadOnly();
        }

        private void DelockUpdate()
        {
            ctrlDetailedPerson1.DelockUpdate();

            txtSalary.ReadOnly = false;
            cbDepartments.Enabled = true;
            cbManager.Enabled = true;
        }

        private void DisappearBackIcon()
        {
           pbBack.Visible = false;
        }

        private void ShowBackIcon()
        {
            pbBack.Visible = true;
        } 

        private void DisableShowManager ()
        {
            if (SelectedRecord.ManagerId == -1)
                btnShowManager.Enabled = false; 
        }

        private void EnableShowManager()
        {
                btnShowManager.Enabled = true;
        }

        private void DisappearEmployeeId()
        {
            lblId.Visible = false;
            lblEmployeeId.Visible = false;  
        }

        private void pbBack_MouseEnter(object sender, EventArgs e)
        {
            pbBack.Image = Properties.Resources.back;
        }

        private void pbBack_MouseLeave(object sender, EventArgs e)
        {
            pbBack.Image = Properties.Resources.backk;
        }


        private  void DisableSaveBtn ()
        {
            btnSave.Enabled = false;
        }
        private void EnableSaveBtn()
        {
            btnSave.Enabled = true;
        }
           
        private void DisapppearCloseButtons()
        {
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        private void DisappearShowManagerBtn()
        {
            btnShowManager.Visible = false;

            lblManagerId.Location = new System.Drawing.Point(23, 267);
            cbManager.Location = new System.Drawing.Point(155, 267);
        }

        private void lblEmployeeIdToAddEmployee ()
        {
            lblId.Visible = false;
            lblEmployeeId.Size = new System.Drawing.Size(175, 23);
            lblEmployeeId.Text = "Add Employee";
            lblEmployeeId.Location = new System.Drawing.Point(250, 15);
        }

        private void AddMode()
        {
            DisappearShowManagerBtn();
            lblEmployeeIdToAddEmployee();
        }

        private void ReadOnlyMode()
        {
            LockUpdate();
            DisappearEmployeeId();
            DisapppearCloseButtons();
            DisappearShowManagerBtn();
        }

    }
}