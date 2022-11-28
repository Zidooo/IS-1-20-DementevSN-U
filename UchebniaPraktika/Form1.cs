using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace UchebniaPraktika
{
    public partial class Form1 : Form
    {
        public Form1()
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
            public void Display()
            {
                MessageBox.Show($"Артикул: {article}\nЦена:{cost}\nГод выпуска: {year_of_production} ");
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

            public new void Display()
            {
                MessageBox.Show($"Артикул: {article}\nЦена:{cost}\nГод выпуска: {year_of_production}\nКоличество оборотов: {number_of_revolutions}\nИнтерфейс: {iInterface}\nОбъем: {volume} Гб");
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
            public new void Display()
            {
                MessageBox.Show($"Артикул: {article}\nЦена: {cost}\nГод выпуска: {year_of_production}\nЧастота: {gpu_frequency}\nПроизводитель: {manufacturer}\nОбъем памяти: {memory_capacity} Гб");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add($"Артикул: {textBox9.Text}");
            listBox1.Items.Add($"Цена: {textBox1.Text}");
            listBox1.Items.Add($"Год Выпуска: {textBox2.Text}");
            listBox1.Items.Add($"Частота оборотов: {textBox3.Text}");
            listBox1.Items.Add($"Интерфейс: {textBox4.Text}");
            listBox1.Items.Add($"Объем памяти: {textBox5.Text} Гб");
            disks<int> xx = new disks<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox9.Text));
            xx.Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add($"Артикул: {textBox9.Text}");
            listBox1.Items.Add($"Цена: {textBox1.Text}");
            listBox1.Items.Add($"Год Выпуска: {textBox2.Text}");
            listBox1.Items.Add($"Частота: {textBox6.Text}");
            listBox1.Items.Add($"Производитель: {textBox7.Text}");
            listBox1.Items.Add($"Видеопамять: {textBox8.Text} Гб");
            Videocard<int> xx = new Videocard<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox6.Text), textBox7.Text, Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
            xx.Display();
        }
    }
}
