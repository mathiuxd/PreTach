using MediatR;

namespace PreTach.Application.UseCases.Users.Commands
{
    public record CreateUserCommand(string Name, string Email, string PassworHash) : IRequest<Guid>;
}
