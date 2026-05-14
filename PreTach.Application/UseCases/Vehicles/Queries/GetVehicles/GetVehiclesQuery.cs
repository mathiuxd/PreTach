using MediatR;
using PreTach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PreTach.Application.UseCases.Vehicles.Queries.GetVehicles
{
    public record GetVehiclesQuery(Guid UserId) : IRequest<List<Vehicle>>;
}
        