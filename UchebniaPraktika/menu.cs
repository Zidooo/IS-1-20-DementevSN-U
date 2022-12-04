using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zfive;
using Zfour;
using Zone;
using Zthree;
using Ztwo;

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
            Zone.Zone z = new Zone.Zone();
            z.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ztwo.Ztwo z = new Ztwo.Ztwo();
            z.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zthree.Zthree z = new Zthree.Zthree();
            z.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Zfour.Zfour z = new Zfour.Zfour();
            z.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Zfive.Zfive z = new Zfive.Zfive();
            z.ShowDialog();
        }
    }
}
