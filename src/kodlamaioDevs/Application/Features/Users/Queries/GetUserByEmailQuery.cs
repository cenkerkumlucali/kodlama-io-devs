using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetUserByEmailQuery:IRequest<Core.Security.Entities.User>
{
    public string? Email { get; set; }

    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery,Core.Security.Entities.User>
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public GetUserByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Core.Security.Entities.User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            Core.Security.Entities.User user =  _userRepository.Get(user => user.Email == request.Email);
           
            return user;
        }
    }
}