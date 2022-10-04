using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Auth;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoggedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IPAddress { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
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

        public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Core.Security.Entities.User? user =
                await _userRepository.GetAsync(user => user.Email == request.UserForLoginDto.Email);
            
            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);
            LoggedDto loginDto = _mapper.Map<LoggedDto>(user);
            if (user.AuthenticatorType != AuthenticatorType.None)
            {
                
            }
            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            loginDto.AccessToken = createdAccessToken;
            loginDto.RefreshToken = addedRefreshToken;
            return loginDto;
        }
    }
}