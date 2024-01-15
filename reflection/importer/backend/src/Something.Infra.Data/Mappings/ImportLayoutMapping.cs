using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Something.Domain.Entities;

namespace Something.Infra.Data.Mappings
{
    public class ImportLayoutMapping : IEntityTypeConfiguration<ImportLayout>
    {
        public void Configure(EntityTypeBuilder<ImportLayout> builder)
        {
            builder.ToTable("ImportLayout");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.Separator)
                .HasColumnName("Separator")
                .IsRequired();

            builder.Property(x => x.Service)
                .HasColumnName("Service")
                .IsRequired();

            builder.HasMany(x => x.Columns)
                .WithOne(x => x.ImportLayout)
                .IsRequired();
        }
    }
}
