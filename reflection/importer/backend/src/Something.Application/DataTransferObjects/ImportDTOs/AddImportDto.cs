using Core.Application.DataTransferObjects;
using System;

namespace Something.Application.DataTransferObjects.ImportDTOs
{
    public class AddImportDto : DataTransferObject
    {
        public Guid ImportLayoutId { get; set; }
        public string ImportFileLines { get; set; }
    }
}
