using Demo.HotChocolate.Models;

namespace Demo.HotChocolate.Repositories
{
    public class DbContext : IDbContext
    {
        private readonly List<AuthorModel> _authors;
        public IReadOnlyCollection<AuthorModel> Authors => _authors;

        private readonly List<BookModel> _books;
        public IReadOnlyCollection<BookModel> Books => _books;

        public DbContext()
        {
            _authors = new List<AuthorModel>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Robert Cecil Martin"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Jon Skeet"
                }
            };

            _books = new List<BookModel>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Clean Code",
                    Author = _authors.ElementAt(0)
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Clean Architecture",
                    Author = _authors.ElementAt(0)
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "C# in depth",
                    Author = _authors.ElementAt(1)
                }
            };
        }
    }
}
