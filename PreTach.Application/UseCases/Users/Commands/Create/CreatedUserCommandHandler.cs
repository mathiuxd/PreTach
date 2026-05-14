using MediatR;
using PreTach.Domain.Entities;


namespace PreTach.Application.UseCases.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.PassworHash);

            return user.UserId;
        }
    }
}
