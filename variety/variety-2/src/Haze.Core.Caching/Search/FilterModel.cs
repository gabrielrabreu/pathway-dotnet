using Haze.Core.Caching.Enums;

namespace Haze.Core.Caching.Search
{
    public class FilterModel
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public FilterOperation Operation { get; set; }
    }
}