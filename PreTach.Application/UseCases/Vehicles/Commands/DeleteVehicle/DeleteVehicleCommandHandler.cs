using MediatR;
using PreTach.Application.Contracts;

namespace PreTach.Application.UseCases.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
            if (vehicle == null) return false;

            await _vehicleRepository.DeleteAsync(request.VehicleId);
            return true;
        }
    }
}