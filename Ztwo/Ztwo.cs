using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ztwo
{
    public partial class Ztwo : Form
    {
        public Ztwo()
        {
            InitializeComponent();
        }
        //Переменная соединения
        public MySqlConnection conn;
        //глобальное обьвление класса подключение
        Connection mysql;

        class Connection //класс подключения
        {
            string host = "chuc.caseum.ru";
            string port = "33333";
            string user = "uchebka";
            string bd = "uchebka";
            string pass = "uchebka";
            public string connStr;
            public string test() //метод который возвращает строку подключения
            {
                return connStr = $"server={host};port={port};user={user};database={bd};password={pass}";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //подключение
                mysql = new Connection(); //Класс подключения
                mysql.test();//вызывается метод возвращение строки подключения
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
