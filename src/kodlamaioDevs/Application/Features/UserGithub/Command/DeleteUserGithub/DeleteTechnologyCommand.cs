using Application.Features.programmingLanguage.Dtos;
using Application.Features.Technology.Dtos;
using Application.Features.UserGithub.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technology.Commands.DeleteTechnology;

public class DeleteUserGithubCommand:IRequest<DeletedUserGithubDto>
{
    public int Id { get; set; }
    
    public class DeleteUserGithubCommandHandler:IRequestHandler<DeleteUserGithubCommand,DeletedUserGithubDto>
    {
        private IUserGithubRepository _userGithubRepository;
        private IMapper _mapper;


        public DeleteUserGithubCommandHandler(IUserGithubRepository userGithubRepository, IMapper mapper)
        {
            _userGithubRepository = userGithubRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserGithubDto> Handle(DeleteUserGithubCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.UserGithub userGithub = _mapper.Map<Domain.Entities.UserGithub>(request);
            Domain.Entities.UserGithub deletedUserGithub =
                await _userGithubRepository.DeleteAsync(userGithub);
            DeletedUserGithubDto deletedUserGithubDto =
                _mapper.Map<DeletedUserGithubDto>(deletedUserGithub);
            return deletedUserGithubDto;
        }
    }
}