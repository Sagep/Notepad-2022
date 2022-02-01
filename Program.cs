using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_2022
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
            Form2 loginform = new Form2();
            Application.Run(loginform);
            if(loginform.UserSuccessfullyAuthenticated)
            {
                Application.Run(new Form1());
            }
        }
    }
}
