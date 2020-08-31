using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursHolidays
{
    public partial class FStatAddS : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sda;
        DataTable dt;
        public FStatAddS()
        {
            InitializeComponent();
        }

        private void FStatAddS_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sda = new SqlDataAdapter(@"SELECT Name_serv as N'Название доп. услуги', COUNT(Name_serv) as N'Кол-во заказов' FROM [AddServ] GROUP BY Name_serv", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

       
    }
}
