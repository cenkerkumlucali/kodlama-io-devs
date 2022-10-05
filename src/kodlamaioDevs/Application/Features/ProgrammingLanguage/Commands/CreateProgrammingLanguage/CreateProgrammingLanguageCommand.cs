using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProgrammingLanguage.Constants.Claims;

namespace Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>,ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => new[] { Admin, User };
    public class CreateProgrammingLanguageEntityCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand,
        CreatedProgrammingLanguageDto>
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository;
        private ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        private IMapper _mapper;
        

        public CreateProgrammingLanguageEntityCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }


        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request,
            CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
            Domain.Entities.ProgrammingLanguage programmingLanguage = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
            Domain.Entities.ProgrammingLanguage createdProgrammingLanguage =
                await _programmingLanguageRepository.AddAsync(programmingLanguage);
            CreatedProgrammingLanguageDto createdProgrammingLanguageDto =
                _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);
            return createdProgrammingLanguageDto;
        }
    }
}