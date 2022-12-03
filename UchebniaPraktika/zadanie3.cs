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
using static UchebniaPraktika.Program;
namespace UchebniaPraktika
{
    public partial class zadanie3 : Form
    {
        MySqlConnection conn;
        Connection mysql;

        public zadanie3()
        {
            InitializeComponent();
        }


        private void zadanie3_Load(object sender, EventArgs e)
        {
            //подключение
            mysql = new Connection();
            mysql.test();
            conn = new MySqlConnection(mysql.connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = $"SELECT who_ordered, phone, addres_who_ordered, fio_ordered, name_services, car, sum, datatime, id_order, id_clients FROM clients INNER JOIN orders ON id_clients = id_order ORDER BY id_clients;";
                dataGridView1.Columns.Add("id_clients", "ID Клиента");
                dataGridView1.Columns["id_clients"].Width = 100;
                dataGridView1.Columns.Add("who_ordered", "Кто заказал");
                dataGridView1.Columns["who_ordered"].Width = 185;
                dataGridView1.Columns.Add("phone", "Номер телефона");
                dataGridView1.Columns["phone"].Width = 105;
                dataGridView1.Columns.Add("addres_who_ordered", "адресс заказа");
                dataGridView1.Columns["addres_who_ordered"].Width = 100;
                dataGridView1.Columns.Add("fio_ordered", "ФИО заказчика");
                dataGridView1.Columns["fio_ordered"].Width = 130;
                dataGridView1.Columns.Add("name_services", "Название услуги");
                dataGridView1.Columns["name_services"].Width = 104;
                dataGridView1.Columns.Add("car", "Машина для заказа");
                dataGridView1.Columns["car"].Width = 175;
                dataGridView1.Columns.Add("sum", "Сумма заказа");
                dataGridView1.Columns["sum"].Width = 104;
                dataGridView1.Columns.Add("datatime", "Время заказа");
                dataGridView1.Columns["datatime"].Width = 104;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_clients"].ToString(), reader["who_ordered"].ToString(), reader["phone"].ToString(), reader["addres_who_ordered"].ToString(), 
                    reader["fio_ordered"].ToString(), reader["name_services"].ToString(), reader["car"].ToString(), reader["sum"].ToString(), reader["datatime"].ToString());

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Нужно выбрать именно запись в datagrid");
            }
        }
    }
}
