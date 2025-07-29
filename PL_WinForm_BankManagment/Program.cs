using PL_WinForm_BankManagment.Main_Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_WinForm_BankManagment
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

         /*   short tries = 0;

            while (true)
            {
                frmLogin frm = new frmLogin();
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tries = 0;*/
                    Application.Run(new frmMain());
           /*     }

                else if (result == DialogResult.Retry)
                {
                    tries++;
                    if (tries == 3)
                    {
                        MessageBox.Show("You failed to login 3 times");
                        break;
                    }
                }

                else if (result == DialogResult.Cancel)
                {
                    break;
                }
           
            }*/
        }
    }
}
