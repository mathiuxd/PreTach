using PreTach.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace PreTach.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<Vehicle> Vehicles { get; set; } = []; // esto es como poner new List<Vehicle>()


        private User()
        {
            
        }

        public User(string name, string email, string passworHash)
        {   
            ApplyBusinessRulesForName(name);
            ApplyBusinessRulesForEmail(email);
            ApplyBusinessRulesForPasswordHash(passworHash);
            UserId = Guid.CreateVersion7();
            Name = name;
            Email = email;
            PasswordHash = passworHash;
            CreatedAt = DateTime.UtcNow;
        }

        private void ApplyBusinessRulesForName (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"El {nameof(name)} es requerido.");
            }

            if (name.Length < 4)
            {
                throw new BusinessRuleException($"El {nameof(name)} debe ser mayor a 4 letras.");
            }

            if (name.Length > 64)
            {
                throw new BusinessRuleException($"El {nameof(name)} debe ser menor a 64 letras.");
            }
        }

        private void ApplyBusinessRulesForEmail (String email) 
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException($"El {nameof(email)} es requerido.");
            }

            if (!Regex.IsMatch(email, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$"))
            {
                throw new BusinessRuleException($"El Email es invalido");
            }
        }

        private void ApplyBusinessRulesForPasswordHash(string passworHash)
        {
            if (string.IsNullOrWhiteSpace(passworHash))
            {
                throw new BusinessRuleException($"El {nameof(passworHash)} es requerido.");
            }

            if (passworHash.Length < 8)
            {
                throw new BusinessRuleException($"La contraseña debe ser mayor a 8 caracteres");
            }

            if (passworHash.Length > 64)
            {
                throw new BusinessRuleException($"El contraseña debe ser menor a 64 letras.");
            }
        }

    }
}
