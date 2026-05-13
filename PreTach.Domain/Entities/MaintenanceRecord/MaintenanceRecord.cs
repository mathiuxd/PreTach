using PreTach.Domain.Exceptions;

namespace PreTach.Domain.Entities
{
    public class MaintenanceRecord
    {
        public Guid MaintenanceRecordId { get; private set; }
        public Guid VehicleId { get; private set; }
        public Guid MaintenanceTypeId { get; private set; }
        public int MileageAtService { get; private set; }
        public decimal? Cost { get; private set; }
        public int NextMaintenanceKm { get; private set; }
        public DateTime Date { get; set; }
        public Vehicle Vehicle { get; private set; }
        public MaintenanceType MaintenanceType { get; private set; }


        private MaintenanceRecord()
        {
            
        }

        public MaintenanceRecord(Guid vehicleId, Guid maintenanceTypeId, int mileageAtService, int nextMaintenanceKm, decimal? cost = null)
        {
            ApplyBusinessRuleForNextMaintenance(nextMaintenanceKm);
            ApplyBusinessRuleForMileage(mileageAtService);
            MaintenanceRecordId = Guid.CreateVersion7();
            VehicleId = vehicleId;
            MaintenanceTypeId = maintenanceTypeId;
            MileageAtService = mileageAtService;
            Cost = cost;
            NextMaintenanceKm = nextMaintenanceKm;
            Date = DateTime.UtcNow;
        }

        private void ApplyBusinessRuleForMileage(int mileageAtService)
        {   
            if (mileageAtService < 0)
            {
                throw new BusinessRuleException($"El kilometraje no puede ser negativo");
            }
        }

        private void ApplyBusinessRuleForNextMaintenance(int nextMaintenanceKm)
        {
            if (nextMaintenanceKm < 0)
            {
                throw new BusinessRuleException($"El kilometraje no puede ser negativo");
            }
        }
    }
}
