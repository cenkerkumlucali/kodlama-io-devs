using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserGithubRepository:EfRepositoryBase<UserGithub,BaseDbContext>,IUserGithubRepository

{
    public UserGithubRepository(BaseDbContext context) : base(context)
    {
    }
}