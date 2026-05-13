

using MediatR;
using PreTach.Domain.Entities;

namespace PreTach.Application.UseCases.Vehicles.Commands
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
    {
        public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle(request.UserId, request.LicensePlate, request.Mileage, request.DailyKmAverage, request.Brand, request.Model, request.Year);

            return vehicle.VehicleId;
        }
    }
}
