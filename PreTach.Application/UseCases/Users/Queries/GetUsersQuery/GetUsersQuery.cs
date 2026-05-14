using MediatR;
using PreTach.Domain.Entities;

namespace PreTach.Application.UseCases.Users.Queries.GetUsers
{
    public record GetUsersQuery() : IRequest<List<User>>;
}