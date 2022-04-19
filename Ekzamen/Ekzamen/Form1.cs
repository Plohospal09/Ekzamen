using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ekzamen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data source = .\SQLEXPRESS; initial catalog=СалонКрасоты; integrated security=SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("Select * from [User] Where Логин = '"+textBox1.Text+"' and Пароль = '"+textBox2.Text+"'",con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dataGridView1.DataSource = table;          
            con.Close();
            if (dataGridView1.Rows[0].Cells[2].Value != null)
            {
                Заказы заказы = new Заказы();
                заказы.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
