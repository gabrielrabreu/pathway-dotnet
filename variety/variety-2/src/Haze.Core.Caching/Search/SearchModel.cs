using System.Collections.Generic;

namespace Haze.Core.Caching.Search
{
    public class SearchModel
    {
        public SortModel SortModel { get; set; }
        public IEnumerable<FilterModel> FilterModels { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}