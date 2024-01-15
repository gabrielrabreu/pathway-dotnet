using Demo.HotChocolate.Models;

namespace Demo.HotChocolate.Repositories
{
    public interface IDbContext
    {
        IReadOnlyCollection<AuthorModel> Authors { get; }
        IReadOnlyCollection<BookModel> Books { get; }
    }
}
