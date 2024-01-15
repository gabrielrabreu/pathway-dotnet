using AutoMapper;
using Something.Application.AutoMapper;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Domain.Entities;
using System;
using Xunit;

namespace Something.Application.Tests.AutoMapper
{
    public class EntityToDtoMappingProfileTests
    {
        private readonly IMapper _mapper;

        public EntityToDtoMappingProfileTests()
        {
            _mapper = new MapperConfiguration(p => p.AddProfile(new EntityToDtoMappingProfile())).CreateMapper();
        }

        [Fact(DisplayName = "Map_ShouldMapXptoToXptoDto")]
        [Trait("Something - AutoMapper", "EntityToDtoMappingProfile")]
        public void Map_ShouldMapXptoToXptoDto()
        {
            // Arrange
            var xpto = new Xpto()
            {
                Id = Guid.NewGuid(),
                Code = 1,
                Name = "Xpto"
            };

            // Act
            var result = _mapper.Map<XptoDto>(xpto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(xpto.Id, result.Id);
            Assert.Equal(xpto.Code, result.Code);
            Assert.Equal(xpto.Name, result.Name);
        }
    }
}
