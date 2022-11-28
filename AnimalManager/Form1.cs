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
            MySqlCommand commandReader = new MySqlCommand("select * from tb_login;", SQL_Connect.Connection);
            MySqlDataReader reader = commandReader.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();

                if (textBox1.Text != "" && strongPassword == true)
                {
                    MySqlCommand cmd = new MySqlCommand($"insert into tb_login (nm_user, nm_password, id_onUse) values ('{textBox1.Text}', '{textBox2.Text}', 'y')", SQL_Connect.Connection);

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

                return;
            }
            else
            {
                Login l = new Login();
                while (reader.Read())
                {
                    if (reader["id_onUse"].ToString() == "y")
                    {
                        l = new Login((int)reader["cd_login"], reader["nm_user"].ToString(), reader["nm_password"].ToString());
                        char[] array = reader["id_onUse"].ToString().ToCharArray();
                        l.OnUse = array[0];
                    }
                }

                if(textBox1.Text == l.UserName && textBox2.Text == l.Password)
                {
                    MessageBox.Show("Sucesso meu patrão");
                    var form5 = new Form5();
                    this.Hide();
                    form5.ShowDialog();    
                }
            }

            reader.Close();
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
                    if (c.ToString() == c.ToString().ToUpper() && !Int32.TryParse(c.ToString(), out int result))
                    {
                        UpperCheck = true;
                    }
                    if (Int32.TryParse(c.ToString(), out int value))
                    {
                        NumberCheck = true;
                    }
                }

                if (UpperCheck == true && NumberCheck == true)
                {
                    strongPassword = true;
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
