using System;

namespace Haze.Core.Caching.Entities
{
    public abstract class CacheEntity
    {
        public string Data { get; set; }
        public Guid Id { get; set; }
        public string Tenant { get; set; }
        public DateTime Date { get; set; }
    }
}