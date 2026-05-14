using MediatR;

namespace PreTach.Application.UseCases.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(Guid UserId, string Name, string Email) : IRequest<bool>;
}