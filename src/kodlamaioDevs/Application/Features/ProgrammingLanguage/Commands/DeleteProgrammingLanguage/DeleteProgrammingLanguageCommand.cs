using Application.Features.ProgrammingLanguage.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProgrammingLanguage.Constants.Claims;


namespace Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>,ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, User };
    public class DeleteProgrammingLanguageCommandHandler:IRequestHandler<DeleteProgrammingLanguageCommand,DeletedProgrammingLanguageDto>
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository;
        private IMapper _mapper;

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.ProgrammingLanguage programmingLanguage = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
            Domain.Entities.ProgrammingLanguage deletedProgrammingLanguage =
                await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
            DeletedProgrammingLanguageDto deletedProgrammingLanguageDto =
                _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
            return deletedProgrammingLanguageDto;
        }
    }
}