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
    public partial class FEditLoc : Form
    {
        SqlConnection sqlConnection;
        public FEditLoc()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;

            if (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Location] (Name_loc, Type, Maxcup, Descr, Price, Id_ev)VALUES(@Name_loc, @Type, @Maxcup, @Descr, @Price, @Id_ev)", sqlConnection);

                command.Parameters.AddWithValue("Name_loc", textBox1.Text);
                command.Parameters.AddWithValue("Type", textBox5.Text);
                command.Parameters.AddWithValue("Price", textBox3.Text);
                command.Parameters.AddWithValue("Maxcup", textBox2.Text);
                command.Parameters.AddWithValue("Descr", textBox8.Text);
                command.Parameters.AddWithValue("Id_ev", textBox12.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox8.Clear();
                textBox12.Clear();
               


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

                label5.Text = " Все поля должны быть заполнены!";
            }
        }

        private async void FEditLoc_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

           
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label11.Visible)
                label11.Visible = false;

            if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Location] SET [Name_loc]=@Name_loc, [Type]=@Type, [Maxcup]=@Maxcup, [Descr]=@Descr, [Price]=@Price, [Id_ev]=@Id_ev WHERE [Id_location]=@Id_location", sqlConnection);

                command.Parameters.AddWithValue("Id_location", textBox9.Text);
                command.Parameters.AddWithValue("Name_loc", textBox15.Text);
                command.Parameters.AddWithValue("Type", textBox7.Text);
                command.Parameters.AddWithValue("Descr", textBox6.Text);
                command.Parameters.AddWithValue("Maxcup", textBox14.Text);
                command.Parameters.AddWithValue("Price", textBox13.Text);
                command.Parameters.AddWithValue("Id_ev", textBox4.Text);
                textBox9.Clear();
                textBox15.Clear();
                textBox7.Clear();
                textBox14.Clear();
                textBox13.Clear();
                textBox6.Clear();
                textBox4.Clear();
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

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label15.Visible)
                label15.Visible = false;
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)
            )
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Location] WHERE [Id_location]=@Id_location", sqlConnection);
                command.Parameters.AddWithValue("Id_location", textBox10.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox10.Clear();
                await command.ExecuteNonQueryAsync();

            }
            else if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Location] WHERE [Name_loc]=@Name_loc", sqlConnection);
                command.Parameters.AddWithValue("Name_loc", textBox11.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox11.Clear();
                await command.ExecuteNonQueryAsync();
            }
            else
            {

                label15.Visible = true;
                label15.Text = "Введите имя события или ID";
            }
        }
    }
}
