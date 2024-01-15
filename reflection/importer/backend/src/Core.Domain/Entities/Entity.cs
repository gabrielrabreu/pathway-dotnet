using System;

namespace Core.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
    }
}
