using MediatR;
using PreTach.Application.Contracts;
using PreTach.Domain.Entities;

namespace PreTach.Application.UseCases.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}