using Core.Application.DataTransferObjects;
using GenericImporter.Service.Attributes;
using Something.Application.Interfaces;
using System;

namespace Something.Application.DataTransferObjects.XptoDtos
{
    [ImportClass(Class = typeof(IXptoAppService), Method = "Add")]
    public class AddXptoDto : DataTransferObject
    {
        [ImportField(Name="Name")]
        public string Name { get; set; }
        [ImportField(Name = "Date")]
        public DateTime Date { get; set; }
        [ImportField(Name = "Version")]
        public int Version { get; set; }
        [ImportField(Name = "Value")]
        public double Value { get; set; }
    }
}
