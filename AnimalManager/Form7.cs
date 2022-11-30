using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Windows.Forms;

namespace AnimalManager
{
    public partial class Form7 : Form
    {
        MySqlDataAdapter adapter;
        string strSQL;
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            this.Hide();
            form5.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                strSQL = "SELECT * FROM tb_product";
                adapter = new MySqlDataAdapter(strSQL, SQL_Connect.Connection);

                DataTable dt = new DataTable();

                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
