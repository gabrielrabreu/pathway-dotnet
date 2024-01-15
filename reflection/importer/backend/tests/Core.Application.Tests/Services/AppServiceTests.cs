using AutoMapper;
using Core.Application.DataTransferObjects;
using Core.Application.Services;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Core.Application.Tests.Services
{
    public class AppServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IRepository<MyEntityConcreteClass>> _mockRepository;
        private readonly MyAppServiceConcreteClass _myAppServiceConcreteClass;

        public AppServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IRepository<MyEntityConcreteClass>>();
            _myAppServiceConcreteClass = new MyAppServiceConcreteClass(
                _mockMapper.Object,
                _mockRepository.Object);
        }

        [Fact(DisplayName = "GetAll_ShouldReturnEmptyDTOList_WhenDontHaveDTOs")]
        [Trait("Core - AppService", "AppService")]
        public async Task GetAll_ShouldReturnEmptyDTOList_WhenDontHaveDTOs()
        {
            // Arrange
            _mockRepository.Setup(e => e.GetAll()).ReturnsAsync(new List<MyEntityConcreteClass>());

            // Act
            var result = await _myAppServiceConcreteClass.GetAll();

            // Assert
            Assert.Empty(result);
        }

        [Fact(DisplayName = "GetAll_ShouldReturnDTOList_WhenHaveDTOs")]
        [Trait("Core - AppService", "AppService")]
        public async Task GetAll_ShouldReturnDTOList_WhenHaveDTOs()
        {
            // Arrange
            var entityOne = new MyEntityConcreteClass();
            var entityTwo = new MyEntityConcreteClass();
            var entityList = new List<MyEntityConcreteClass>() { entityOne, entityTwo };
            
            var dataTransferObjectOne = new MyDataTransferObjectConcreteClass();
            var dataTransferObjectTwo = new MyDataTransferObjectConcreteClass();
            var dataTransferObjectList = new List<MyDataTransferObjectConcreteClass>() { dataTransferObjectOne, dataTransferObjectTwo };

            _mockRepository.Setup(e => e.GetAll()).ReturnsAsync(entityList);

            _mockMapper.Setup(e => e.Map<IEnumerable<MyDataTransferObjectConcreteClass>>(It.Is<IEnumerable<MyEntityConcreteClass>>(s => 
                s.Equals(entityList)))).Returns(dataTransferObjectList);

            // Act
            var result = await _myAppServiceConcreteClass.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(dataTransferObjectList, result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnNull_WhenEntityNotFound")]
        [Trait("Core - AppService", "AppService")]
        public async Task GetById_ShouldReturnNull_WhenEntityNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockRepository.Setup(e => e.GetById(id)).ReturnsAsync((MyEntityConcreteClass)null);

            // Act
            var result = await _myAppServiceConcreteClass.GetById(id);

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnDTO_WhenEntityFound")]
        [Trait("Core - AppService", "AppService")]
        public async Task GetById_ShouldReturnDTO_WhenEntityFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new MyEntityConcreteClass();
            var dataTransferObject = new MyDataTransferObjectConcreteClass();

            _mockRepository.Setup(e => e.GetById(id)).ReturnsAsync(entity);

            _mockMapper.Setup(e => e.Map<MyDataTransferObjectConcreteClass>(It.Is<MyEntityConcreteClass>(s =>
                s.Equals(entity)))).Returns(dataTransferObject);

            // Act
            var result = await _myAppServiceConcreteClass.GetById(id);

            // Assert
            Assert.Equal(dataTransferObject, result);
        }
    }

    public class MyEntityConcreteClass : Entity { }

    public class MyDataTransferObjectConcreteClass : DataTransferObject { }

    public class MyAppServiceConcreteClass : AppService<MyDataTransferObjectConcreteClass, MyDataTransferObjectConcreteClass, MyEntityConcreteClass>
    {
        public MyAppServiceConcreteClass(IMapper mapper,
                                         IRepository<MyEntityConcreteClass> repository)
            : base(mapper, repository) { }

        public override async Task Add(MyDataTransferObjectConcreteClass myDataTransferObjectConcreteClass)
        {
            await Task.CompletedTask;
        }
    }
}
