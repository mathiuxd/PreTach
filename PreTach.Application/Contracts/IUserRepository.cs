using PreTach.Domain.Entities;

namespace PreTach.Application.Contracts
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid userId);
        Task<User?> GetByEmailAsync(string email);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid userId);
        Task<List<User>> GetAllAsync();
    }
}