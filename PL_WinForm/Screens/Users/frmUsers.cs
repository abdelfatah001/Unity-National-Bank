using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PL_WinForm.User_Controls;
using PL_WinForm.Data_Gathering;

using BLL_BankManagment;
using PL_WinForm.Screens.Users;

namespace PL_WinForm.Users
{
    public partial class frmUsers : Form, IUserScreen
    {

        public bool IsLoaded { get; set; } = false;

        public frmUsers()
        {
        }

        public void LoadScreen()
        {
            InitializeComponent();
            
            ((IUserScreen)this).ReintializeCtrl();

            ctrlUsersManager1.OnDataRowClick += CtrlUsersManager1_OnDataRowClick;

            ctrlUsersManager1.ResizeDGV(450);

            ShowScreen();
        }

        void IRecordsScreen<clsUser>.ReintializeCtrl()
        { 
            ctrlUsersManager1 = new ctrlUsersManager(new clsUserEntity(new clsUserManager(new clsUserCache(), new clsUserRepo(new clsUsersRepository(new clsEmployeesRepository(new clsPersonRepository()))))));
            ctrlUsersManager1.Dock = DockStyle.Fill;

            this.Controls.Clear();  
            this.Controls.Add(ctrlUsersManager1);
        }

        

        public void ShowScreen()
        {
            List<clsUser> users = ctrlUsersManager1.LoadEntityData();
            List<string> columns = new List<string>
            { "Id", "User Name", "Password", "AccessCode"};
            ctrlUsersManager1.CreateTableHeader(columns);

            foreach (clsUser user in users)
            {
                List<string> row = new List<string>
                { user.Id.ToString(), user.UserName, user.Password, user.AccessCode.ToString() };

                ctrlUsersManager1.AddRow(row, user);
            }
        }
        private void CtrlUsersManager1_OnDataRowClick(object sender, RecordEvevtsArgs<clsUser> e)
        {
            if (frmDetailedUsers.IsOpened)
                return;

            frmDetailedUsers frm = new frmDetailedUsers(e.obj, (short)e.RowIndex);
            frm.DataBack += Frm_DataBack;
            frm.Show();
        }

        private void Frm_DataBack(object sender, short index, clsUser user)
        {
            ReflectUpdateOnUI(index, user);
        }

        public void ReflectUpdateOnUI (short index, clsUser user)
        {
            List<string> row = new List<string>
            { user.Id.ToString(), user.UserName, user.Password, user.AccessCode.ToString() };

            ctrlUsersManager1.UpdateRow(index, row, user);

        }
    }
}
