using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.programmingLanguage.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQuery:IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListProgrammingLanguageQueryHandler:IRequestHandler<GetListProgrammingLanguageQuery,ProgrammingLanguageListModel>
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository;
        private IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguage =
                await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            ProgrammingLanguageListModel mappedProgrammingLanguageListModel =
                _mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);
            
            return mappedProgrammingLanguageListModel;
        }
    }
}