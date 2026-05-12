using PreTach.Domain.Exceptions;

namespace PreTach.Domain.Entities
{
    public class Vehicle
    {
        public Guid VehicleId { get; private set; }
        public Guid UserId { get; private set; }
        public string? Brand { get; private set; } = null;
        public string? Model { get; private set; } = null;
        public int? Year { get; private set; } = null;
        public string LicensePlate { get; private set; }
        public int Mileage { get; private set; }
        public int DailyKmAverage { get; private set; }

        private Vehicle()
        {

        }

        public Vehicle(Guid userId, string licensePlate, int mileage, int dailyKmAverage, string? brand = null, string? model = null, int? year = null)
        {
            ApplyBusinessRuleForDailyKmAverage(dailyKmAverage);
            ApplyBusinessRuleForMileage(mileage);
            ApplyBusinessRuleForLicensePlate(licensePlate);
            VehicleId = Guid.CreateVersion7();
            UserId = userId;
            Brand = brand;
            Model = model;
            Year = year;
            LicensePlate = licensePlate;
            Mileage = mileage;
            DailyKmAverage = dailyKmAverage;
        }

        private void ApplyBusinessRuleForLicensePlate(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                throw new BusinessRuleException($"El {nameof(licensePlate)} es requerido.");
            }

            if (licensePlate.Length < 5)
            {
                throw new BusinessRuleException($"La Placa no puede ser menor a 5 letras");
            }

            if (licensePlate.Length > 8)
            {
                throw new BusinessRuleException($"El Placa debe ser menor a 8 letras.");
            }
        }

        private void ApplyBusinessRuleForMileage(int mileage) 
        {
            if (mileage < 0)
            {
                throw new BusinessRuleException($"El kilometraje no puede ser negativo");
            }
        }

        //Deuda tecnica :P
        private void ApplyBusinessRuleForDailyKmAverage(int dailyKmAverage)
        {
            ApplyBusinessRuleForMileage(dailyKmAverage);
        }



    }
}
