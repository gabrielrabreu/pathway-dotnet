using Core.Domain.Entities;
using System;

namespace Something.Domain.Entities
{
    public class Xpto : Entity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Version { get; set; }
        public double Value { get; set; }
    }
}
