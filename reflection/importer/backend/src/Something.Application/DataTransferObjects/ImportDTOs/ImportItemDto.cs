using Core.Application.DataTransferObjects;
using System;

namespace Something.Application.DataTransferObjects.ImportDTOs
{
    public class ImportItemDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public string ImportFileLine { get; set; }
        public bool Processed { get; set; }
        public string Error { get; set; }
    }
}
