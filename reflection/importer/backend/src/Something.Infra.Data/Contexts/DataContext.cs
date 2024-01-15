using Something.Domain.Entities;
using Core.Infra.Data.Contexts;
using Something.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Something.Infra.Data.Contexts
{
    public class DataContext : BaseDbContext
    {
        public DbSet<Xpto> Xpto { get; set; }
        public DbSet<ImportLayout> ImportLayout { get; set; }
        public DbSet<Import> Import { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new XptoMapping());
            modelBuilder.ApplyConfiguration(new ImportLayoutMapping());
            modelBuilder.ApplyConfiguration(new ImportMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
