using Core.Domain.Entities;
using Core.Infra.Data.Contexts;
using Core.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Core.Infra.Data.Tests.Repositories
{
    public class RepositoryTests
    {
        [Fact(DisplayName = "UnitOfWork_ShouldReturnContextAsIUnitOfWork")]
        [Trait("Core - Repository", "Repository")]
        public void UnitOfWork_ShouldReturnContextAsIUnitOfWork()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = myRepositoryConcreteClass.UnitOfWork;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mockMyBaseDbContextConcreteClass.Object, result);
        }

        [Fact(DisplayName = "Query_ShouldReturnDbSetAsQueryable")]
        [Trait("Core - Repository", "Repository")]
        public void Query_ShouldReturnDbSetAsQueryable()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = myRepositoryConcreteClass.Query();

            // Assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Search_ShouldReturnEmptyEntityList_WhenDontHaveEntities")]
        [Trait("Core - Repository", "Repository")]
        public async Task Search_ShouldReturnEmptyEntityList_WhenDontHaveEntities()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.Search(x => x.Code == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact(DisplayName = "Search_ShouldReturnEmptyEntityList_WhenPredicateDontMatchesNothing")]
        [Trait("Core - Repository", "Repository")]
        public async Task Search_ShouldReturnEmptyEntityList_WhenPredicateDontMatchesNothing()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>()
            {
                new MyEntityConcreteClass() { Code = 2 }
            };
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.Search(x => x.Code == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact(DisplayName = "Search_ShouldReturnEntityList_WhenPredicateMatchesSomething")]
        [Trait("Core - Repository", "Repository")]
        public async Task Search_ShouldReturnEntityList_WhenPredicateMatchesSomething()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>()
            {
                new MyEntityConcreteClass() { Code = 1 }
            };
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.Search(x => x.Code == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact(DisplayName = "GetAll_ShouldReturnEmptyEntityList_WhenDontHaveEntities")]
        [Trait("Core - Repository", "Repository")]
        public async Task GetAll_ShouldReturnEmptyEntityList_WhenDontHaveEntities()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact(DisplayName = "GetAll_ShouldReturnEntityList_WhenHaveEntities")]
        [Trait("Core - Repository", "Repository")]
        public async Task GetAll_ShouldReturnEntityList_WhenHaveEntities()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>()
            {
                new MyEntityConcreteClass() { Code = 1 }
            };
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnNull_WhenDontHaveEntities")]
        [Trait("Core - Repository", "Repository")]
        public async Task GetById_ShouldReturnNull_WhenDontHaveEntities()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.GetById(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnNull_WhenEntityNotFound")]
        [Trait("Core - Repository", "Repository")]
        public async Task GetById_ShouldReturnNull_WhenEntityNotFound()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>()
            {
                new MyEntityConcreteClass() { Id = Guid.NewGuid() }
            };
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.GetById(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }

        [Fact(DisplayName = "GetById_ShouldReturnEntity_WhenEntityFound")]
        [Trait("Core - Repository", "Repository")]
        public async Task GetById_ShouldReturnEntity_WhenEntityFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>()
            {
                new MyEntityConcreteClass() { Id = id }
            };
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            // Act
            var result = await myRepositoryConcreteClass.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(myEntityConcreteClasses.Single(), result);
        }

        [Fact(DisplayName = "Add_ShouldCallDbSetAdd")]
        [Trait("Core - Repository", "Repository")]
        public void Add_ShouldCallDbSetAdd()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            var myEntityConcreteClass = new MyEntityConcreteClass();

            // Act
            myRepositoryConcreteClass.Add(myEntityConcreteClass);

            // Assert
            mockMyDbSetMyEntityConcreteClass.Verify(e => e.Add(myEntityConcreteClass), Times.Once);
        }

        [Fact(DisplayName = "Update_ShouldCallDbSetUpdate")]
        [Trait("Core - Repository", "Repository")]
        public void Update_ShouldCallDbSetUpdate()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            var myEntityConcreteClass = new MyEntityConcreteClass();

            // Act
            myRepositoryConcreteClass.Update(myEntityConcreteClass);

            // Assert
            mockMyDbSetMyEntityConcreteClass.Verify(e => e.Update(myEntityConcreteClass), Times.Once);
        }

        [Fact(DisplayName = "Remove_ShouldCallDbSetRemove")]
        [Trait("Core - Repository", "Repository")]
        public void Remove_ShouldCallDbSetRemove()
        {
            // Arrange
            var mockDbContextOptions = new DbContextOptions<MyBaseDbContextConcreteClass>();
            var mockMyBaseDbContextConcreteClass = new Mock<MyBaseDbContextConcreteClass>(mockDbContextOptions);
            var myEntityConcreteClasses = new List<MyEntityConcreteClass>();
            var mockMyDbSetMyEntityConcreteClass = myEntityConcreteClasses.AsQueryable().BuildMockDbSet();
            mockMyBaseDbContextConcreteClass.Setup(e => e.Set<MyEntityConcreteClass>())
                .Returns(mockMyDbSetMyEntityConcreteClass.Object);
            var myRepositoryConcreteClass = new MyRepositoryConcreteClass(mockMyBaseDbContextConcreteClass.Object);

            var myEntityConcreteClass = new MyEntityConcreteClass();

            // Act
            myRepositoryConcreteClass.Remove(myEntityConcreteClass);

            // Assert
            mockMyDbSetMyEntityConcreteClass.Verify(e => e.Remove(myEntityConcreteClass), Times.Once);
        }
    }

    public class MyEntityConcreteClass : Entity { }

    public class MyBaseDbContextConcreteClass : BaseDbContext 
    {
        public DbSet<MyEntityConcreteClass> MyEntityConcreteClass { get; set; }

        public MyBaseDbContextConcreteClass(DbContextOptions<MyBaseDbContextConcreteClass> options) 
            : base(options) { }
    }

    public class MyRepositoryConcreteClass : Repository<MyEntityConcreteClass>
    {
        public MyRepositoryConcreteClass(MyBaseDbContextConcreteClass myBaseDbContextConcreteClass) 
            : base(myBaseDbContextConcreteClass) { }
    }
}
