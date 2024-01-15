using Core.Domain.Entities;
using Something.Domain.Enums;
using System.Collections.Generic;

namespace Something.Domain.Entities
{
    public class ImportLayout : Entity
    {
        public string Name { get; set; }
        public string Separator { get; set; }
        public ImportLayoutService Service { get; set; }

        // EF Rel.
        public IEnumerable<ImportLayoutColumn> Columns { get; set; }
        public IEnumerable<Import> Imports { get; set; }
    }
}
