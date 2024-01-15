using GenericImporter.Service.Attributes;
using System;

namespace GenericImporter.Service.Tests.Helpers
{
    public class MyClassWithoutImportFieldAttribute
    {
        public string Name { get; set; }
    }

    public class MyClassWithDuplicatedImportFieldAttribute
    {
        [ImportField(Name = "Duplicated")]
        public string Name { get; set; }

        [ImportField(Name = "Duplicated")]
        public string AnotherName { get; set; }
    }

    public class MyClassWithImportFieldAttribute
    {
        [ImportField(Name = "WillFind")]
        public string Name { get; set; }
    }

    [ImportClass(Class = typeof(MyClassWithImportFieldAttribute), Method = "MethodAttribute")]
    public class MyClassWithImportClassAttribute { }

    public class MyClassWithoutImportClassAttribute { }

    public interface IMyClassWithPropertiesAndMethods
    {
        void WillFind(string name);
    }

    public class MyClassWithPropertiesAndMethods : IMyClassWithPropertiesAndMethods
    {
        public string Name { get; set; }

        public void WillFind(string name)
        {
            Name = name;
        }
    }

    public class MyClassWithProperties
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public double DoubleProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public Guid GuidProperty { get; set; }
    }
}
