using Entities.Models;

namespace Repository.Contracts;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task<User?> GetUserAsync(string email, string password, bool trackChanges);
}