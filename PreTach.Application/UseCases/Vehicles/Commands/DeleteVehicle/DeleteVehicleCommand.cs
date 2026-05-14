using MediatR;

namespace PreTach.Application.UseCases.Vehicles.Commands.DeleteVehicle
{
    public record DeleteVehicleCommand(Guid VehicleId) : IRequest<bool>;
}