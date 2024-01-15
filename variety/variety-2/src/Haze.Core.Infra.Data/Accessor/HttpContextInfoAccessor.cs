using Microsoft.AspNetCore.Http;
using System;

namespace Haze.Core.Infra.Data.Accessor
{
    public class HttpContextInfoAccessor : ITenantAccessor
    {
        private readonly IHttpContextAccessor _accessor;

        public HttpContextInfoAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetTenant()
        {
            if (_accessor.HttpContext.Request.Headers.ContainsKey("Tenant"))
            {
                var tenant = _accessor.HttpContext.Request.Headers["Tenant"].ToString();
                if (!string.IsNullOrEmpty(tenant))
                {
                    return tenant.Replace(" ", "");
                }
            }

            throw new Exception("Tenant is required.");
        }
    }
}