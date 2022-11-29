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
using Classes;
using MySql.Data.MySqlClient;

namespace AnimalManager
{
    public partial class Form4 : Form
    {
        string ValidatedCNPJ;
        string ValidatedPhone;

        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            this.Hide();
            form5.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form9 = new Form9();
            this.Hide();
            form9.ShowDialog();
        }

		private void button1_Click(object sender, EventArgs e)
		{
            if(textBox2.Text == "")
			{
                MessageBox.Show("Campo do cnpj vazio", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(textBox3.Text == "")
			{
                MessageBox.Show("Campo do nome vazio", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MySqlCommand cmd = new MySqlCommand($"insert into tb_supplier (cnpj, nm_supplier, nm_email, nm_address, nr_phone) values ('{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox4.Text}', '{textBox5.Text}')", SQL_Connect.Connection);

            cmd.ExecuteNonQuery();
            button2_Click(sender, e);
        }

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
            if (textBox2.Text.Length == 14)
            {
                ValidatedCNPJ = textBox2.Text;
            }

            if (textBox2.Text.Length > 14)
            {
                textBox2.Text = ValidatedCNPJ;
            }
        }

		private void textBox2_Leave(object sender, EventArgs e)
		{
            if (textBox2.Text.Length != 14)
            {
                MessageBox.Show("Número de caractéres inválido", "Caractéres inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }
            else if (!Int64.TryParse(textBox2.Text, out _))
            {
                MessageBox.Show("É apenas permitido números", "Formato incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }
        }

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
            if (textBox5.Text.Length == 11)
            {
                ValidatedPhone = textBox5.Text;
            }

            if (textBox5.Text.Length > 11)
            {
                textBox5.Text = ValidatedPhone;
            }
        }
	}
}
