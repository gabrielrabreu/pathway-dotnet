using Core.Application.DataTransferObjects;
using Something.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Something.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class ImportLayoutDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Separator { get; set; }
        public ImportLayoutService Service { get; set; }
        public IEnumerable<ImportLayoutColumnDto> Columns { get; set; }
    }
}
