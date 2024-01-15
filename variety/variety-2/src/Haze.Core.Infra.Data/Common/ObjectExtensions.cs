using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Haze.Core.Infra.Data.Common
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            var camelCase = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, camelCase);
        }
    }
}