using MediatR;

namespace PreTach.Application.UseCases.Users.Commands.Create
{
    public record CreateUserCommand(string Name, string Email, string PassworHash) : IRequest<Guid>;
}
