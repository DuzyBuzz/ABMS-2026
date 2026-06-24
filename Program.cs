using ABMS_2026.Data.MySql;
using ABMS_2026.UI.Forms;
using System;
using System.Windows.Forms;

namespace ABMS_2026
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new LoginForm());
        }
    }
}