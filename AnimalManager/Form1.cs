using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace AnimalManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Connect_SQL();
        }

        void Connect_SQL()
        {
            string message = SQL_Connect.Connect("server = 127.0.0.1; User Id = root; database = db_AnimalManager; password = admin");

            if(message != "")
            {
                MessageBox.Show("Error: " + message);
            }
            else
            {
                SQL_Connect.Connection.Open();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
