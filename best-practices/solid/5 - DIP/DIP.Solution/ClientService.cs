using DIP.Solution.Interfaces;

namespace DIP.Solution
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IEmailService _emailService;

        public ClientService(IClientRepository clientRepository, IEmailService emailService)
        {
            _clientRepository = clientRepository;
            _emailService = emailService;
        }

        public string Add(Client client)
        {
            if (!client.IsValid())
            {
                return "Invalid data";
            }

            _clientRepository.Add(client);

            _emailService.Send("company@company.com", client.Email, "Welcome", "Congratulations! You are registered.");

            return "Client successfully added!";
        }
    }
}
