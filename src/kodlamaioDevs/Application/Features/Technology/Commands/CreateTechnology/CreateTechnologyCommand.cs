using Application.Features.Technology.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Technology.Commands.CreateTechnology;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
{
    public int LanguageId { get; set; }
    public string Name { get; set; }

    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand,
        CreatedTechnologyDto>
    {
        private ITechnologyRepository _technologyRepository;
        private IMapper _mapper;


        public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }


        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request,
            CancellationToken cancellationToken)
        {
            Domain.Entities.Technology technology = _mapper.Map<Domain.Entities.Technology>(request);
            Domain.Entities.Technology createdTechnology =
                await _technologyRepository.AddAsync(technology);
            CreatedTechnologyDto createdTechnologyDto =
                _mapper.Map<CreatedTechnologyDto>(createdTechnology);
            return createdTechnologyDto;
        }
    }
}