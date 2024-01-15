using Core.Application.DataTransferObjects;
using Something.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Something.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class AddImportLayoutDto : DataTransferObject
    {
        public string Name { get; set; }
        public string Separator { get; set; }
        public ImportLayoutService Service { get; set; }
        public IEnumerable<AddImportLayoutColumnDto> Columns { get; set; }
    }
}
