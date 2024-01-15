using Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Something.Domain.Entities
{
    public class Import : Entity
    {
        public Guid ImportLayoutId { get; set; }
        public DateTime Date { get; set; }

        public bool Processed { get; set; }
        public int ItemsUnprocessed { get; set; }
        public int ItemsFailedProcessed { get; set; }
        public int ItemsSuccessfullyProcessed { get; set; }

        // EF Rel.
        public virtual ImportLayout ImportLayout { get; set; }
        public IEnumerable<ImportItem> ImportItems { get; set; }
    }
}
