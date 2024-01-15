using Something.Domain.Entities;
using Something.Domain.Interfaces;
using Something.Infra.Data.Contexts;
using Core.Infra.Data.Repositories;

namespace Something.Infra.Data.Repositories
{
    public class XptoRepository : Repository<Xpto>, IXptoRepository
    {
        public XptoRepository(DataContext dataContext) : base(dataContext) { }
    }
}
