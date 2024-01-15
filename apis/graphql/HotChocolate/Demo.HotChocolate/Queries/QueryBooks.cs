using Demo.HotChocolate.Models;
using Demo.HotChocolate.Repositories;

namespace Demo.HotChocolate.Queries
{
    [ExtendObjectType("RootQuery")]
    public class QueryBooks
    {
        private readonly IDbContext _dbContext;

        public QueryBooks(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookModel? GetBookById(Guid id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == id);
        } 

        public IReadOnlyCollection<BookModel> GetBooks()
        {
            return _dbContext.Books;
        }
    }
}
