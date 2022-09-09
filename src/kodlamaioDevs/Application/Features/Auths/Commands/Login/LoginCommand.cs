using Application.Features.Auths.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands;

public class LoginCommand : IRequest<LoginedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
    {
        private readonly IUserRepository _userRepository;
        private IUserOperationClaimRepository _userOperationClaimRepository;
        private IOperationClaimRepository _operationClaimRepository;
        private ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;


        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper,
            IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper,
            IOperationClaimRepository operationClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Core.Security.Entities.User? user =
                await _userRepository.GetAsync(user => user.Email == request.UserForLoginDto.Email);
            if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash,
                    user.PasswordSalt))
            {
                return new LoginedDto();
            }

            var userClaim = await _userOperationClaimRepository.GetAsync(c => c.UserId == user.Id);
            var claims = await _operationClaimRepository.GetListAsync(c => c.Id == userClaim.OperationClaimId);
            LoginedDto loginDto = _mapper.Map<LoginedDto>(user);
            loginDto.AccessToken = _tokenHelper.CreateToken(user, claims.Items);

            return loginDto;
        }
    }
}