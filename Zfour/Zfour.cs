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
using static Zfour.SqlConnect; //ссылка на библиотеку подключения 

namespace Zfour
{
    public partial class Zfour : Form
    {
        public Zfour()
        {
            InitializeComponent();
        }

        //Переменная соединения
        public MySqlConnection conn;
        //глобальное обьвление класса подключение
        SqlConnect mysql;

        private void Datagrid()
        {
            try
            {
                conn.Open();
                string sql = $"SELECT * FROM t_datatime";
                dataGridView1.Columns.Add("fio", "ФИО");
                dataGridView1.Columns["fio"].Width = 100; //Дата грид, добавление полей, заголовки
                dataGridView1.Columns.Add("date_of_Birth", "День рождения");
                dataGridView1.Columns["date_of_Birth"].Width = 185;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) //считываение данных из бд
                {
                    dataGridView1.Rows.Add(reader["fio"].ToString(), reader["date_of_Birth"].ToString());

                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void Zfour_Load(object sender, EventArgs e)
        {
            //подключение
            mysql = new SqlConnect();//Класс подключения
            mysql.test(); //вызывается метод возвращение строки подключения
            conn = new MySqlConnection(mysql.connStr);
            Datagrid(); //вызывается метод загрузки датагрида при запуске формы
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            int id = dataGridView1.SelectedCells[0].RowIndex + 1; // Переменная id берёт индекс строки и прибавляет 1
            string url = $"SELECT photoUrl FROM t_datatime WHERE id = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string name = com.ExecuteScalar().ToString();
            conn.Close();
            pictureBox1.ImageLocation = $"{name}";
        }
    }
}
