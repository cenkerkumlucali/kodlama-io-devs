using Application.Features.SocialPlatforms.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialPlatforms.Command.UpdateSocialPlatform;

public class UpdateSocialPlatformCommand:IRequest<UpdatedSocialPlatformDto>
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    
    public class UpdateUserGithubCommandHandler:IRequestHandler<UpdateSocialPlatformCommand,UpdatedSocialPlatformDto>
    {
        private ISocialPlatformRepository _userGithubRepository;
        private IMapper _mapper;


        public UpdateUserGithubCommandHandler(ISocialPlatformRepository userGithubRepository, IMapper mapper)
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