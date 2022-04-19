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
    public partial class Заказы : Form
    {
        public Заказы()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data source = .\SQLEXPRESS; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT [Employee].[LastName]+' '+[Employee].[MiddleName]+' '+[Employee].[FirstName],[Name],count(Client.LastName" +
                "+ ' ' + Client.MiddleName + ' ' + Client.FirstName) as [Кол-во заказов] FROM[dbo].[Employee] " +
                "left join Position on PositionId = Position.ID " +
                "left join [Order] on [Order].EmployeeID = Employee.ID " +
                "left join Client on Client.ID = [Order].ClientID " +
                "group by [Employee].[LastName]+' '+[Employee].[MiddleName]+' '+[Employee].[FirstName],[Name]", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dataGridView1.DataSource = table;
            con.Close();
        }
        SqlConnection con;
        private void button1_Click(object sender, EventArgs e)
        {
            Формирование_заявок заявок = new Формирование_заявок();
            заявок.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Заявки заявки = new Заявки();
            заявки.Show();
            Hide();
        }
    }
}
