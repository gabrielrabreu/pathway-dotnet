namespace OCP.Violation
{
    public class DebitAccount
    {
        public void Debit(decimal amount, string account, AccountType accountType)
        {
            if (accountType == AccountType.Checking)
            {
                // Do something
            }

            if (accountType == AccountType.Saving)
            {
                // Do something
            }
        }
    }
}
