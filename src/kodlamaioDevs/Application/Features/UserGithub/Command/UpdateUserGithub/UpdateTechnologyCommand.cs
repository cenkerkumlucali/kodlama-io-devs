using Application.Features.Technology.Dtos;
using Application.Features.UserGithub.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Technology.Commands.UpdateTechnology;

public class UpdateUserGithubCommand:IRequest<UpdatedUserGithubDto>
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    
    public class UpdateUserGithubCommandHandler:IRequestHandler<UpdateUserGithubCommand,UpdatedUserGithubDto>
    {
        private IUserGithubRepository _userGithubRepository;
        private IMapper _mapper;


        public UpdateUserGithubCommandHandler(IUserGithubRepository userGithubRepository, IMapper mapper)
        {
            _userGithubRepository = userGithubRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserGithubDto> Handle(UpdateUserGithubCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.UserGithub userGithub = _mapper.Map<Domain.Entities.UserGithub>(request);
            Domain.Entities.UserGithub createdUserGithub =
                await _userGithubRepository.UpdateAsync(userGithub);
            UpdatedUserGithubDto  updatedUserGithubDto =
                _mapper.Map<UpdatedUserGithubDto>(createdUserGithub);
            return updatedUserGithubDto;
        }
    }
}