using AutoMapper;
using Something.Application.AutoMapper;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Domain.Commands.XptoCommands;
using Xunit;

namespace Something.Application.Tests.AutoMapper
{
    public class DtoToCommandMappingProfileTests
    {
        private readonly IMapper _mapper;

        public DtoToCommandMappingProfileTests()
        {
            _mapper = new MapperConfiguration(p => p.AddProfile(new DtoToCommandMappingProfile())).CreateMapper();
        }

        [Fact(DisplayName = "Map_ShouldMapAddXptoDtoToAddXptoCommand")]
        [Trait("Something - AutoMapper", "DtoToCommandMappingProfile")]
        public void Map_ShouldMapAddXptoDtoToAddXptoCommand()
        {
            // Arrange
            var addXptoDto = new AddXptoDto()
            {
                Name = "Xpto"
            };

            // Act
            var result = _mapper.Map<AddXptoCommand>(addXptoDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addXptoDto.Name, result.Entity.Name);
        }
    }
}
