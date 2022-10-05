using Application.Features.Technology.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Technology.Constants.Claims;

namespace Application.Features.Technology.Commands.DeleteTechnology;

public class DeleteTechnologyCommand:IRequest<DeletedTechnologyDto>,ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin };
    
    public class DeleteTechnologyCommandHandler:IRequestHandler<DeleteTechnologyCommand,DeletedTechnologyDto>
    {
        private ITechnologyRepository _technologyRepository;
        private IMapper _mapper;


        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Technology technology = _mapper.Map<Domain.Entities.Technology>(request);
            Domain.Entities.Technology deletedTechnology =
                await _technologyRepository.DeleteAsync(technology);
            DeletedTechnologyDto deletedTechnologyDto =
                _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
            return deletedTechnologyDto;
        }
    }
}