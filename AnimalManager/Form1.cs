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
        }

        void Connect_SQL()
        {
            string message = SQL_Connect.Connect("127.0.0.1", "root", "db_AnimalManager", "admin");

            if(message != "")
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
    }
}
