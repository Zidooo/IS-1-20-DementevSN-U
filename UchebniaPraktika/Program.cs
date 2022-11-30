using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchebniaPraktika
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new menu());
        }

        public class Connection
        {
            public string host = "10.90.12.110";
            public string port = "33333";
            public string user = "st_1_20_11";
            public string bd = "is_1_20_st11_KURS";
            public string pass = "25645194";
            public string connStr;
            public string test()
            {
                return connStr = $"host={host};port={port};user={user};database={bd};password={pass}";
            }
        }
    }
}
