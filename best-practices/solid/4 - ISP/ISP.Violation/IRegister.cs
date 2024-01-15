namespace ISP.Violation
{
    public interface IRegister
    {
        void ValidateData();
        void AddDatabase();
        void SendEmail();
    }
}
