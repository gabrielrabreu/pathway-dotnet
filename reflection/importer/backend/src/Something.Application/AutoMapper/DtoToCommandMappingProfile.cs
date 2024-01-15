using AutoMapper;
using Something.Application.DataTransferObjects.ImportDTOs;
using Something.Application.DataTransferObjects.ImportLayoutDTOs;
using Something.Application.DataTransferObjects.XptoDtos;
using Something.Domain.Commands.ImportCommands;
using Something.Domain.Commands.ImportLayoutCommands;
using Something.Domain.Commands.XptoCommands;
using Something.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Something.Application.AutoMapper
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateXptoMap();
            CreateImportLayoutMap();
            CreateImportMap();
        }

        private void CreateXptoMap()
        {
            CreateMap<AddXptoDto, AddXptoCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new Xpto() 
                { 
                    Name = s.Name,
                    Date = s.Date,
                    Version = s.Version,
                    Value = s.Value
                }));
        }

        private void CreateImportLayoutMap()
        {
            CreateMap<AddImportLayoutDto, AddImportLayoutCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new ImportLayout()))
                .ForPath(d => d.Entity.Name, o => o.MapFrom(s => s.Name))
                .ForPath(d => d.Entity.Separator, o => o.MapFrom(s => s.Separator))
                .ForPath(d => d.Entity.Service, o => o.MapFrom(s => s.Service))
                .ForPath(d => d.Entity.Columns, o => o.MapFrom(s => s.Columns.Select(s2 => new ImportLayoutColumn
                {
                    Name = s2.Name,
                    Position = s2.Position,
                    Format = s2.Format,
                })));
        }

        private void CreateImportMap()
        {
            CreateMap<AddImportDto, AddImportCommand>()
                .ForMember(d => d.Entity, o => o.MapFrom(s => new Import()))
                .ForPath(d => d.Entity.ImportItems, o => o.MapFrom(s => MapImportFileLinesToImportItemList(s.ImportFileLines)))
                .ForPath(d => d.Entity.ImportLayoutId, o => o.MapFrom(s => s.ImportLayoutId));
        }

        private IEnumerable<ImportItem> MapImportFileLinesToImportItemList(string importFileLines)
        {
            var importItems = new List<ImportItem>();

            using (var reader = new StringReader(importFileLines))
            {
                string importFileLine;
                while ((importFileLine = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(importFileLine))
                    {
                        importItems.Add(new ImportItem() { ImportFileLine = importFileLine });
                    }
                }
            }

            return importItems;
        }
    }
}
