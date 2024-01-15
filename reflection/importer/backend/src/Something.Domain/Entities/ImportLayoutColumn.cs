using System;

namespace Something.Domain.Entities
{
    public class ImportLayoutColumn
    {
        public Guid Id { get; set; }
        public Guid ImportLayoutId { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string Format { get; set; }

        // EF Rel.
        public virtual ImportLayout ImportLayout { get; set; }
    }
}
