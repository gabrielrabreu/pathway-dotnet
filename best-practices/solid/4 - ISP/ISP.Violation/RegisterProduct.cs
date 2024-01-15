using System;

namespace ISP.Violation
{
    internal class RegisterProduct : IRegister
    {
        public void ValidateData()
        {
            // Validate value
        }

        public void AddDatabase()
        {
            // Add to database
        }

        public void SendEmail()
        {
            // Do nothing, because product don't have email
            throw new NotImplementedException();
        }
    }
}
