using Application.Features.SocialPlatforms.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialPlatforms.Queries.GetByIdSocialPlatform;

public class GetListSocialPlatformQuery : IRequest<SocialPlatformModel>
{
    public PageRequest PageRequest { get; set; }

    public class
        GetListSocialPlatformQueryHandler : IRequestHandler<GetListSocialPlatformQuery, SocialPlatformModel>
    {
        private ISocialPlatformRepository _socialPlatformRepository;
        private IMapper _mapper;


        public GetListSocialPlatformQueryHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper)
        {
            _socialPlatformRepository = socialPlatformRepository;
            _mapper = mapper;
        }

        public async Task<SocialPlatformModel> Handle(GetListSocialPlatformQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<SocialPlatform> socialPlatform =
                await _socialPlatformRepository.GetListAsync(include: c => c.Include(c => c.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            SocialPlatformModel getByIdSocialPlatformListModel =
                _mapper.Map<SocialPlatformModel>(socialPlatform);
            return getByIdSocialPlatformListModel;
        }
    }
}