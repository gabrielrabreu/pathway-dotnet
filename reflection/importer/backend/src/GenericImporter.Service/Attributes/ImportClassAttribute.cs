using System;
using System.ComponentModel.DataAnnotations;

namespace GenericImporter.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ImportClassAttribute : Attribute
    {
        public Type Class { get; set; }
        public string Method { get; set; }
    }
}
