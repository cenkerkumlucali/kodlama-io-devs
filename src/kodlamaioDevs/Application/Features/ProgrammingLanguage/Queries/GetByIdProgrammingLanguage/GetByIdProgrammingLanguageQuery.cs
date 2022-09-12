using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgrammingLanguage.Queries.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLanguageQuery:IRequest<GetByIdProgrammingLanguageDto>
{
    public int Id { get; set; }
    public class GetByIdProgrammingLanguageQueryHandler:IRequestHandler<GetByIdProgrammingLanguageQuery,GetByIdProgrammingLanguageDto>
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository;
        private IMapper _mapper;
        private ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;


        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            
            Domain.Entities.ProgrammingLanguage? programmingLanguage =
                await _programmingLanguageRepository.GetAsync(c => c.Id == request.Id);
            await _programmingLanguageBusinessRules.LanguageShouldExistWhenRequested(programmingLanguage);
            GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto =
                _mapper.Map<GetByIdProgrammingLanguageDto>(programmingLanguage);
            return getByIdProgrammingLanguageDto;
        }
    }
}