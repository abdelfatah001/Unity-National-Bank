using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Details_Presenter.User
{
    internal class clsAccessManager
    {
        private List<CheckBox> _AccessibilityList;

        private CheckBox _cbxAdmin;

        private Label _lblAccessCode;

        private int _UserAccessibility;

        public clsAccessManager(List<CheckBox> cbxAccessibility,CheckBox cbxAdmin , Label lblAccessCode, int userAccessibility)
        {
            _AccessibilityList = cbxAccessibility;
            _lblAccessCode = lblAccessCode;
            _cbxAdmin = cbxAdmin;
            _UserAccessibility = userAccessibility; 
        }

        private int fullAccess = 2047;

        private int AccessLabelValue = 0;

        private enum enIsAllCBXChecked { AllChecked, SemiChecked, NotingChecked };

        private enIsAllCBXChecked IsAllCBXChecked = enIsAllCBXChecked.NotingChecked;

        /// <summary>
        /// Display accessibility on UI
        /// </summary>
        public void FillAccessibilityCbx()
        {
            if (fullAccess == _UserAccessibility)
            {
                _cbxAdmin.Checked = true;
                return;
            }


            foreach (CheckBox cbx in _AccessibilityList)
            {
                int cbxTagValue = Convert.ToInt32(cbx.Tag);

                if ((cbxTagValue & _UserAccessibility) == cbxTagValue)
                    cbx.Checked = true;
            }

            IsAllCBXChecked = enIsAllCBXChecked.SemiChecked;

        }

        public void cbx_CheckChanged(object sender, EventArgs e)
        {
            CheckBox cbx = sender as CheckBox;

            if (cbx.Checked)
                AccessLabelValue += Convert.ToInt32(cbx.Tag);

            else
                AccessLabelValue -= Convert.ToInt32(cbx.Tag);


            _lblAccessCode.Text = AccessLabelValue.ToString();

            if (AccessLabelValue == fullAccess)
            {
                IsAllCBXChecked = enIsAllCBXChecked.AllChecked;
                _cbxAdmin.Checked = true;
            }

            else if (AccessLabelValue < fullAccess && IsAllCBXChecked == enIsAllCBXChecked.AllChecked) // if all checked while the accessibility is not all uncheck cbxAdmin
            {
                IsAllCBXChecked = enIsAllCBXChecked.SemiChecked;
                _cbxAdmin.Checked = false;
            }
        }

        public void cbxAdmin_CheckChanged(object sender, EventArgs e)
        {
            CheckBox Admincbx = sender as CheckBox;


            if (Admincbx.Checked)
            {
                if (IsAllCBXChecked == enIsAllCBXChecked.NotingChecked || IsAllCBXChecked == enIsAllCBXChecked.SemiChecked)
                {
                    _AccessibilityList.ForEach(cbx => cbx.Checked = true);
                    IsAllCBXChecked = enIsAllCBXChecked.AllChecked;
                }
            }

            else
            {
                if (IsAllCBXChecked == enIsAllCBXChecked.AllChecked)
                {
                    _AccessibilityList.ForEach(cbx => cbx.Checked = false);
                    IsAllCBXChecked = enIsAllCBXChecked.NotingChecked;
                }
            }
        }
    }
}
