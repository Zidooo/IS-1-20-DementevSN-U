using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UchebniaPraktika
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zadanie2 z2 = new zadanie2();
            z2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zadanie3 z3 = new zadanie3();
            z3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zadanie4 z4 = new zadanie4();
            z4.ShowDialog();
        }
    }
}
