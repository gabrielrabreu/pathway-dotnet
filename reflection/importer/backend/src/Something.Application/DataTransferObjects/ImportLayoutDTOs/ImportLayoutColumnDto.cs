using Core.Application.DataTransferObjects;
using System;

namespace Something.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class ImportLayoutColumnDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string Format { get; set; }
    }
}
