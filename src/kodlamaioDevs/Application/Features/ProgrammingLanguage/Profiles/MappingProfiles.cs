using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguage.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            
            CreateMap<Domain.Entities.ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            
            CreateMap<Domain.Entities.ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            
            CreateMap<IPaginate<Domain.Entities.ProgrammingLanguage>,ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage,ProgrammingLanguageListDto>().ReverseMap();

            CreateMap<Domain.Entities.ProgrammingLanguage, GetByIdProgrammingLanguageDto>().ReverseMap();
        }
    }
}
