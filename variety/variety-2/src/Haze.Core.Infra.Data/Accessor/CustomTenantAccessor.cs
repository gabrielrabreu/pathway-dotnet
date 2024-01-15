namespace Haze.Core.Infra.Data.Accessor
{
    public class CustomTenantAccessor : ITenantAccessor
    {
        public const string DesignTimeTenant = "designtime";
        private readonly string _tenant;

        public CustomTenantAccessor(string tenant)
        {
            _tenant = tenant;
        }

        public string GetTenant()
        {
            return _tenant;
        }
    }
}