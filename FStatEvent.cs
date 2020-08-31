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
    public partial class FStatEvent : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sda;
        DataTable dt;
        public FStatEvent()
        {
            InitializeComponent();
        }

        private void FStatEvent_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Уже проведенные");
            comboBox1.Items.Add("Которые проведутся");
            comboBox1.Items.Add("На сегодня");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == "Уже проведенные")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT N'Уже проведено:' as 'Условие', COUNT(Name_ev) as N'Кол-во праздников' FROM Event WHERE FinishD < GETDATE()", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Которые проведутся")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT N'Которые проведутся:' as 'Условие', COUNT(Name_ev) as N'Кол-во праздников' FROM Event WHERE FirstD > GETDATE()", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "На сегодня")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT N'На сегодня:' as 'Условие', COUNT(Name_ev) as N'Кол-во праздников' FROM Event WHERE FirstD = GETDATE()", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
