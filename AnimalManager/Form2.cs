using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Classes;
using System.Windows.Forms;

namespace AnimalManager
{
    public partial class Form2 : Form
    {
        Product product;
        string ValidatedNCM;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"insert into tb_login (nm_product, nm_brand, ncm, vl_sale_price, vl_cost_price, qt_product) values ('{textBox3.Text}', '{textBox2.Text}', '{textBox6.Text}', '{double.Parse(textBox1.Text)}', '{double.Parse(textBox5.Text)}', '{int.Parse(textBox1.Text)}')", SQL_Connect.Connection);

            cmd.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            this.Hide();
            form5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Form7 = new Form7();
            this.Hide();
            Form7.ShowDialog();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Length != 8)
            {
                MessageBox.Show("Número de caractéres inválido", "Caractéres inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Text = "";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 8)
            {
                ValidatedNCM = textBox6.Text;
            }

            if(textBox6.Text.Length > 8)
            {
                textBox6.Text = ValidatedNCM;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //product = new Product(0, textBox3.Text, textBox2.Text, textBox6.Text, double.Parse(textBox5.Text), int.Parse(textBox1.Text), );
        }
    }
}
