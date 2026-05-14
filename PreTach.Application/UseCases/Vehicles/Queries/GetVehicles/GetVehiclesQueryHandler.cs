using MediatR;
using PreTach.Application.Contracts;
using PreTach.Domain.Entities;

namespace PreTach.Application.UseCases.Vehicles.Queries.GetVehicles
{
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, List<Vehicle>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehiclesQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<Vehicle>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _vehicleRepository.GetByUserIdAsync(request.UserId);
        }
    }
}