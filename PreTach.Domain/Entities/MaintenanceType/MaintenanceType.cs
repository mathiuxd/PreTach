using PreTach.Domain.Exceptions;

namespace PreTach.Domain.Entities
{
    public class MaintenanceType
    {
        public Guid MaintenanceId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; } = null;
        public int? IntervalKm { get; private set; } = null;
        public int? IntervalDays { get; private set; } = null;
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; private set; } = [];

        private MaintenanceType()
        {

        }

        public MaintenanceType(string name, string? description, int? intervalkm = null, int? intervalDays = null)
        {
            ApplyBusinessRulesForDailyKm(intervalkm, intervalDays);
            ApplyBusinessRulesForDescription(description);
            ApplyBusinessRulesForName(name);
            MaintenanceId = Guid.CreateVersion7();
            Name = name;
            Description = description;
            IntervalKm = intervalkm;
            IntervalDays = intervalDays;
        }

        private void ApplyBusinessRulesForName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"El nombre del mantenimiento es requerido.");
            }

            if (name.Length < 1)
            {
                throw new BusinessRuleException($"El nombre del matenimiento debe de tener al menos un caracter");
            }

            if (name.Length > 80)
            {
                throw new BusinessRuleException($"El nombre del mantenimiento no se puede pasar de los 80 caracteres");
            }
        }

        private void ApplyBusinessRulesForDescription(string? description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                if (description.Length > 255)
                {
                    throw new BusinessRuleException($"La descripcion no puede tener mas de 255 caracteres");
                }
            }

        }   

        private void ApplyBusinessRulesForDailyKm(int? intervalkm, int? intervalDays)
        {
            if (intervalkm == null && intervalDays == null)
            {
                throw new BusinessRuleException("Se requiere al menos el intervalo en kilómetros o el intervalo en días");
            }

        }
    }
}
