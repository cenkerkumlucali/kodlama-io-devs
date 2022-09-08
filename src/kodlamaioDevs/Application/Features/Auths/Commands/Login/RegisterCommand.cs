using Application.Features.Auths.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Auth.Commands;

public class LoginCommand : IRequest<LoginedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Core.Security.Entities.User? user =  await _userRepository.GetAsync(user => user.Email == request.UserForLoginDto.Email);
            if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            { }
            LoginedDto loginDto = _mapper.Map<LoginedDto>(user);
            return loginDto;
        }
    }
}