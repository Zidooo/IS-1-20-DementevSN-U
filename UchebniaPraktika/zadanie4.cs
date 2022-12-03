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
using static UchebniaPraktika.SqlConnect;

namespace UchebniaPraktika
{
    public partial class zadanie4 : Form
    {
        public zadanie4()
        {
            InitializeComponent();
        }


        public MySqlConnection conn;
        Connection mysql;

        private void Datagrid()
        {
            try
            {
                conn.Open();
                string sql = $"SELECT * FROM t_datatime";
                dataGridView1.Columns.Add("fio", "ФИО");
                dataGridView1.Columns["fio"].Width = 100;
                dataGridView1.Columns.Add("date_of_Birth", "др");
                dataGridView1.Columns["date_of_Birth"].Width = 185;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
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



        private void zadanie4_Load(object sender, EventArgs e)
        {
            mysql = new Connection();
            mysql.test();
            conn = new MySqlConnection(mysql.connStr);
            Datagrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 1)
            {
                conn.Open();
                int id = dataGridView1.Rows[0].Cells[0].Value;
                string url = $"SELECT photoUrl FROM t_datatime WHERE id = {id}";
                MySqlCommand com = new MySqlCommand(url, conn);
                string name = com.ExecuteScalar().ToString();
                conn.Close();
                pictureBox1.ImageLocation = $"{name}";
            }

        }
    }
}
