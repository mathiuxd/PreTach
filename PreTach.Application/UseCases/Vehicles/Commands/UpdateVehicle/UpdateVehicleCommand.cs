using MediatR;

namespace PreTach.Application.UseCases.Vehicles.Commands.UpdateVehicle
{
    public record UpdateVehicleCommand(Guid VehicleId, string? Brand, string? Model, int? Year, int Mileage) : IRequest<bool>;
}