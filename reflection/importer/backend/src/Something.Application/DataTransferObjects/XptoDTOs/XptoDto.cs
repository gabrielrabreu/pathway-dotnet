using Core.Application.DataTransferObjects;
using System;

namespace Something.Application.DataTransferObjects.XptoDtos
{
    public class XptoDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Version { get; set; }
        public double Value { get; set; }
    }
}
