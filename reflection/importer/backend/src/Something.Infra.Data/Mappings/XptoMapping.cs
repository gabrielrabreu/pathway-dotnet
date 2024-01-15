using Something.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Something.Infra.Data.Mappings
{
    public class XptoMapping : IEntityTypeConfiguration<Xpto>
    {
        public void Configure(EntityTypeBuilder<Xpto> builder)
        {
            builder.ToTable("Xpto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.Date)
                .HasColumnName("Date")
                .IsRequired();

            builder.Property(x => x.Version)
                .HasColumnName("Version")
                .IsRequired();

            builder.Property(x => x.Value)
                .HasColumnName("Value")
                .IsRequired();
        }
    }
}
