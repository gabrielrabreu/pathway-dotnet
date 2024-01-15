using Haze.Core.Caching.Models;
using Haze.Core.Caching.Search;
using System;
using System.Collections.Generic;

namespace Haze.Core.Caching.Queries
{
    public interface IQuery<TModel> where TModel : Model
    {
        TModel GetById(Guid id);

        IEnumerable<TModel> GetAll();

        IEnumerable<TModel> Search(SearchModel searchModel);
    }
}