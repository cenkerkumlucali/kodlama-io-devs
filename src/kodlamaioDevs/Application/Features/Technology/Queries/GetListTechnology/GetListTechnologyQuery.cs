using Application.Features.Technology.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technology.Queries.GetListTechnology;

public class GetListTechnologyQuery:IRequest<TechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListTechnologyQueryHandler:IRequestHandler<GetListTechnologyQuery,TechnologyListModel>
    {
        private ITechnologyRepository _technologyRepository;
        private IMapper _mapper;

        public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Technology> technology = await _technologyRepository.GetListAsync(
                include: m => m.Include(c => c.Language),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize
            );
            
            TechnologyListModel mappedTechnology = _mapper.Map<TechnologyListModel>(technology);
            return mappedTechnology;
        }
    }
}