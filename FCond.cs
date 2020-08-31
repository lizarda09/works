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
    public partial class FCond : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sda;
        DataTable dt;
        public static int i = 0;
        public static string LastSelect = "===";
        public FCond()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sda = new SqlDataAdapter(@"SELECT * FROM Conduct", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox1.Items.Add("ФИО");
            comboBox1.Items.Add("Цене");
            comboBox1.Items.Add("ID");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }





        private void ведущиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCust fcond = new FCust();
            fcond.Show();
            Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FEditCond feditc = new FEditCond();
            feditc.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sda = new SqlDataAdapter(@"SELECT * FROM Conduct", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void событиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEvent fevent = new FEvent();
            fevent.Show();
            Hide();
        }

        private void локацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLoc fLoc = new FLoc();
            fLoc.Show();
            Hide();
        }

        private void допУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAddS fAddS = new FAddS();
            fAddS.Show();
            Hide();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == "ФИО")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM Conduct ORDER BY Name_cond", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Цене")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM Conduct ORDER BY Price_cond", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "ID")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM Conduct ORDER BY Id_conduct", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button4_Click(object sender, EventArgs e)
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
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRepCond fRepCond = new FRepCond();
            fRepCond.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FStatConduct fStatConduct = new FStatConduct();
            fStatConduct.Show();
            
        }
    }
}
