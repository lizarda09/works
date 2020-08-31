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
using System.Net.Mail;
using System.Net;

namespace KursHolidays
{
    public partial class FEditCust : Form
    {
        SqlConnection sqlConnection;
        public FEditCust()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text))
               {
                SqlCommand command = new SqlCommand("INSERT INTO [Customer] (Name_cust, Face_cust, Phone_cust, Mail_cust)VALUES(@Name_cust, @Face_cust, @Phone_cust, @Mail_cust)", sqlConnection);

                command.Parameters.AddWithValue("Name_cust", textBox1.Text);
                command.Parameters.AddWithValue("Face_cust", comboBox1.Text);
                command.Parameters.AddWithValue("Phone_cust", textBox2.Text); 
                command.Parameters.AddWithValue("Mail_cust", textBox3.Text);
                MessageBox.Show("Данные успешно добавлены :)");
                if (checkBox1.Checked)
                {
                    try
                    {
                        MailAddress fromMailAddress = new MailAddress("mirliz3748@gmail.com", "Администратор");
                        MailAddress toAddress = new MailAddress(textBox3.Text);

                        using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
                        using (SmtpClient smtpClient = new SmtpClient())
                        {
                            mailMessage.Subject = "Организация проведения праздников";
                            mailMessage.Body = "Регистрация прошла успешно. Спасибо, что выбрали нас :)";
                            //mailMessage.Attachments.Add(new Attachment("thx1.jpg"));
                            smtpClient.Host = "smtp.gmail.com";
                            smtpClient.Port = 587;
                            smtpClient.EnableSsl = true;
                            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "mirliz3748");

                            smtpClient.Send(mailMessage);
                            MessageBox.Show("И уведомление отправлено");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проверьте подключение к интернету");
                    }
                }
                comboBox1.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                
                await command.ExecuteNonQueryAsync();

            }
            else
            {
                label5.Visible = true;

                label5.Text = "должны быть заполнены!";
            }
        }

        private  async void button2_Click(object sender, EventArgs e)
        {
            if (label11.Visible)
                label11.Visible = false;

            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Customer] SET [Name_cust]=@Name_cust, [Face_cust]=@Face_cust, [Phone_cust]=@Phone_cust, [Mail_cust]=@Mail_cust WHERE [Id_customer]=@Id_customer", sqlConnection);

                command.Parameters.AddWithValue("Id_customer", textBox9.Text);
                command.Parameters.AddWithValue("Face_cust", comboBox2.Text);
                command.Parameters.AddWithValue("Name_cust", textBox7.Text);
                command.Parameters.AddWithValue("Phone_cust", textBox6.Text);
                command.Parameters.AddWithValue("Mail_cust", textBox4.Text);
                MessageBox.Show("Данные успешно обновлены :)");
                textBox9.Clear();
                comboBox2.Items.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox4.Clear();

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
                SqlCommand command = new SqlCommand("DELETE FROM [Customer] WHERE [Id_customer]=@Id_customer", sqlConnection);
                command.Parameters.AddWithValue("Id_customer", textBox10.Text);
                MessageBox.Show("Данные успешно удалены :)");
                textBox10.Clear();
                
                await command.ExecuteNonQueryAsync();

            }
            else if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Customer] WHERE [Name_cust]=@Name_cust", sqlConnection);
                command.Parameters.AddWithValue("Name_cust", textBox11.Text);
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

        private async void FEditCust_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\KursHolidays\KursHolidays\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
            comboBox1.Items.Add("Физическое");
            comboBox1.Items.Add("Юридическое");
            comboBox2.Items.Add("Физическое");
            comboBox2.Items.Add("Юридическое");
            
        }

        

        
    }
}
