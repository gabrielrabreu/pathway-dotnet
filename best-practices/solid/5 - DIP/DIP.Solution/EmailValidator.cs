using DIP.Solution.Interfaces;

namespace DIP.Solution
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValid(string email)
        {
            return email.Contains("@");
        }
    }
}
