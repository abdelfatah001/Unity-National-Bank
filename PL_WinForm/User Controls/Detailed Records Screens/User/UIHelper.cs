using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.User
{
    public partial class ctrlDetailedUsers
    {

        /// <summary>
        /// sow control in reduced view
        /// </summary>
        private void ShowReducedView()
        {
            DisapearEmployeeCtrl();
            CloseButtonsUp();
            MinimizeCtrl();
        }

        private void ShowEmployeeData()
        {
            MaximizeCtrl();
            CloseButtonsDown();
            ShowEmployeeCtrl();

            btnShowEmployee.Enabled = false;
        }

        /// <summary>
        /// used in reduced view to make save and cancel button at the end of the control
        /// </summary>
        private void CloseButtonsUp()
        {
            btnSave.Location = new Point(334, 418);
            btnCancel.Location = new Point(218, 418);
        }

        /// <summary>
        /// used in Employee shown view to make save and cancel button at the end of the control
        /// </summary>
        private void CloseButtonsDown()
        {
            btnSave.Location = new Point(329, 700);
           btnCancel.Location = new Point(223, 700);
        }

        /// <summary>
        /// Disapear employee ctrl from control
        /// </summary>
        private void DisapearEmployeeCtrl ()
        {
            ctrlDetailedEmployee1.Visible = false;
        }

        /// <summary>
        /// show emplyee data
        /// </summary>
        private void ShowEmployeeCtrl ()
        {
            ctrlDetailedEmployee1.Visible = true;
            ctrlDetailedEmployee1.Location = new Point(0, 355);
            ctrlDetailedEmployee1.Size = new Size(643, 295);

        }

        /// <summary>
        /// Minimize control dimentions
        /// </summary>
        private void MinimizeCtrl ()
        {
            this.Size = this.MinimumSize;
        }

        /// <summary>
        /// Maximize control dimentions
        /// </summary>
        private void MaximizeCtrl ()
        {
            this.Size = new Size(643, 730);
        }

        private void DisappearlblClientId()
        {
            lblEmployeeId.Visible = false;
        }

        private void DisappearBtnShowEmployee()
        {
            btnShowEmployee.Visible = false;
        }

        private void CustomizeEmployeeIdDataShow()
        {
            lbl_EmployeeId.Location = new Point(170, 365);
            cbEmployees.Location = new Point(320, 365);
        }

        private void ChangebtnSaveToAdd()
        {
            btnSave.Text = "Add";
        }

        private void AddView()
        {
            DisappearlblClientId();
            DisappearBtnShowEmployee();
            CustomizeEmployeeIdDataShow();
            ChangebtnSaveToAdd();
        }
    }
}
