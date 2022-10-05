using Application.Features.Technology.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Technology.Constants.Claims;

namespace Application.Features.Technology.Commands.UpdateTechnology;

public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyDto>,ISecuredRequest
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public string[] Roles => new[] { Admin };
    
    public class UpdateTechnologyCommandHandler:IRequestHandler<UpdateTechnologyCommand,UpdatedTechnologyDto>
    {
        private ITechnologyRepository _technologyRepository;
        private IMapper _mapper;

        public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Technology technology = _mapper.Map<Domain.Entities.Technology>(request);
            Domain.Entities.Technology createdTechnology =
                await _technologyRepository.UpdateAsync(technology);
            UpdatedTechnologyDto  updatedTechnologyDto =
                _mapper.Map<UpdatedTechnologyDto>(createdTechnology);
            return updatedTechnologyDto;
        }
    }
}