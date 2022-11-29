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
using System.Globalization;

namespace AnimalManager
{
    public partial class Form2 : Form
    {
        string ValidatedNCM;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"insert into tb_product (nm_product, nm_brand, ncm, vl_sale_price, vl_cost_price, qt_product) values ('{textBox3.Text}', '{textBox2.Text}', '{textBox6.Text}', '{double.Parse(textBox1.Text.ToString(CultureInfo.InvariantCulture))}', '{double.Parse(textBox5.Text.ToString(CultureInfo.InvariantCulture))}', '{int.Parse(textBox4.Text)}')", SQL_Connect.Connection);

            cmd.ExecuteNonQuery();
            button2_Click(sender, e);
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
            else if (!int.TryParse(textBox6.Text, out _))
            {
                MessageBox.Show("É apenas permitido números", "Formato incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Text = "";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 8)
            {
                ValidatedNCM = textBox6.Text;
            }

			if (textBox6.Text.Length > 8)
            {
                textBox6.Text = ValidatedNCM;
            }
        }

		private void textBox1_Leave(object sender, EventArgs e)
		{
            if (!double.TryParse(textBox1.Text.ToString(CultureInfo.InvariantCulture), out _))
            {
                MessageBox.Show("É apenas permitido números", "Formato incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
        }

		private void textBox5_Leave(object sender, EventArgs e)
		{
            if (!double.TryParse(textBox5.Text.ToString(CultureInfo.InvariantCulture), out _))
            {
                MessageBox.Show("É apenas permitido números", "Formato incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Text = "";
            }
        }

		private void textBox4_Leave(object sender, EventArgs e)
		{
            if (!int.TryParse(textBox4.Text, out _))
            {
                MessageBox.Show("É apenas permitido números", "Formato incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = "";
            }
        }
	}
}
