using System;

namespace Something.Domain.Entities
{
    public class ImportItem
    {
        public Guid Id { get; set; }
        public Guid ImportId { get; set; }
        public string ImportFileLine { get; set; }
        public bool Processed { get; set; }
        public string Error { get; set; }

        // EF Rel.
        public virtual Import Import { get; set; }
    }
}
