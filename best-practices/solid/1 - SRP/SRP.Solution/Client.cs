using System;

namespace SRP.Solution
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }

        public bool IsValid()
        {
            return new EmailValidator(Email).IsValid();
        }
    }
}
