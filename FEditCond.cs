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
    public partial class FEditCond : Form
    {
        SqlConnection sqlConnection;
        public FEditCond()
        {
            InitializeComponent();
        }

       

        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label11.Visible)
                label11.Visible = false;

            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Conduct] SET [Name_cond]=@Name_cond, [Phone_cond]=@Phone_cond, [Mail_cond]=@Mail_cond, [Price_cond]=@Price_cond WHERE [Id_conduct]=@Id_conduct", sqlConnection);

                command.Parameters.AddWithValue("Id_conduct", textBox9.Text);
                command.Parameters.AddWithValue("Name_cond", textBox7.Text);
                command.Parameters.AddWithValue("Price_cond", textBox8.Text);
                command.Parameters.AddWithValue("Phone_cond", textBox6.Text);
                command.Parameters.AddWithValue("Mail_cond", textBox4.Text);
                textBox4.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                MessageBox.Show("Данные успешно обновлены :)");

                await command.ExecuteNonQueryAsync();
            }
            else if (string.IsNullOrEmpty(textBox9.Text) && string.IsNullOrWhiteSpace(textBox9.Text))
            {
                label11.Visible = true;

                label11.Text = "Id должнен быть заполнен!";
            }
            else
            {
                label11.Visible = true;

                label11.Text = "Все поля должны быть заполнены!";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Conduct] (Name_cond, Phone_cond, Mail_cond, Price_cond)VALUES(@Name_cond, @Phone_cond, @Mail_cond, @Price_cond)", sqlConnection);

                command.Parameters.AddWithValue("Name_cond", textBox1.Text);
                command.Parameters.AddWithValue("Phone_cond", textBox2.Text);
                command.Parameters.AddWithValue("Price_cond", textBox5.Text);
                command.Parameters.AddWithValue("Mail_cond", textBox3.Text);
                MessageBox.Show("Данные успешно добавлены :)");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label5.Visible = true;

                label5.Text = "должны быть заполнены!";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label15.Visible)
                label15.Visible = false;
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
            )
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Conduct] WHERE [Id_conduct]=@Id_conduct", sqlConnection);
                command.Parameters.AddWithValue("Id_conduct", textBox10.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox10.Clear();
                
                await command.ExecuteNonQueryAsync();

            }
            else if(!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Conduct] WHERE [Name_cond]=@Name_cond", sqlConnection);
                command.Parameters.AddWithValue("Name_cond", textBox11.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox11.Clear();
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                
                label15.Visible = true;
                label15.Text = "Введите или ФИО или ID";
            }
        }
    }
}
