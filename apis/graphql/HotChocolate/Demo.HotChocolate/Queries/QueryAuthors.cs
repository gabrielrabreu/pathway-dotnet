using Demo.HotChocolate.Models;
using Demo.HotChocolate.Repositories;

namespace Demo.HotChocolate.Queries
{
    [ExtendObjectType("RootQuery")]
    public class QueryAuthors
    {
        private readonly IDbContext _dbContext;

        public QueryAuthors(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AuthorModel? GetAuthorById(Guid id)
        {
            return _dbContext.Authors.FirstOrDefault(x => x.Id == id);
        }

        public IReadOnlyCollection<AuthorModel> GetAuthors()
        {
            return _dbContext.Authors;
        }
    }
}
