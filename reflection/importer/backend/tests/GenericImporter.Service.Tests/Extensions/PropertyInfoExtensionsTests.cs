using GenericImporter.Service.Exceptions;
using GenericImporter.Service.Extensions;
using GenericImporter.Service.Tests.Helpers;
using System;
using Xunit;

namespace GenericImporter.Service.Tests.Extensions
{
    public class PropertyInfoExtensionsTests
    {
        #region GetImportAttribute
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Fact(DisplayName = "GetImportAttribute_ShouldReturnNull_WhenDontFindAttribute")]
        public void GetImportAttribute_ShouldReturnNull_WhenDontFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithoutImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = propertyInfo.GetImportAttribute();

            // Assert
            Assert.Null(result);
        }

        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Fact(DisplayName = "GetImportAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute")]
        public void GetImportAttribute_ShouldReturnImportClassAttribute_WhenFindAttribute()
        {
            // Arrange
            var classType = typeof(MyClassWithImportFieldAttribute);
            var propertyInfo = classType.GetProperty("Name");

            // Act
            var result = propertyInfo.GetImportAttribute();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("WillFind", result.Name);
        }
        #endregion

        #region SetIntegerValueFromString
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Theory(DisplayName = "SetIntegerValueFromString_ShouldThrowImporterException_WhenStringIsInvalidInteger")]
        [InlineData("Value")]
        [InlineData("10.0")]
        [InlineData(null)]
        public void SetIntegerValueFromString_ShouldThrowImporterException_WhenStringIsInvalidInteger(string value)
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("IntProperty");
            var instance = new MyClassWithProperties();

            // Act & Assert
            var ex = Assert.Throws<ImporterException>(() => propertyInfo.SetIntegerValueFromString(instance, value));
            Assert.Equal("Value informed for 'IntProperty' is not a valid integer.", ex.Message);
        }

        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Fact(DisplayName = "SetIntegerValueFromString_ShouldSetPropertyValue_WhenStringIsValidInteger")]
        public void SetIntegerValueFromString_ShouldSetPropertyValue_WhenStringIsValidInteger()
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("IntProperty");
            var instance = new MyClassWithProperties();
            var value = "1";

            // Act

            propertyInfo.SetIntegerValueFromString(instance, value);

            // Assert
            Assert.Equal(1, instance.IntProperty);
        }
        #endregion

        #region SetDoubleValueFromString
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Theory(DisplayName = "SetDoubleValueFromString_ShouldThrowImporterException_WhenStringIsInvalidDouble")]
        [InlineData("Value")]
        [InlineData(null)]
        public void SetDoubleValueFromString_ShouldThrowImporterException_WhenStringIsInvalidDouble(string value)
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("DoubleProperty");
            var instance = new MyClassWithProperties();

            // Act & Assert
            var ex = Assert.Throws<ImporterException>(() => propertyInfo.SetDoubleValueFromString(instance, value));
            Assert.Equal("Value informed for 'DoubleProperty' is not a valid double.", ex.Message);
        }

        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Fact(DisplayName = "SetDoubleValueFromString_ShouldSetPropertyValue_WhenStringIsValidDouble")]
        public void SetDoubleValueFromString_ShouldSetPropertyValue_WhenStringIsValidDouble()
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("DoubleProperty");
            var instance = new MyClassWithProperties();
            var value = "1,50";

            // Act

            propertyInfo.SetDoubleValueFromString(instance, value);

            // Assert
            Assert.Equal(1.50, instance.DoubleProperty);
        }
        #endregion

        #region SetDateTimeValueFromString
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Theory(DisplayName = "SetDateTimeValueFromString_ShouldThrowImporterException_WhenStringIsInvalidDateTime")]
        [InlineData("Value")]
        [InlineData("150")]
        [InlineData(null)]
        public void SetDateTimeValueFromString_ShouldThrowImporterException_WhenStringIsInvalidDateTime(string value)
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("DateTimeProperty");
            var instance = new MyClassWithProperties();

            // Act & Assert
            var ex = Assert.Throws<ImporterException>(() => propertyInfo.SetDateTimeValueFromString(instance, value, ""));
            Assert.Equal("Value informed for 'DateTimeProperty' is not a valid DateTime.", ex.Message);
        }

        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Theory(DisplayName = "SetDateTimeValueFromString_ShouldSetPropertyValue_WhenStringIsValidDateTime")]
        [InlineData("10/11/2021 20:35", "dd/MM/yyyy HH:mm")]
        [InlineData("10/11/2021 20:35:00", "dd/MM/yyyy HH:mm:ss")]
        [InlineData("101120212035", "ddMMyyyyHHmm")]
        [InlineData("10112021203500", "ddMMyyyyHHmmss")]
        [InlineData("202111102035", "yyyyMMddHHmm")]
        public void SetDateTimeValueFromString_ShouldSetPropertyValue_WhenStringIsValidDateTime(string value, string format)
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("DateTimeProperty");
            var instance = new MyClassWithProperties();

            // Act
            propertyInfo.SetDateTimeValueFromString(instance, value, format);

            // Assert
            Assert.Equal(new DateTime(2021, 11, 10, 20, 35, 0), instance.DateTimeProperty);
        }
        #endregion

        #region SetGuidValueFromString
        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Theory(DisplayName = "SetGuidValueFromString_ShouldThrowImporterException_WhenStringIsInvalidGuid")]
        [InlineData("Value")]
        [InlineData("150")]
        [InlineData(null)]
        public void SetGuidValueFromString_ShouldThrowImporterException_WhenStringIsInvalidGuid(string value)
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("GuidProperty");
            var instance = new MyClassWithProperties();

            // Act & Assert
            var ex = Assert.Throws<ImporterException>(() => propertyInfo.SetGuidValueFromString(instance, value));
            Assert.Equal("Value informed for 'GuidProperty' is not a valid Guid.", ex.Message);
        }

        [Trait("GenericImporter - Extensions", "PropertyInfoExtensions")]
        [Fact(DisplayName = "SetGuidValueFromString_ShouldSetPropertyValue_WhenStringIsValidGuid")]
        public void SetGuidValueFromString_ShouldSetPropertyValue_WhenStringIsValidGuid()
        {
            // Arrange
            var propertyInfo = typeof(MyClassWithProperties).GetProperty("GuidProperty");
            var instance = new MyClassWithProperties();
            var value = "3e7396c2-bfe3-49fc-90f9-6af4fbcdf19b";

            // Act

            propertyInfo.SetGuidValueFromString(instance, value);

            // Assert
            Assert.Equal(Guid.Parse("3e7396c2-bfe3-49fc-90f9-6af4fbcdf19b"), instance.GuidProperty);
        }
        #endregion
    }
}
