using GenericImporter.Service.Attributes;
using GenericImporter.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GenericImporter.Service.Extensions
{
    public static class TypeExtensions
    {
        public static PropertyInfo GetPropertyByImportName(this Type type, string name)
        {
            var foundedProperties = new List<PropertyInfo>();

            foreach (var property in type.GetProperties())
            {
                var attribute = property.GetImportAttribute();
                if (attribute != null && attribute.Name == name)
                {
                    foundedProperties.Add(property);
                }
            }

            if (foundedProperties.Count > 1)
            {
                throw new ImporterException("Duplicated ImportFieldAttributeName in class.");
            }

            return foundedProperties.SingleOrDefault();
        }

        public static ImportClassAttribute GetImportClassAttribute(this Type type)
        {
            var customAttribute = type.GetCustomAttributes(typeof(ImportClassAttribute), false).SingleOrDefault();

            if (customAttribute != null)
            {
                return (ImportClassAttribute)customAttribute;
            }

            return null;
        }

        public static object CreateInstance(this Type type)
        {
            return Activator.CreateInstance(type);
        }

        public static MethodInfo GetMethodOfInterface(this Type type, string name)
        {
            return type.GetMethod(name, BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
        }
    }
}
