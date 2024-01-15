namespace OCP.Solution
{
    public class DebitCheckingAccount : DebitAccount
    {
        public override string Debit(decimal amount, string account)
        {
            return FormatTransaction();
        }
    }
}
