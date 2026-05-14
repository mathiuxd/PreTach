using PreTach.Domain.Entities;

namespace PreTach.Application.Contracts
{
    public interface IVehicleRepository
    {
        Task AddAsync(Vehicle vehicle);
        Task<List<Vehicle>> GetByUserIdAsync(Guid userId);
        Task UpdateAsync(Vehicle vehicle);
        Task DeleteAsync(Guid vehicleId);
        Task<Vehicle> GetByIdAsync(Guid vehicleId);
    }
}