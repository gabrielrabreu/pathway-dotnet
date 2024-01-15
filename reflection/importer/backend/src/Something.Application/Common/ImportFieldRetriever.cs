using Core.Domain.Common;
using Something.Domain.Common;
using Something.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Something.Application.Common
{
    public class ImportFieldRetriever : IImportFieldRetriever
    {
        public PropertyInfo[] GetProperties(ImportLayoutService service)
        {
            var description = service.GetDescription();
            var dtoType = Type.GetType(description);
            if (dtoType == null)
            {
                return new List<PropertyInfo>().ToArray();
            }
            return dtoType.GetProperties();
        }
    }
}
