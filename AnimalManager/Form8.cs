using MySql.Data.MySqlClient;
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
    public partial class Form8 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        MySqlDataAdapter adapter;
        string strSQL;
        public Form8()
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
                conn = new MySqlConnection("Server=localhost;Database=db_animalmanager;Uid=root;Pwd=tubas;");



                strSQL = "SELECT * FROM tb_sale";



                adapter = new MySqlDataAdapter(strSQL, conn);



                DataTable dt = new DataTable();



                adapter.Fill(dt);



                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
                cmd = null;
            }
        }
    }
}
