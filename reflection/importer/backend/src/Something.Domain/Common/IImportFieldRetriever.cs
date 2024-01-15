using Something.Domain.Enums;
using System.Reflection;

namespace Something.Domain.Common
{
    public interface IImportFieldRetriever
    {
        PropertyInfo[] GetProperties(ImportLayoutService service);
    }
}
