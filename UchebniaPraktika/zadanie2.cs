using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace UchebniaPraktika
{
    public partial class zadanie2 : Form
    {
        public zadanie2()
        {
            InitializeComponent();
        }

        public MySqlConnection conn;
        Connection mysql;

        class Connection
        {
            string host = "10.90.12.110";
            string port = "33333";
            string user = "uchebka";
            string bd = "uchebka";
            string pass = "uchebka";
            public string connStr;
            public string test()
            {
                return connStr = $"server={host};port={port};user={user};database={bd};password={pass}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = new Connection();
                mysql.test();
                conn = new MySqlConnection(mysql.connStr);
                conn.Open();
                MessageBox.Show("Ураааа, подключение успешно");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
