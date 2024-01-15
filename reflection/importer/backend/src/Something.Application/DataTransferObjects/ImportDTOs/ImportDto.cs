using Core.Application.DataTransferObjects;
using Something.Application.DataTransferObjects.ImportLayoutDTOs;
using System;
using System.Collections.Generic;

namespace Something.Application.DataTransferObjects.ImportDTOs
{
    public class ImportDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public ImportLayoutDto ImportLayout { get; set; }
        public DateTime Date { get; set; }
        public bool Processed { get; set; }
        public int ItemsUnprocessed { get; set; }
        public int ItemsFailedProcessed { get; set; }
        public int ItemsSuccessfullyProcessed { get; set; }
        public IEnumerable<ImportItemDto> ImportItems { get; set; }
    }
}
