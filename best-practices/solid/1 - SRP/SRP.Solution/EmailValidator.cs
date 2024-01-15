namespace SRP.Solution
{
    public class EmailValidator
    {
        public string Email { get; }

        public EmailValidator(string email)
        {
            Email = email;
        }

        public bool IsValid()
        {
            return Email.Contains("@");
        }
    }
}
