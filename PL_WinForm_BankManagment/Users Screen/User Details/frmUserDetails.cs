using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace PL_WinForm_BankManagment.Users_Screen
{
    public partial class frmUserDetails : Form
    {


        clsUser _SelectedUser = null;

        frmUsers _UserForm;

        List<CheckBox> _UserAccessibility = new List<CheckBox>();

        public frmUserDetails(clsUser user, frmUsers UserForm)
        {
            InitializeComponent();
            FillUserAccessibilityList();

            this._UserForm = UserForm;

            _SelectedUser = user;
            AssignUser();
            
            FillFormWithUserData();
        }

        
    }
}
