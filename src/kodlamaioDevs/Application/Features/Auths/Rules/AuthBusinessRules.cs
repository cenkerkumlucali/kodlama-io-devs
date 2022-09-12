using Application.Features.Auths.Constansts;
using Application.Services.Auth;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;

namespace Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task UserShouldBeExists(Core.Security.Entities.User? user)
    {
        if (user == null) throw new BusinessException(Messages.UserShouldBeExists);
        return Task.CompletedTask;
    }

    public async Task UserEmailShouldBeNotExists(string email)
    {
        Core.Security.Entities.User? user = await _userRepository.GetAsync(c => c.Email == email);
        if (user != null) throw new BusinessException(Messages.UserMailAlreadyExists);
    }
    public async Task UserPasswordShouldBeMatch(int id, string password)
    {
        Core.Security.Entities.User? user = await _userRepository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(Messages.PasswordShouldBeMatch);
    }
}