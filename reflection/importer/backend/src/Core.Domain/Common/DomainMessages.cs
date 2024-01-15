namespace Core.Domain.Common
{
    public static class DomainMessages
    {
        public static DomainMessage CommitFailed => new("There was an error saving data.");
        public static DomainMessage RequiredField => new("Please, ensure you enter {0}.");
        public static DomainMessage AlreadyInUse => new("The informed {0} is already in use.");
        public static DomainMessage InvalidFormat => new("The informed {0} is invalid.");
        public static DomainMessage MustBeGreatherOrEqual => new("The informed {0} must be greather than or equal to {1}.");
        public static DomainMessage NotFound => new("The informed {0} was not found.");
    }
}
