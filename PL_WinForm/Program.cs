using BLL.Manager;
using BLL_BankManagment.Person_Manager;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using Models;
using PL.MainForm;
using PL_WinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmMain());
        }

    }
}
