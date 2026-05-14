using MediatR;

namespace PreTach.Application.UseCases.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid UserId) : IRequest<bool>;
}