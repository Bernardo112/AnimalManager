using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalManager
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            this.Hide();
            form4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
