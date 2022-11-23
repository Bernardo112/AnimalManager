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
using Classes;

namespace AnimalManager
{
    public partial class Form1 : Form
    {
        bool strongPassword;

        public Form1()
        {
            InitializeComponent();
        }

        void Connect_SQL()
        {
            string message = SQL_Connect.Connect("127.0.0.1", "root", "db_AnimalManager", "admin");

            if (message != "")
            {
                MessageBox.Show(("Error: " + message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SQL_Connect.Connection.Open();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect_SQL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && strongPassword == true)
            {
                MySqlCommand cmd = new MySqlCommand($"insert into tb_login (nm_user, nm_password) values ('{textBox1.Text}', '{textBox2.Text}')", SQL_Connect.Connection);

                cmd.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("                       USUÁRIO OU SENHA INVÁLIDOS \n\n\n(é necessário pelo menos 8 caractéres, uma letra maiúscula e um número na senha)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool UpperCheck = false;
            bool NumberCheck = false;
            char[] passwordArray = textBox2.Text.ToCharArray();
            if (textBox2.TextLength >= 8)
            {
                foreach (char c in passwordArray)
                {
                    if(c.ToString() == c.ToString().ToUpper() && !Int32.TryParse(c.ToString(), out int result))
                    {
                        UpperCheck = true;
                    }
                    if(Int32.TryParse(c.ToString(), out int value))
                    {
                        NumberCheck = true;
                    }
                }

                if(UpperCheck == true && NumberCheck == true)
                {
                    strongPassword = true;
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            button1_Click(sender, e);
        }
    }
}
