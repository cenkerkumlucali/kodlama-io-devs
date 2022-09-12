using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Auth;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoginedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService,
            AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Core.Security.Entities.User? user =
                await _userRepository.GetAsync(user => user.Email == request.UserForLoginDto.Email);
            
            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);
            LoginedDto loginDto = _mapper.Map<LoginedDto>(user);
            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            loginDto.AccessToken = createdAccessToken;
            return loginDto;
        }
    }
}