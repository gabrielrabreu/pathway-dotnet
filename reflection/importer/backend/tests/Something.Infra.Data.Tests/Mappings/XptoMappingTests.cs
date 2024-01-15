using Something.Domain.Entities;
using Something.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Xunit;

namespace Something.Infra.Data.Tests.Mappings
{
    public class XptoMappingTests
    {
        [Fact(DisplayName = "Configure_ShouldHaveTableNameAsXpto")]
        [Trait("Something - Mapping", "Xpto")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHaveTableNameAsXpto()
        {
            // Arrange
            var entityTypeXpto = new EntityType(typeof(Xpto), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderXpto = new EntityTypeBuilder<Xpto>(entityTypeXpto);
            var xptoMaping = new XptoMapping();

            // Act
            xptoMaping.Configure(entityTypeBuilderXpto);

            // Assert
            var annotation = entityTypeBuilderXpto.Metadata.FindAnnotation("Relational:TableName");
            Assert.NotNull(annotation);
            Assert.Equal("Xpto", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHavePrimaryKey")]
        [Trait("Something - Mapping", "Xpto")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePrimaryKey()
        {
            // Arrange
            var entityTypeXpto = new EntityType(typeof(Xpto), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderXpto = new EntityTypeBuilder<Xpto>(entityTypeXpto);
            var xptoMaping = new XptoMapping();

            // Act
            xptoMaping.Configure(entityTypeBuilderXpto);

            // Assert
            var primaryKey = entityTypeBuilderXpto.Metadata.FindPrimaryKey();
            Assert.NotNull(primaryKey);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyCodeAsValueGeneratedOnAdd")]
        [Trait("Something - Mapping", "Xpto")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyCodeAsValueGeneratedOnAdd()
        {
            // Arrange
            var entityTypeXpto = new EntityType(typeof(Xpto), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderXpto = new EntityTypeBuilder<Xpto>(entityTypeXpto);
            var xptoMaping = new XptoMapping();

            // Act
            xptoMaping.Configure(entityTypeBuilderXpto);

            // Assert
            var property = entityTypeBuilderXpto.Metadata.FindProperty("Code");
            Assert.NotNull(property);
            Assert.Equal(ValueGenerated.OnAdd, property.ValueGenerated);
            Assert.False(property.IsNullable);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyNameColumnNameAsName")]
        [Trait("Something - Mapping", "Xpto")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyNameColumnNameAsName()
        {
            // Arrange
            var entityTypeXpto = new EntityType(typeof(Xpto), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderXpto = new EntityTypeBuilder<Xpto>(entityTypeXpto);
            var xptoMaping = new XptoMapping();

            // Act
            xptoMaping.Configure(entityTypeBuilderXpto);

            // Assert
            var property = entityTypeBuilderXpto.Metadata.FindProperty("Name");
            Assert.NotNull(property);
            var annotation = property.FindAnnotation("Relational:ColumnName");
            Assert.NotNull(annotation);
            Assert.Equal("Name", annotation.Value);
        }

        [Fact(DisplayName = "Configure_ShouldHavePropertyNameAsRequired")]
        [Trait("Something - Mapping", "Xpto")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<Pending>")]
        public void Configure_ShouldHavePropertyNameAsRequired()
        {
            // Arrange
            var entityTypeXpto = new EntityType(typeof(Xpto), new Model(), ConfigurationSource.Explicit);
            var entityTypeBuilderXpto = new EntityTypeBuilder<Xpto>(entityTypeXpto);
            var xptoMaping = new XptoMapping();

            // Act
            xptoMaping.Configure(entityTypeBuilderXpto);

            // Assert
            var property = entityTypeBuilderXpto.Metadata.FindProperty("Name");
            Assert.NotNull(property);
            Assert.False(property.IsNullable);
        }
    }
}
