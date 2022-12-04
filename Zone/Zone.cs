using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Zone
{
    public partial class Zone : Form
    {
        public Zone()
        {
            InitializeComponent();
        }
        public abstract class Complects<X>
        {
            public X article;  // Артикуль
            public int cost; // Прайс
            public int year_of_production; // Год выпуска
            public Complects(int Cost, int Year_of_production, X Article)
            {
                cost = Cost; // Прайс
                year_of_production = Year_of_production; // Год выпуска
                article = Article; // Артикуль
            }
            public string Display()
            {
                return ($"Артикул: {article} Цена:{cost} Год выпуска: {year_of_production}");
            }
        }
        public class disks<X> : Complects<X>
        {
            public int number_of_revolutions { get; set; } // Количество оборотов
            public string iInterface { get; set; } // Интерфейс
            public int volume { get; set; } // Обьем

            public disks(int Cost, int Year_of_production, int Number_of_revolutions, string IInterface, int Volume, X Article) : base(Cost, Year_of_production, Article)
            {
                number_of_revolutions = Number_of_revolutions; // Количество оборотов
                iInterface = IInterface; // Интерфейс
                volume = Volume; // Обьем
            }

            public new string Display()
            {
                return ($"Артикул: {article} Цена:{cost} Год выпуска: {year_of_production} Количество оборотов: {number_of_revolutions} Интерфейс: {iInterface} Объем: {volume} Гб");
            }
        }
        class Videocard<X> : Complects<X>
        {
            public int gpu_frequency { get; set; } // Частота GPU
            public string manufacturer { get; set; } // Производитель
            public int memory_capacity { get; set; } // Обьем памяти
            public Videocard(int Cost, int Year_of_production, int Gpu_frequency, string Manufacturer, int Memory_capacity, X Article) : base(Cost, Year_of_production, Article)
            {
                gpu_frequency = Gpu_frequency; // Частота GPU
                manufacturer = Manufacturer; // Производитель
                memory_capacity = Memory_capacity; // Обьем памяти
            }
            public new string Display()
            {
                return ($"Артикул: {article} Цена: {cost} Год выпуска: {year_of_production} Частота: {gpu_frequency} Производитель: {manufacturer} Объем памяти: {memory_capacity} Гб");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            disks<int> xx = new disks<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox9.Text));
            listBox1.Items.Add(xx.Display());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Videocard<int> xx = new Videocard<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox6.Text), textBox7.Text, Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
            listBox1.Items.Add(xx.Display());
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            disks<int> v1 = new disks<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox9.Text));
            listBox1.Items.Add(v1.Display());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Videocard<int> v1 = new Videocard<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox6.Text), textBox7.Text, Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
            listBox1.Items.Add(v1.Display());
        }
    }
}
