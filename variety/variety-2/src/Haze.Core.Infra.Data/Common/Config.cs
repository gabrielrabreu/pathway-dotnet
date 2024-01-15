using System;

namespace Haze.Core.Infra.Data.Common
{
    public static class Config
    {
        public static readonly string Stage = "dev";

        public static readonly DatabaseSettings DatabaseSettings = new DatabaseSettings()
        {
            DataConnection = new ConnectionInfo()
            {
                Server = "DESKTOP-P380A6G\\SQLEXPRESS",
                Port = "5432",
                Username = "pb_sa",
                Password = Environment.GetEnvironmentVariable("ConnectionInfo_DataConnection_Password", EnvironmentVariableTarget.User)
            },
            CacheConnection = new ConnectionInfo()
            {
                Server = "DESKTOP-P380A6G\\SQLEXPRESS",
                Port = "5432",
                Username = "pb_sa",
                Password = Environment.GetEnvironmentVariable("ConnectionInfo_DataConnection_Password", EnvironmentVariableTarget.User)
            }
        };
    }
}