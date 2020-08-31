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
    public partial class FEditAddS : Form
    {
        SqlConnection sqlConnection;
        public FEditAddS()
        {
            InitializeComponent();
        }

        private async void FEditAddS_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

          
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && 
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [AddServ] (Name_serv, Price_serv, Id_ev)VALUES(@Name_serv, @Price_serv, @Id_serv)", sqlConnection);

                command.Parameters.AddWithValue("Name_serv", textBox1.Text);
                command.Parameters.AddWithValue("Id_serv", textBox2.Text);
                command.Parameters.AddWithValue("Price_serv", textBox5.Text);
                
                textBox1.Clear();
                textBox2.Clear();
                textBox5.Clear();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Данные успешно добавлены :)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Данного события не существует");
                }
            }
            else
            {
                label5.Visible = true;

                label5.Text = "Все поля должны быть заполнены!";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label11.Visible)
                label11.Visible = false;

            if (
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [AddServ] SET [Name_serv]=@Name_serv, [Price_serv]=@Price_serv [Id_ev]=@Id_ev WHERE [Id_serv]=@Id_serv", sqlConnection);

                command.Parameters.AddWithValue("Id_serv", textBox7.Text);
                command.Parameters.AddWithValue("Name_serv", textBox4.Text);
                command.Parameters.AddWithValue("Price_serv", textBox6.Text);
                command.Parameters.AddWithValue("Id_ev", textBox3.Text);
                
                textBox4.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox3.Clear();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Данные успешно обновлены :)");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Такого события не существует");
                }
            }
            else if (string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrWhiteSpace(textBox7.Text))
            {
                label11.Visible = true;

                label11.Text = "Id услуги должнен быть заполнен!";
            }
            else
            {
                label11.Visible = true;

                label11.Text = "Все поля должны быть заполнены!";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label15.Visible)
                label15.Visible = false;
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
            )
            {
                SqlCommand command = new SqlCommand("DELETE FROM [AddServ] WHERE [Id_serv]=@Id_serv", sqlConnection);
                command.Parameters.AddWithValue("Id_verv", textBox10.Text);
                
                textBox10.Clear();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Данные успешно удалены :)");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Такого события не существует");
                }

            }
            else if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [AddServ] WHERE [Name_serv]=@Name_serv", sqlConnection);
                command.Parameters.AddWithValue("Name_serv", textBox11.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox11.Clear();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Данные успешно удалены :)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Такого события не существует");
                }
            }
            else
            {

                label15.Visible = true;
                label15.Text = "Введите или название или ID";
            }
        }
    }
}
