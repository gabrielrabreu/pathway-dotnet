namespace Haze.Core.Infra.Data.Common
{
    public interface IDatabaseSettingsProvider
    {
        DatabaseSettings GetDatabaseSettings();
    }
}