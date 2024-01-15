using Core.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Something.Domain.Entities;
using Something.Domain.Interfaces;
using Something.Infra.Data.Contexts;
using System.Linq;

namespace Something.Infra.Data.Repositories
{
    public class ImportRepository : Repository<Import>, IImportRepository
    {
        public ImportRepository(DataContext dataContext) : base(dataContext) { }

        protected override IQueryable<Import> ImproveQuery(IQueryable<Import> query)
        {
            return query.Include(i => i.ImportLayout)
                .ThenInclude(i => i.Columns)
                .Include(i => i.ImportItems);
        }
    }
}
