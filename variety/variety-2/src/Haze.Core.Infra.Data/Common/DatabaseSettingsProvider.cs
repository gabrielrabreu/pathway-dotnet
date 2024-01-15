namespace Haze.Core.Infra.Data.Common
{
    public class DatabaseSettingsProvider : IDatabaseSettingsProvider
    {
        private readonly DatabaseSettings _databaseSettings;

        public DatabaseSettingsProvider(DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        public DatabaseSettings GetDatabaseSettings() => _databaseSettings;
    }
}