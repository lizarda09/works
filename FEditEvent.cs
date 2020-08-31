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
    public partial class FEditEvent : Form
    {
        SqlConnection sqlConnection;
        public FEditEvent()
        {
            InitializeComponent();
        }

        private async void FEditEvent_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;

            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) )
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Event] (Name_ev, Numg, Cond, FirstD, FinishD, Id_cust, Id_cond)VALUES(@Name_ev, @Numg, @Cond, @FirstD, @FinishD, @Id_cust, @Id_cond)", sqlConnection);

                command.Parameters.AddWithValue("Name_ev", textBox5.Text);
                command.Parameters.AddWithValue("Numg", textBox2.Text);
                command.Parameters.AddWithValue("Cond", textBox3.Text);
                command.Parameters.AddWithValue("FirstD", dateTimePicker1.Value);
                command.Parameters.AddWithValue("FinishD", dateTimePicker2.Value);
                command.Parameters.AddWithValue("Id_cond", textBox8.Text);
                command.Parameters.AddWithValue("Id_cust", textBox12.Text);

                
                
                textBox5.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox8.Clear();
                textBox12.Clear();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Данные успешно добавлены :)");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Проверьте, существуют ли этот заказчик или ведущий");
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

            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Event] SET [Name_ev]=@Name_ev, [Numg]=@Numg, [Cond]=@Cond, [FirstD]=@FirstD, [FinishD]=@FinishD, [Id_cust]=@Id_cust, [Id_cond]=@Id_cond WHERE [Id_event]=@Id_event", sqlConnection);

                command.Parameters.AddWithValue("Id_event", textBox13.Text);
                command.Parameters.AddWithValue("Name_ev", textBox6.Text);
                command.Parameters.AddWithValue("Numg", textBox9.Text);
                command.Parameters.AddWithValue("Cond", textBox7.Text);
                command.Parameters.AddWithValue("FirstD", dateTimePicker1.Value);
                command.Parameters.AddWithValue("FinishD", dateTimePicker2.Value);
                command.Parameters.AddWithValue("Id_cust", textBox1.Text);
                command.Parameters.AddWithValue("Id_cond", textBox4.Text);
               
                textBox13.Clear();
                textBox6.Clear();
                textBox9.Clear();
                textBox7.Clear();
                textBox1.Clear();
                textBox4.Clear();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Данные успешно обновлены :)");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Проверьте, существуют ли этот заказчик или ведущий");
                }
            }
            else if (string.IsNullOrEmpty(textBox13.Text) && string.IsNullOrWhiteSpace(textBox13.Text))
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
                SqlCommand command = new SqlCommand("DELETE FROM [Event] WHERE [Id_event]=@Id_event", sqlConnection);
                command.Parameters.AddWithValue("Id_event", textBox10.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox10.Clear();

                await command.ExecuteNonQueryAsync();

            }
            else if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Event] WHERE [Name_ev]=@Name_ev", sqlConnection);
                command.Parameters.AddWithValue("Name_ev", textBox11.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox11.Clear();
                await command.ExecuteNonQueryAsync();
            }
            else
            {

                label15.Visible = true;
                label15.Text = "Введите название события или ID";
            }
        }

        
    }
}
