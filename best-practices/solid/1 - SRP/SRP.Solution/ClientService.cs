namespace SRP.Solution
{
    public class ClientService
    {
        public string Add(Client client)
        {
            if (!client.IsValid())
            {
                return "Invalid data";
            }

            var repository = new ClientRepository();
            repository.Add(client);

            EmailService.Send("company@company.com", client.Email, "Welcome", "Congratulations! You are registered.");

            return "Client successfully added!";
        }
    }
}
