using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Something.Domain.Entities;

namespace Something.Infra.Data.Mappings
{
    public class ImportMapping : IEntityTypeConfiguration<Import>
    {
        public void Configure(EntityTypeBuilder<Import> builder)
        {
            builder.ToTable("Import");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasOne(x => x.ImportLayout)
                .WithMany(x => x.Imports)
                .IsRequired();

            builder.Property(x => x.Date)
                .HasColumnName("Date")
                .IsRequired();
        }
    }
}
