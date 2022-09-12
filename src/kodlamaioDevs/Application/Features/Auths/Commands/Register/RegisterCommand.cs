using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Auth;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;


        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules, IAuthService authService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
            Core.Security.Entities.User user = new Core.Security.Entities.User()
            {
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                Email = request.UserForRegisterDto.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true,
                AuthenticatorType = AuthenticatorType.None,
            };
            Core.Security.Entities.User createdUser = await _userRepository.AddAsync(user);
            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
            RegisteredDto registeredDto = _mapper.Map<RegisteredDto>(createdAccessToken);
            registeredDto.AccessToken = createdAccessToken;
            return registeredDto;
        }
    }
}