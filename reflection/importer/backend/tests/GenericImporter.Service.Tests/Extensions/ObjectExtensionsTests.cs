using GenericImporter.Service.Extensions;
using GenericImporter.Service.Tests.Helpers;
using Xunit;

namespace GenericImporter.Service.Tests.Extensions
{
    public class ObjectExtensionsTests
    {
        #region SetValueByString
        [Fact(DisplayName = "CallMethod_ShouldCallMethod")]
        [Trait("GenericImporter - Extensions", "ObjectExtensions")]
        public void CallMethod_ShouldCallMethod()
        {
            // Arrange
            var instance = new MyClassWithPropertiesAndMethods();
            var methodName = "WillFind";
            var parameter = "TestName";

            // Act
            instance.CallMethod(methodName, parameter);

            // Assert
            Assert.Equal(parameter, instance.Name);
        }
        #endregion
    }
}
