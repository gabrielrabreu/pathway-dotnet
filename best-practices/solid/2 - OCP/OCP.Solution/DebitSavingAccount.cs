namespace OCP.Solution
{
    public class DebitSavingAccount : DebitAccount
    {
        public override string Debit(decimal amount, string account)
        {
            return FormatTransaction();
        }
    }
}
