using Application.Features.ProgrammingLanguage.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProgrammingLanguage.Constants.Claims;


namespace Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommand:IRequest<UpdatedProgrammingLanguageDto>,ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Roles => new[] { Admin, User };

    public class UpdateProgrammingLanguageCommandHandler:IRequestHandler<UpdateProgrammingLanguageCommand,UpdatedProgrammingLanguageDto>
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository;
        private IMapper _mapper;

        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.ProgrammingLanguage programmingLanguage = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
            Domain.Entities.ProgrammingLanguage createdProgrammingLanguage =
                await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
            UpdatedProgrammingLanguageDto  updatedProgrammingLanguageDto =
                _mapper.Map<UpdatedProgrammingLanguageDto>(createdProgrammingLanguage);
            return updatedProgrammingLanguageDto;
        }
    }
}