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
            datagridload();
        }


        private void datagridload()
        {

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM employees;";
            command.CommandText = commandString;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                dataGridView1.Columns.Add("id_employees", "ID Сотрудника");
                dataGridView1.Columns["id_employees"].Width = 100;
                dataGridView1.Columns.Add("FIO", "ФИО");
                dataGridView1.Columns["FIO"].Width = 185;
                dataGridView1.Columns.Add("number_pass", "Номер паспорта");
                dataGridView1.Columns["number_pass"].Width = 105;
                dataGridView1.Columns.Add("salary", "Зарплата");
                dataGridView1.Columns["salary"].Width = 100;
                dataGridView1.Columns.Add("address", "Адресс");
                dataGridView1.Columns["address"].Width = 130;
                dataGridView1.Columns.Add("job_title", "Должность");
                dataGridView1.Columns["job_title"].Width = 104;
                dataGridView1.Columns.Add("email", "Email");
                dataGridView1.Columns["email"].Width = 175;
                dataGridView1.Columns.Add("phone", "Номер телефона");
                dataGridView1.Columns["phone"].Width = 104;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_employees"].ToString(), reader["FIO"].ToString(), reader["number_pass"].ToString(), reader["salary"].ToString(), reader["address"].ToString(), reader["job_title"].ToString(), reader["email"].ToString(), reader["phone"].ToString());
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }


        private void zadanie3_Load(object sender, EventArgs e)
        {
            mysql = new Connection();
            mysql.test();
            conn = new MySqlConnection(mysql.connStr);
        }
    }
}
