using Core.Application.DataTransferObjects;

namespace Something.Application.DataTransferObjects.ImportLayoutDTOs
{
    public class AddImportLayoutColumnDto : DataTransferObject
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public string Format { get; set; }

    }
}
