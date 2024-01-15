namespace OCP.Solution
{
    public class DebitInvestmentAccount : DebitAccount
    {
        public override string Debit(decimal amount, string account)
        {
            return FormatTransaction();
        }
    }
}
