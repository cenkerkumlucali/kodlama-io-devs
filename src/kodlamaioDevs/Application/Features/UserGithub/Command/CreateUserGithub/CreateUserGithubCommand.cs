using Application.Features.UserGithub.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserGithub.Command.CreateUserGithub;

public class CreateUserGithubCommand: IRequest<CreatedUserGithubDto>
{
    public int UserId { get; set; }
    public string Name { get; set; }

    public class CreateTechnologyCommandHandler : IRequestHandler<CreateUserGithubCommand,
        CreatedUserGithubDto>
    {
        private IUserGithubRepository _userGithubRepository;
        private IMapper _mapper;


        public CreateTechnologyCommandHandler(IUserGithubRepository userGithubRepository, IMapper mapper)
        {
            _userGithubRepository = userGithubRepository;
            _mapper = mapper;
        }


        public async Task<CreatedUserGithubDto> Handle(CreateUserGithubCommand request,
            CancellationToken cancellationToken)
        {
           Domain.Entities.UserGithub userGithub = _mapper.Map<Domain.Entities.UserGithub>(request);
            Domain.Entities.UserGithub createdUserGithub =
                await _userGithubRepository.AddAsync(userGithub);
            CreatedUserGithubDto createdUserGithubDto =
                _mapper.Map<CreatedUserGithubDto>(createdUserGithub);
            return createdUserGithubDto;
        }
    }
}