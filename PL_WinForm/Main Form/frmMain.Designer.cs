using PL_WinForm;
using PL_WinForm.Accounts;
using PL_WinForm.Clients;
using PL_WinForm.Employees;
using PL_WinForm.Home;
using PL_WinForm.Users;

namespace PL.MainForm
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMainScreen = new System.Windows.Forms.Panel();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.pbusername = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pbSideBarDrawer = new System.Windows.Forms.PictureBox();
            this.pnlLogout = new System.Windows.Forms.Panel();
            this.pbLogout = new System.Windows.Forms.PictureBox();
            this.lblLogout = new System.Windows.Forms.Label();
            this.pnlDateTime = new System.Windows.Forms.Panel();
            this.lblMinute = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.flpList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.lblHome = new System.Windows.Forms.Label();
            this.pnlAccounts = new System.Windows.Forms.Panel();
            this.pbAccounts = new System.Windows.Forms.PictureBox();
            this.lblAccounts = new System.Windows.Forms.Label();
            this.pnlClients = new System.Windows.Forms.Panel();
            this.pbClients = new System.Windows.Forms.PictureBox();
            this.lblClients = new System.Windows.Forms.Label();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.pbUsers = new System.Windows.Forms.PictureBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.pnlEmployees = new System.Windows.Forms.Panel();
            this.pbEmployees = new System.Windows.Forms.PictureBox();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.pnlTransactions = new System.Windows.Forms.Panel();
            this.pbTransactions = new System.Windows.Forms.PictureBox();
            this.lblTransactions = new System.Windows.Forms.Label();
            this.pnlRegisterations = new System.Windows.Forms.Panel();
            this.pbRegisterations = new System.Windows.Forms.PictureBox();
            this.lblRegisterations = new System.Windows.Forms.Label();
            this.pnlCurrencies = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblCurrencies = new System.Windows.Forms.Label();
            this.pnlSideBar.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbusername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSideBarDrawer)).BeginInit();
            this.pnlLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
            this.pnlDateTime.SuspendLayout();
            this.flpList.SuspendLayout();
            this.pnlHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            this.pnlAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).BeginInit();
            this.pnlClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClients)).BeginInit();
            this.pnlUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsers)).BeginInit();
            this.pnlEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployees)).BeginInit();
            this.pnlTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransactions)).BeginInit();
            this.pnlRegisterations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRegisterations)).BeginInit();
            this.pnlCurrencies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainScreen.BackgroundImage = global::PL_WinForm.Properties.Resources.UNBwithoutbg;
            this.pnlMainScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMainScreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMainScreen.Location = new System.Drawing.Point(188, 0);
            this.pnlMainScreen.MaximumSize = new System.Drawing.Size(820, 658);
            this.pnlMainScreen.MinimumSize = new System.Drawing.Size(689, 658);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(689, 658);
            this.pnlMainScreen.TabIndex = 3;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.CadetBlue;
            this.pnlSideBar.Controls.Add(this.pnlUsername);
            this.pnlSideBar.Controls.Add(this.pbSideBarDrawer);
            this.pnlSideBar.Controls.Add(this.pnlLogout);
            this.pnlSideBar.Controls.Add(this.pnlDateTime);
            this.pnlSideBar.Controls.Add(this.flpList);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.MaximumSize = new System.Drawing.Size(187, 658);
            this.pnlSideBar.MinimumSize = new System.Drawing.Size(53, 658);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(187, 658);
            this.pnlSideBar.TabIndex = 2;
            // 
            // pnlUsername
            // 
            this.pnlUsername.Controls.Add(this.pbusername);
            this.pnlUsername.Controls.Add(this.lblUsername);
            this.pnlUsername.Location = new System.Drawing.Point(45, 3);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(106, 90);
            this.pnlUsername.TabIndex = 2;
            // 
            // pbusername
            // 
            this.pbusername.Image = global::PL_WinForm.Properties.Resources.user_128;
            this.pbusername.Location = new System.Drawing.Point(21, 0);
            this.pbusername.Name = "pbusername";
            this.pbusername.Size = new System.Drawing.Size(54, 57);
            this.pbusername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbusername.TabIndex = 2;
            this.pbusername.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(-4, 66);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(106, 26);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSideBarDrawer
            // 
            this.pbSideBarDrawer.Image = global::PL_WinForm.Properties.Resources.result4;
            this.pbSideBarDrawer.Location = new System.Drawing.Point(3, 6);
            this.pbSideBarDrawer.Name = "pbSideBarDrawer";
            this.pbSideBarDrawer.Size = new System.Drawing.Size(42, 35);
            this.pbSideBarDrawer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSideBarDrawer.TabIndex = 2;
            this.pbSideBarDrawer.TabStop = false;
            this.pbSideBarDrawer.Click += new System.EventHandler(this.SideBarDrawer);
            this.pbSideBarDrawer.MouseEnter += new System.EventHandler(this.pbSideBarDrawer_MouseEnter);
            this.pbSideBarDrawer.MouseLeave += new System.EventHandler(this.pbSideBarDrawer_MouseLeave);
            // 
            // pnlLogout
            // 
            this.pnlLogout.Controls.Add(this.pbLogout);
            this.pnlLogout.Controls.Add(this.lblLogout);
            this.pnlLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLogout.Location = new System.Drawing.Point(0, 614);
            this.pnlLogout.Name = "pnlLogout";
            this.pnlLogout.Size = new System.Drawing.Size(187, 44);
            this.pnlLogout.TabIndex = 6;
            // 
            // pbLogout
            // 
            this.pbLogout.BackColor = System.Drawing.Color.Transparent;
            this.pbLogout.Image = global::PL_WinForm.Properties.Resources.download_removebg_preview;
            this.pbLogout.Location = new System.Drawing.Point(1, 0);
            this.pbLogout.Name = "pbLogout";
            this.pbLogout.Size = new System.Drawing.Size(48, 41);
            this.pbLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogout.TabIndex = 1;
            this.pbLogout.TabStop = false;
            this.pbLogout.Click += new System.EventHandler(this.OnLogOutClick);
            this.pbLogout.MouseEnter += new System.EventHandler(this.OnLogoutPanel_MouseEnter);
            this.pbLogout.MouseLeave += new System.EventHandler(this.OnLogoutPanel_MouseLeave);
            // 
            // lblLogout
            // 
            this.lblLogout.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.LightGray;
            this.lblLogout.Location = new System.Drawing.Point(50, 4);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(134, 37);
            this.lblLogout.TabIndex = 0;
            this.lblLogout.Text = "Logout";
            this.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogout.Click += new System.EventHandler(this.OnLogOutClick);
            this.lblLogout.MouseEnter += new System.EventHandler(this.OnLogoutPanel_MouseEnter);
            this.lblLogout.MouseLeave += new System.EventHandler(this.OnLogoutPanel_MouseLeave);
            // 
            // pnlDateTime
            // 
            this.pnlDateTime.Controls.Add(this.lblMinute);
            this.pnlDateTime.Controls.Add(this.lblHour);
            this.pnlDateTime.Controls.Add(this.lblDate);
            this.pnlDateTime.Controls.Add(this.lblTime);
            this.pnlDateTime.Location = new System.Drawing.Point(4, 95);
            this.pnlDateTime.Name = "pnlDateTime";
            this.pnlDateTime.Size = new System.Drawing.Size(180, 86);
            this.pnlDateTime.TabIndex = 1;
            // 
            // lblMinute
            // 
            this.lblMinute.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMinute.Location = new System.Drawing.Point(-9, 37);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(50, 42);
            this.lblMinute.TabIndex = 5;
            this.lblMinute.Text = "mm";
            this.lblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHour
            // 
            this.lblHour.Font = new System.Drawing.Font("Kristen ITC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHour.Location = new System.Drawing.Point(-6, 4);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(57, 43);
            this.lblHour.TabIndex = 4;
            this.lblHour.Text = "HH";
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDate.Location = new System.Drawing.Point(24, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(140, 31);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime.Location = new System.Drawing.Point(24, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(140, 31);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpList
            // 
            this.flpList.Controls.Add(this.pnlHome);
            this.flpList.Controls.Add(this.pnlAccounts);
            this.flpList.Controls.Add(this.pnlClients);
            this.flpList.Controls.Add(this.pnlUsers);
            this.flpList.Controls.Add(this.pnlEmployees);
            this.flpList.Controls.Add(this.pnlTransactions);
            this.flpList.Controls.Add(this.pnlRegisterations);
            this.flpList.Controls.Add(this.pnlCurrencies);
            this.flpList.Location = new System.Drawing.Point(0, 187);
            this.flpList.Name = "flpList";
            this.flpList.Size = new System.Drawing.Size(187, 406);
            this.flpList.TabIndex = 0;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlHome.Controls.Add(this.pbHome);
            this.pnlHome.Controls.Add(this.lblHome);
            this.pnlHome.Location = new System.Drawing.Point(3, 3);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(184, 44);
            this.pnlHome.TabIndex = 6;
            // 
            // pbHome
            // 
            this.pbHome.Image = global::PL_WinForm.Properties.Resources.Home;
            this.pbHome.Location = new System.Drawing.Point(1, 0);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(45, 41);
            this.pbHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHome.TabIndex = 1;
            this.pbHome.TabStop = false;
            this.pbHome.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pbHome.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pbHome.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblHome
            // 
            this.lblHome.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHome.ForeColor = System.Drawing.Color.LightGray;
            this.lblHome.Location = new System.Drawing.Point(44, 4);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(140, 37);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = "Home";
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHome.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblHome.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblHome.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // pnlAccounts
            // 
            this.pnlAccounts.Controls.Add(this.pbAccounts);
            this.pnlAccounts.Controls.Add(this.lblAccounts);
            this.pnlAccounts.Location = new System.Drawing.Point(3, 53);
            this.pnlAccounts.Name = "pnlAccounts";
            this.pnlAccounts.Size = new System.Drawing.Size(184, 44);
            this.pnlAccounts.TabIndex = 4;
            // 
            // pbAccounts
            // 
            this.pbAccounts.Image = global::PL_WinForm.Properties.Resources.aAccount;
            this.pbAccounts.Location = new System.Drawing.Point(1, 0);
            this.pbAccounts.Name = "pbAccounts";
            this.pbAccounts.Size = new System.Drawing.Size(45, 41);
            this.pbAccounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAccounts.TabIndex = 1;
            this.pbAccounts.TabStop = false;
            this.pbAccounts.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pbAccounts.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pbAccounts.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblAccounts
            // 
            this.lblAccounts.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAccounts.ForeColor = System.Drawing.Color.LightGray;
            this.lblAccounts.Location = new System.Drawing.Point(44, 4);
            this.lblAccounts.Name = "lblAccounts";
            this.lblAccounts.Size = new System.Drawing.Size(140, 37);
            this.lblAccounts.TabIndex = 0;
            this.lblAccounts.Text = "Accounts";
            this.lblAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAccounts.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblAccounts.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblAccounts.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // pnlClients
            // 
            this.pnlClients.Controls.Add(this.pbClients);
            this.pnlClients.Controls.Add(this.lblClients);
            this.pnlClients.Location = new System.Drawing.Point(3, 103);
            this.pnlClients.Name = "pnlClients";
            this.pnlClients.Size = new System.Drawing.Size(184, 44);
            this.pnlClients.TabIndex = 2;
            // 
            // pbClients
            // 
            this.pbClients.Image = global::PL_WinForm.Properties.Resources.public_relation1;
            this.pbClients.Location = new System.Drawing.Point(1, 0);
            this.pbClients.Name = "pbClients";
            this.pbClients.Size = new System.Drawing.Size(45, 41);
            this.pbClients.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClients.TabIndex = 1;
            this.pbClients.TabStop = false;
            this.pbClients.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pbClients.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pbClients.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblClients
            // 
            this.lblClients.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblClients.ForeColor = System.Drawing.Color.LightGray;
            this.lblClients.Location = new System.Drawing.Point(44, 4);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(140, 37);
            this.lblClients.TabIndex = 0;
            this.lblClients.Text = "Clients";
            this.lblClients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClients.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblClients.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblClients.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // pnlUsers
            // 
            this.pnlUsers.Controls.Add(this.pbUsers);
            this.pnlUsers.Controls.Add(this.lblUsers);
            this.pnlUsers.Location = new System.Drawing.Point(3, 153);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(184, 44);
            this.pnlUsers.TabIndex = 0;
            // 
            // pbUsers
            // 
            this.pbUsers.Image = global::PL_WinForm.Properties.Resources.user_128;
            this.pbUsers.Location = new System.Drawing.Point(1, 0);
            this.pbUsers.Name = "pbUsers";
            this.pbUsers.Size = new System.Drawing.Size(45, 41);
            this.pbUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsers.TabIndex = 1;
            this.pbUsers.TabStop = false;
            this.pbUsers.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pbUsers.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pbUsers.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblUsers
            // 
            this.lblUsers.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUsers.ForeColor = System.Drawing.Color.LightGray;
            this.lblUsers.Location = new System.Drawing.Point(44, 4);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(140, 37);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "Users";
            this.lblUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsers.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblUsers.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblUsers.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.Controls.Add(this.pbEmployees);
            this.pnlEmployees.Controls.Add(this.lblEmployees);
            this.pnlEmployees.Location = new System.Drawing.Point(3, 203);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(184, 44);
            this.pnlEmployees.TabIndex = 2;
            // 
            // pbEmployees
            // 
            this.pbEmployees.Image = global::PL_WinForm.Properties.Resources.result;
            this.pbEmployees.Location = new System.Drawing.Point(1, 0);
            this.pbEmployees.Name = "pbEmployees";
            this.pbEmployees.Size = new System.Drawing.Size(45, 41);
            this.pbEmployees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmployees.TabIndex = 1;
            this.pbEmployees.TabStop = false;
            this.pbEmployees.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pbEmployees.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pbEmployees.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblEmployees
            // 
            this.lblEmployees.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblEmployees.ForeColor = System.Drawing.Color.LightGray;
            this.lblEmployees.Location = new System.Drawing.Point(44, 4);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(140, 37);
            this.lblEmployees.TabIndex = 0;
            this.lblEmployees.Text = "Employees";
            this.lblEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmployees.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblEmployees.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblEmployees.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.Controls.Add(this.pbTransactions);
            this.pnlTransactions.Controls.Add(this.lblTransactions);
            this.pnlTransactions.Location = new System.Drawing.Point(3, 253);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Size = new System.Drawing.Size(184, 44);
            this.pnlTransactions.TabIndex = 3;
            // 
            // pbTransactions
            // 
            this.pbTransactions.Image = global::PL_WinForm.Properties.Resources.transaction_line_icon_png_234015_removebg_preview;
            this.pbTransactions.Location = new System.Drawing.Point(1, 0);
            this.pbTransactions.Name = "pbTransactions";
            this.pbTransactions.Size = new System.Drawing.Size(45, 41);
            this.pbTransactions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTransactions.TabIndex = 1;
            this.pbTransactions.TabStop = false;
            this.pbTransactions.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pbTransactions.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pbTransactions.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblTransactions
            // 
            this.lblTransactions.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTransactions.ForeColor = System.Drawing.Color.LightGray;
            this.lblTransactions.Location = new System.Drawing.Point(44, 4);
            this.lblTransactions.Name = "lblTransactions";
            this.lblTransactions.Size = new System.Drawing.Size(140, 37);
            this.lblTransactions.TabIndex = 0;
            this.lblTransactions.Text = "Transactions";
            this.lblTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTransactions.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblTransactions.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblTransactions.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // pnlRegisterations
            // 
            this.pnlRegisterations.Controls.Add(this.pbRegisterations);
            this.pnlRegisterations.Controls.Add(this.lblRegisterations);
            this.pnlRegisterations.Location = new System.Drawing.Point(3, 303);
            this.pnlRegisterations.Name = "pnlRegisterations";
            this.pnlRegisterations.Size = new System.Drawing.Size(184, 44);
            this.pnlRegisterations.TabIndex = 4;
            // 
            // pbRegisterations
            // 
            this.pbRegisterations.Image = global::PL_WinForm.Properties.Resources.images_removebg_preview;
            this.pbRegisterations.Location = new System.Drawing.Point(1, 0);
            this.pbRegisterations.Name = "pbRegisterations";
            this.pbRegisterations.Size = new System.Drawing.Size(45, 41);
            this.pbRegisterations.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRegisterations.TabIndex = 1;
            this.pbRegisterations.TabStop = false;
            this.pbRegisterations.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pbRegisterations.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pbRegisterations.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblRegisterations
            // 
            this.lblRegisterations.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblRegisterations.ForeColor = System.Drawing.Color.LightGray;
            this.lblRegisterations.Location = new System.Drawing.Point(44, 4);
            this.lblRegisterations.Name = "lblRegisterations";
            this.lblRegisterations.Size = new System.Drawing.Size(140, 37);
            this.lblRegisterations.TabIndex = 0;
            this.lblRegisterations.Text = "Registerations";
            this.lblRegisterations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRegisterations.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblRegisterations.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblRegisterations.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // pnlCurrencies
            // 
            this.pnlCurrencies.Controls.Add(this.pictureBox5);
            this.pnlCurrencies.Controls.Add(this.lblCurrencies);
            this.pnlCurrencies.Location = new System.Drawing.Point(3, 353);
            this.pnlCurrencies.Name = "pnlCurrencies";
            this.pnlCurrencies.Size = new System.Drawing.Size(184, 44);
            this.pnlCurrencies.TabIndex = 5;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PL_WinForm.Properties.Resources.currency;
            this.pictureBox5.Location = new System.Drawing.Point(1, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(45, 41);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.OnSideBarPictureBoxClick);
            this.pictureBox5.MouseEnter += new System.EventHandler(this.OnSideBarPictureBox_MouseEnter);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.OnSideBarPictureBox_MouseLeave);
            // 
            // lblCurrencies
            // 
            this.lblCurrencies.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCurrencies.ForeColor = System.Drawing.Color.LightGray;
            this.lblCurrencies.Location = new System.Drawing.Point(44, 4);
            this.lblCurrencies.Name = "lblCurrencies";
            this.lblCurrencies.Size = new System.Drawing.Size(140, 37);
            this.lblCurrencies.TabIndex = 0;
            this.lblCurrencies.Text = "Currencies";
            this.lblCurrencies.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrencies.Click += new System.EventHandler(this.OnSideBarLabelClick);
            this.lblCurrencies.MouseEnter += new System.EventHandler(this.OnSideBarLabel_MouseEnter);
            this.lblCurrencies.MouseLeave += new System.EventHandler(this.OnSideBarLabel_MouseLeave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 658);
            this.Controls.Add(this.pnlMainScreen);
            this.Controls.Add(this.pnlSideBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Unity National Bank";
            this.pnlSideBar.ResumeLayout(false);
            this.pnlUsername.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbusername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSideBarDrawer)).EndInit();
            this.pnlLogout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
            this.pnlDateTime.ResumeLayout(false);
            this.flpList.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            this.pnlAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).EndInit();
            this.pnlClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbClients)).EndInit();
            this.pnlUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsers)).EndInit();
            this.pnlEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployees)).EndInit();
            this.pnlTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTransactions)).EndInit();
            this.pnlRegisterations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRegisterations)).EndInit();
            this.pnlCurrencies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.Panel pnlMainScreen;
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.PictureBox pbusername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox pbSideBarDrawer;
        private System.Windows.Forms.Panel pnlLogout;
        private System.Windows.Forms.PictureBox pbLogout;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Panel pnlDateTime;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.FlowLayoutPanel flpList;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel pnlAccounts;
        private System.Windows.Forms.PictureBox pbAccounts;
        private System.Windows.Forms.Label lblAccounts;
        private System.Windows.Forms.Panel pnlClients;
        private System.Windows.Forms.PictureBox pbClients;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.PictureBox pbUsers;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Panel pnlEmployees;
        private System.Windows.Forms.PictureBox pbEmployees;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Panel pnlTransactions;
        private System.Windows.Forms.PictureBox pbTransactions;
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.Panel pnlRegisterations;
        private System.Windows.Forms.PictureBox pbRegisterations;
        private System.Windows.Forms.Label lblRegisterations;
        private System.Windows.Forms.Panel pnlCurrencies;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblCurrencies;
    }
}