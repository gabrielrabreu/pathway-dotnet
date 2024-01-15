using GenericImporter.Service.Attributes;
using GenericImporter.Service.Exceptions;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace GenericImporter.Service.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static ImportFieldAttribute GetImportAttribute(this PropertyInfo propertyInfo)
        {
            var customAttribute = propertyInfo.GetCustomAttributes(typeof(ImportFieldAttribute), false).SingleOrDefault();

            if (customAttribute != null)
            {
                return (ImportFieldAttribute)customAttribute;
            }

            return null;
        }

        public static void SetValueByString(this PropertyInfo propertyInfo, object instance, string value, string format = null)
        {
            if (typeof(int) == propertyInfo.PropertyType)
            {
                propertyInfo.SetIntegerValueFromString(instance, value);
            }
            else if (typeof(double) == propertyInfo.PropertyType)
            {
                propertyInfo.SetDoubleValueFromString(instance, value);
            }
            else if (typeof(DateTime) == propertyInfo.PropertyType)
            {
                propertyInfo.SetDateTimeValueFromString(instance, value, format);
            }
            else if (typeof(Guid) == propertyInfo.PropertyType)
            {
                propertyInfo.SetGuidValueFromString(instance, value);
            }
            else
            {
                propertyInfo.SetValue(instance, value);
            }
        }

        public static void SetIntegerValueFromString(this PropertyInfo propertyInfo, object instance, string value)
        {
            if (int.TryParse(value, out _))
            {
                var convertedValue = int.Parse(value);
                propertyInfo.SetValue(instance, convertedValue);
                return;
            }

            throw new ImporterException($"Value informed for '{propertyInfo.Name}' is not a valid integer.");
        }

        public static void SetDoubleValueFromString(this PropertyInfo propertyInfo, object instance, string value)
        {
            if (double.TryParse(value, out _))
            {
                var convertedValue = double.Parse(value);
                propertyInfo.SetValue(instance, convertedValue);
                return;
            }

            throw new ImporterException($"Value informed for '{propertyInfo.Name}' is not a valid double.");
        }

        public static void SetDateTimeValueFromString(this PropertyInfo propertyInfo, object instance, string value, string format)
        {
            if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                var convertedValue = DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
                propertyInfo.SetValue(instance, convertedValue);
                return;
            }

            throw new ImporterException($"Value informed for '{propertyInfo.Name}' is not a valid DateTime.");
        }

        public static void SetGuidValueFromString(this PropertyInfo propertyInfo, object instance, string value)
        {
            if (Guid.TryParse(value, out _))
            {
                var convertedValue = Guid.Parse(value);
                propertyInfo.SetValue(instance, convertedValue);
                return;
            }

            throw new ImporterException($"Value informed for '{propertyInfo.Name}' is not a valid Guid.");
        }
    }
}
