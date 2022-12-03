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
using static UchebniaPraktika.SqlConnect;  //ссылка на библиотеку подключения 

namespace UchebniaPraktika
{
    public partial class zadanie5 : Form
    {
        public zadanie5()
        {
            InitializeComponent();
        }

        //Переменная соединения
        public MySqlConnection conn;
        //глобальное обьвление класса подключение
        Connection mysql;

        private void zadanie5_Load(object sender, EventArgs e)
        {
            //подключение
            mysql = new Connection();//Класс подключения
            mysql.test(); //вызывается метод возвращение строки подключения
            conn = new MySqlConnection(mysql.connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string FIO = textBox1.Text; //Текст бокс откуда будет браться фио
                conn.Open();
                string insert = $"INSERT INTO t_Uchebka_DEMENTEV(fioStud)" + $"VALUES ('{FIO}')"; // sql запрос на ввод в бд
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
    }
}
