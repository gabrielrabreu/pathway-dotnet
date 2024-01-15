using DIP.Solution.Interfaces;
using System;

namespace DIP.Solution
{
    public class Client
    {
        private readonly IEmailValidator _emailValidator;

        public Client(IEmailValidator emailValidator)
        {
            _emailValidator = emailValidator;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }

        public bool IsValid()
        {
            return _emailValidator.IsValid(Email);
        }
    }
}
