namespace Haze.Core.Infra.Data.Common
{
    public class DatabaseSettings
    {
        public ConnectionInfo DataConnection { get; set; }
        public ConnectionInfo CacheConnection { get; set; }
    }
}