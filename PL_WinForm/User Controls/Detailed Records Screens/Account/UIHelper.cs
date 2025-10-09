using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.Account
{
    public partial class ctrlDetailedAccounts
    {
      

      /// <summary>
      /// sow control in reduced view
      /// </summary>
        private void ShowReducedView()
        {
            DisapearClientCtrl();
            CloseButtonsUp();
            MinimizeCtrl();

        }

        private void ShowClientData()
        {
            MaximizeCtrl();
            CloseButtonsDown();
            ShowClientCtrl();

        }

        /// <summary>
        /// used in reduced view to make save and cancel button at the end of the control
        /// </summary>
        private void CloseButtonsUp()
        {
            btnSave.Location = new Point(338, 288);
            btnCancel.Location = new Point(242, 288);
        }

        /// <summary>
        /// used in Employee shown view to make save and cancel button at the end of the control
        /// </summary>
        private void CloseButtonsDown()
        {
            btnSave.Location = new Point(321, 495);
            btnCancel.Location = new Point(224, 495);
        }

        /// <summary>
        /// Disapear employee ctrl from control
        /// </summary>
        private void DisapearClientCtrl()
        {
            ctrlDetailedClient1.Visible = false;
        }

        /// <summary>
        /// show emplyee data
        /// </summary>
        private void ShowClientCtrl()
        {
            ctrlDetailedClient1.Visible = true;
            ctrlDetailedClient1.Location = new Point(0, 223);
            ctrlDetailedClient1.Size = new Size(633, 245);

        }

        /// <summary>
        /// Minimize control dimentions
        /// </summary>
        private void MinimizeCtrl()
        {
            this.Size = this.MinimumSize;
        }

        /// <summary>
        /// Maximize control dimentions
        /// </summary>
        private void MaximizeCtrl()
        {
            this.Size = new Size(643, 530);
        }

        /// <summary>
        /// to lock currency combobox
        /// </summary>
        private void ReadOnlyCurrency()
        {
            cbCurrency.Enabled = false;
        }


        private void DisappearlblClientId ()
        {
            lblClientId.Visible = false;
        }

        private void DisappearBtnShowClient ()
        {
            btnShowClient.Visible = false;
        }

        private void CustomizeClientIdDataShow ()
        {
            lbl_ClientId.Location = new Point(170, 247);
            cbClients.Location = new Point(320, 243);
        }

        private void ChangebtnSaveToAdd ()
        {
            btnSave.Text = "Add";
        }

        private void AddView ()
        {
            DisappearlblClientId();
            DisappearBtnShowClient();
            CustomizeClientIdDataShow();
            ChangebtnSaveToAdd();
        }

    }
}
