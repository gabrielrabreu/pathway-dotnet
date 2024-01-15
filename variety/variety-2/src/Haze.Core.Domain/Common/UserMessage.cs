namespace Haze.Core.Domain.Common
{
    public class UserMessage
    {
        public string Message { get; }

        public UserMessage(string message)
        {
            Message = message;
        }

        public UserMessage Format(params object[] args)
        {
            return new UserMessage(string.Format(Message, args));
        }
    }
}