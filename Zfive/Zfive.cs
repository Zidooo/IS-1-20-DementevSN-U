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
using Zfour;
using MySql.Data.MySqlClient;
using static Zfour.SqlConnect;  //ссылка на библиотеку подключения 
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Zfive
{
    public partial class Zfive : Form
    {
        public Zfive()
        {
            InitializeComponent();
        }

         //Переменная соединения
         public MySqlConnection conn;
         //глобальное обьвление класса подключение
         SqlConnect mysql;


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string insertt = textBox1.Text; //Текст бокс откуда будет браться информация ввода 
                DateTime datetest = DateTime.Now;
                conn.Open();
                string insert = $"INSERT INTO t_Uchebka_DEMENTEV(fioStud, datetimeStud) " + $"VALUES ('{insertt}', '{String.Format("{0:s}", datetest)}');" + $"SELECT idStud FROM t_Uchebka_DEMENTEV WHERE(idStud = LAST_INSERT_ID());"; // sql запрос на ввод в бд
                MySqlCommand command = new MySqlCommand(insert, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные успешно введены!");
                if (textBox1.Text == "") //проверка на пустоту текстбокса
                {
                    MessageBox.Show("Ошибка!\nПоле для ввода фио не может быть пустым");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Zfive_Load(object sender, EventArgs e)
        {
            //подключение
            mysql = new SqlConnect();//Класс подключения
            mysql.test(); //вызывается метод возвращение строки подключения
            conn = new MySqlConnection(mysql.connStr);
        }
    }
}
