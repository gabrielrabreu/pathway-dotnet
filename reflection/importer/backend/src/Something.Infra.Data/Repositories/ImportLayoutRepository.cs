using Core.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Something.Domain.Entities;
using Something.Domain.Interfaces;
using Something.Infra.Data.Contexts;
using System.Linq;

namespace Something.Infra.Data.Repositories
{
    public class ImportLayoutRepository : Repository<ImportLayout>, IImportLayoutRepository
    {
        public ImportLayoutRepository(DataContext dataContext) : base(dataContext) { }

        protected override IQueryable<ImportLayout> ImproveQuery(IQueryable<ImportLayout> query)
        {
            return query.Include(i => i.Columns);
        }
    }
}
