using MediatR;
using PreTach.Application.Contracts;

namespace PreTach.Application.UseCases.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
            if (vehicle == null) return false;

            await _vehicleRepository.UpdateAsync(vehicle);
            return true;
        }
    }
}