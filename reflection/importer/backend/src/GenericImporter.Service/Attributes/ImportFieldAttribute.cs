using System;

namespace GenericImporter.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ImportFieldAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
