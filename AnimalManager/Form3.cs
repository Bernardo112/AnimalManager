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
using MySql.Data.MySqlClient;
using Classes;
using System.Globalization;

namespace AnimalManager
{
	public partial class Form3 : Form
	{
		string[] productStringCodes;
		List<int> gotProductCodes = new List<int>();
		int lastLength = 0;

		double totalValue = 0.00;

		public Form3()
		{
			InitializeComponent();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var Form8 = new Form8();
			this.Hide();
			Form8.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			gotProductCodes = new List<int>();
			lastLength = 0;
			totalValue = 0.00;
			textBox1.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
		}


		private void button4_Click(object sender, EventArgs e)
		{
			var Form5 = new Form5();
			this.Hide();
			Form5.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DateTime time = DateTime.Now;

			MySqlCommand cmd = new MySqlCommand($"insert into tb_sale (vl_total, dt_sale) values ({totalValue}, '{time.ToString("yyyy/MM/dd")}')", SQL_Connect.Connection);

			cmd.ExecuteNonQuery();

			MySqlCommand commandReader = new MySqlCommand($"select * from tb_sale;", SQL_Connect.Connection);
			MySqlDataReader reader = commandReader.ExecuteReader();

			int saleCode = 0;
			while (reader.Read())
			{
				saleCode = (int)reader["cd_sale"];
			}
			reader.Close();

			foreach (int code in gotProductCodes)
			{
				cmd = new MySqlCommand($"insert into tb_product_sale (fk_cd_product, fk_cd_sale, qt_product) values ({code}, {saleCode}, {int.Parse(textBox4.Text)})", SQL_Connect.Connection);
				cmd.ExecuteNonQuery();
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			productStringCodes = textBox3.Text.Split(';');
			List<int> productCodes = new List<int>();

			for (int i = lastLength;i < productStringCodes.Length; i++)
			{
				if (int.TryParse(productStringCodes[i], out int result))
				{
					productCodes.Add(result);
				}
			}

			if(productCodes.Count() < 1)
			{
				return;
			}

			int biggestCodeValue = productCodes.Max();

			MySqlCommand commandReader = new MySqlCommand($"select * from tb_product where cd_product = {biggestCodeValue};", SQL_Connect.Connection);
			MySqlDataReader reader = commandReader.ExecuteReader();

			while (reader.Read())
			{
				foreach (int code in productCodes)
				{
					if (code == (int)reader["cd_product"])
					{
						gotProductCodes.Add(code);
						totalValue += double.Parse(reader["vl_sale_price"].ToString());
						textBox1.Text = "R$ " + totalValue.ToString("F2", CultureInfo.InvariantCulture);
					}
				}
			}

			lastLength = productStringCodes.Length;
			reader.Close();
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			textBox1.Text = "R$ " + totalValue.ToString("F2", CultureInfo.InvariantCulture);
		}
	}
}
