using System.Data;
using System.Data.SqlClient;

namespace DIP.Violation
{
    internal class ClientRepository
    {
        public void Add(Client client)
        {
            using (var connection = new SqlConnection())
            {
                var command = new SqlCommand();

                connection.ConnectionString = "ConnectionString";
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO CLIENTE (NAME, EMAIL INSERTDATE) VALUES (@name, @email, @insertDate))";

                command.Parameters.AddWithValue("name", client.Name); ;
                command.Parameters.AddWithValue("email", client.Email);
                command.Parameters.AddWithValue("insertDate", client.InsertDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
