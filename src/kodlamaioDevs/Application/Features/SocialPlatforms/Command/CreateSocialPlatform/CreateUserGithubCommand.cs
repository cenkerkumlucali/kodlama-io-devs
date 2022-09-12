using Application.Features.SocialPlatforms.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialPlatforms.Command.CreateSocialPlatform;

public class CreateSocialPlatformCommand: IRequest<CreatedSocialPlatformDto>
{
    public int UserId { get; set; }
    public string Name { get; set; }

    public class CreateTechnologyCommandHandler : IRequestHandler<CreateSocialPlatformCommand,
        CreatedSocialPlatformDto>
    {
        private ISocialPlatformRepository _userGithubRepository;
        private IMapper _mapper;


        public CreateTechnologyCommandHandler(ISocialPlatformRepository userGithubRepository, IMapper mapper)
        {
            _userGithubRepository = userGithubRepository;
            _mapper = mapper;
        }


        public async Task<CreatedSocialPlatformDto> Handle(CreateSocialPlatformCommand request,
            CancellationToken cancellationToken)
        {
           SocialPlatform userGithub = _mapper.Map<SocialPlatform>(request);
            SocialPlatform createdUserGithub =
                await _userGithubRepository.AddAsync(userGithub);
            CreatedSocialPlatformDto createdUserGithubDto =
                _mapper.Map<CreatedSocialPlatformDto>(createdUserGithub);
            return createdUserGithubDto;
        }
    }
}