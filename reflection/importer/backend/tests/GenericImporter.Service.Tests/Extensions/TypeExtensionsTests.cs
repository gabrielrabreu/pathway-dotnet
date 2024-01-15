using GenericImporter.Service.Attributes;
using GenericImporter.Service.Exceptions;
using GenericImporter.Service.Extensions;
using GenericImporter.Service.Tests.Helpers;
using Xunit;

namespace GenericImporter.Service.Tests.Extensions
{
    public class TypeExtensionsTests
    {
        #region GetPropertyByImportName
        [Fact(DisplayName = "GetPropertyByImportName_ShouldReturnNull_WhenDontFindAttribute")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void GetPropertyByImportName_ShouldReturnNull_WhenDontFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportFieldAttribute);

            // Act
            var result = classType.GetPropertyByImportName("WillNotFind");

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetPropertyByImportName_ShouldThrowException_WhenDuplicatedImportFieldName")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void GetPropertyByImportName_ShouldThrowException_WhenDuplicatedImportFieldName()
        {
            // Arrange
            var classType = typeof(MyClassWithDuplicatedImportFieldAttribute);

            // Act & Assert
            var ex = Assert.Throws<ImporterException>(() => classType.GetPropertyByImportName("Duplicated"));
            Assert.Equal("Duplicated ImportFieldAttributeName in class.", ex.Message);
        }

        [Fact(DisplayName = "GetPropertyByImportName_ShouldReturnPropertyInfo_WhenFindAttribute")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void GetPropertyByImportName_ShouldReturnPropertyInfo_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportFieldAttribute);

            // Act
            var result = classType.GetPropertyByImportName("WillFind");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Name", result.Name);
        }
        #endregion

        #region GetImportClassAttribute
        [Fact(DisplayName = "GetImportClassAttribute_ShouldReturnNull_WhenDontFindAttribute")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void GetImportClassAttribute_ShouldReturnNull_WhenDontFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithoutImportClassAttribute);

            // Act
            var result = classType.GetImportClassAttribute();

            // Assert
            Assert.Null(result);
        }
        
        [Fact(DisplayName = "GetImportClassAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void GetImportClassAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportClassAttribute);

            // Act
            var result = classType.GetImportClassAttribute();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(MyClassWithImportFieldAttribute), result.Class);
            Assert.Equal("MethodAttribute", result.Method);
        }
        #endregion

        #region CreateInstance
        [Fact(DisplayName = "CreateInstance_ShouldReturnInstanceOfType")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void CreateInstance_ShouldReturnInstanceOfType()
        {
            // Arrange
            var classType = typeof(MyClassWithPropertiesAndMethods);

            // Act
            var result = classType.CreateInstance();

            // Assert
            Assert.NotNull(result);
            Assert.IsType(classType, result);
        }
        #endregion

        #region GetMethodOfInterface
        [Fact(DisplayName = "GetMethodOfInterface_ShouldReturnNull_WhenDontFindMethod")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void GetMethodOfInterface_ShouldReturnNull_WhenDontFindMethod()
        {
            // Arrange
            var classType = typeof(IMyClassWithPropertiesAndMethods);

            // Act
            var result = classType.GetMethodOfInterface("WillNotFind");

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetMethodOfInterface_ShouldReturnMethodInfo_WhenFindMethod")]
        [Trait("GenericImporter - Extensions", "TypeExtensions")]
        public void GetMethodOfInterface_ShouldReturnMethodInfo_WhenFindMethod()
        {
            // Arrange
            var classType = typeof(IMyClassWithPropertiesAndMethods);

            // Act
            var result = classType.GetMethodOfInterface("WillFind");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("WillFind", result.Name);
        }
        #endregion
    }
}
