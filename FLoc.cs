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
    public partial class FLoc : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sda;
        DataTable dt;
        public static int i = 0;
        public static string LastSelect="===";
        public FLoc()
        {
            InitializeComponent();
        }

        private void ведущиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCond fCond = new FCond();
            fCond.Show();
            Hide();
        }

        private void событиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEvent fEvent = new FEvent();
            fEvent.Show();
            Hide();
        }

        private void заказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCust fCust = new FCust();
            fCust.Show();
            Hide();
        }

        private async void FLoc_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sda = new SqlDataAdapter(@"SELECT * FROM Location", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox1.Items.Add("Цене");
            comboBox1.Items.Add("Названию");
            comboBox1.Items.Add("ID");
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sda = new SqlDataAdapter(@"SELECT * FROM Location", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FEditLoc fEditLoc = new FEditLoc();
            fEditLoc.Show();

        }

        private void допУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAddS fAddS = new FAddS();
            fAddS.Show();
            Hide();

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == "Названию")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM Location ORDER BY Name_loc", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Цене")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM Location ORDER BY Price", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "ID")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM Location ORDER BY Id_location", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private  void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                break;
            }
        }

        public string convTo20(string s) {
            StringBuilder str = new StringBuilder(s);
            int count = 25;
            
            while ((count - s.Length)>0) {
                str.Append("1");
            }

            return str.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FStatLoc fStatLoc = new FStatLoc();
            fStatLoc.Show();

        }
    }

}

