using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Enums;
using Core.Security.Hashing;
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


        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
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
            Core.Security.Entities.User register = await _userRepository.AddAsync(user);
            RegisteredDto userForRegisterDto = _mapper.Map<RegisteredDto>(register);
            return userForRegisterDto;
        }
    }
}