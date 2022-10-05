using Application.Features.SocialPlatforms.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.SocialPlatforms.Constants.Claims;

namespace Application.Features.SocialPlatforms.Command.UpdateSocialPlatform;

public class UpdateSocialPlatformCommand:IRequest<UpdatedSocialPlatformDto>,ISecuredRequest
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public string[] Roles => new[] { Admin, User };
    public class UpdateSocialPlatformCommandHandler:IRequestHandler<UpdateSocialPlatformCommand,UpdatedSocialPlatformDto>
    {
        private ISocialPlatformRepository _userGithubRepository;
        private IMapper _mapper;


        public UpdateSocialPlatformCommandHandler(ISocialPlatformRepository userGithubRepository, IMapper mapper)
        {
            _userGithubRepository = userGithubRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedSocialPlatformDto> Handle(UpdateSocialPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialPlatform userGithub = _mapper.Map<SocialPlatform>(request);
            SocialPlatform createdUserGithub =
                await _userGithubRepository.UpdateAsync(userGithub);
            UpdatedSocialPlatformDto  updatedUserGithubDto =
                _mapper.Map<UpdatedSocialPlatformDto>(createdUserGithub);
            return updatedUserGithubDto;
        }
    }
}