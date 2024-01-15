using System;
using System.Threading.Tasks;

namespace GenericImporter.Service.Extensions
{
    public static class ObjectExtensions
    {
        public static async Task CallMethod(this object service, string methodName, object parameter)
        {
            var method = service.GetType().GetMethodOfInterface(methodName);
            var convertedParameter = Convert.ChangeType(parameter, parameter.GetType());
            var invoke = method.Invoke(service, new object[] { convertedParameter });
            await (invoke as Task);
        }
    }
}
