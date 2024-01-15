using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace SRP.Violation
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }

        public string Add()
        {
            if (!Email.Contains("@"))
            {
                return "Invalid email.";
            }

            using (var connection = new SqlConnection())
            {
                var command = new SqlCommand();

                connection.ConnectionString = "ConnectionString";
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO CLIENTE (NAME, EMAIL INSERTDATE) VALUES (@name, @email, @insertDate))";

                command.Parameters.AddWithValue("name", Name);
                command.Parameters.AddWithValue("email", Email);
                command.Parameters.AddWithValue("insertDate", InsertDate);

                connection.Open();
                command.ExecuteNonQuery();
            }

            var mail = new MailMessage("company@company.com", Email);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = "Welcome";
            mail.Body = "Congratulations! You are registered.";
            client.Send(mail);

            return "Client successfully added!";
        }
    }
}
