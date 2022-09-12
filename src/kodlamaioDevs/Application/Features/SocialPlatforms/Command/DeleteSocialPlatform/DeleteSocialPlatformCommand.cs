using Application.Features.SocialPlatforms.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialPlatforms.Command.DeleteSocialPlatform;

public class DeleteSocialPlatformCommand:IRequest<DeletedSocialPlatformDto>
{
    public int Id { get; set; }
    
    public class DeleteSocialPlatformCommandHandler:IRequestHandler<DeleteSocialPlatformCommand,DeletedSocialPlatformDto>
    {
        private ISocialPlatformRepository _userGithubRepository;
        private IMapper _mapper;


        public DeleteSocialPlatformCommandHandler(ISocialPlatformRepository userGithubRepository, IMapper mapper)
        {
            _userGithubRepository = userGithubRepository;
            _mapper = mapper;
        }

        public async Task<DeletedSocialPlatformDto> Handle(DeleteSocialPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialPlatform userGithub = _mapper.Map<SocialPlatform>(request);
            SocialPlatform deletedUserGithub =
                await _userGithubRepository.DeleteAsync(userGithub);
            DeletedSocialPlatformDto deletedUserGithubDto =
                _mapper.Map<DeletedSocialPlatformDto>(deletedUserGithub);
            return deletedUserGithubDto;
        }
    }
}