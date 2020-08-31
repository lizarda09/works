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
    public partial class FEvent : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter sda;
        DataTable dt;
        public static int i = 0;
        public static string LastSelect = "===";
        public FEvent()
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
            FCust fCust = new FCust();
            fCust.Show();
            Hide();
        }

        private async void FEvent_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sda = new SqlDataAdapter(@"SELECT * FROM [Event]", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox1.Items.Add("ID");
            comboBox1.Items.Add("Названию");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FEditEvent fEditEvent = new FEditEvent();
            fEditEvent.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sda = new SqlDataAdapter(@"SELECT * FROM [Event]", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void допУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAddS fAddS = new FAddS();
            fAddS.Show();
            Hide();

        }

        private void локацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLoc fLoc = new FLoc();
            fLoc.Show();
            Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.Text == "Названию")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM [Location] ORDER BY Name_loc", sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "ID")
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionString);
                sda = new SqlDataAdapter(@"SELECT * FROM [Location] ORDER BY Id_location", sqlConnection);
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
                break;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRepEvent fRepEvent = new FRepEvent();
            fRepEvent.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FStatEvent fStatEvent = new FStatEvent();
            fStatEvent.Show();

        }

      
    }
}
