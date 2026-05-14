
using MediatR;

namespace PreTach.Application.UseCases.Vehicles.Commands.CreateVehicle
{   
   public record CreateVehicleCommand(Guid UserId, string LicensePlate, int Mileage, int DailyKmAverage, string? Brand = null, string? Model = null, int? Year = null) : IRequest<Guid>;
    
}
